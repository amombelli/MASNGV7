using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.AsientoContable;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO
{
    /// <summary>
    /// Funciones especificas para la interaccion con la base de datos
    /// </summary>
    public class AsientoDbManager
    {
        private T0601_DOCU_H _header = new T0601_DOCU_H();
        private List<T0602_DOCU_S> _itemList;
        public AsientoBase.IdentificacionAsiento GrabaAsientoEnDatabase(T0601_DOCU_H header, List<T0602_DOCU_S> items)
        {
            _header = header;
            _itemList = new List<T0602_DOCU_S>(items);

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_header.IDDOCU == 0)
                {
                    AsignaNumeroAsiento();
                    AsignaLogData();
                    db.T0601_DOCU_H.Add(header);
                    //Header no existe >> creo con numero asignado
                }
                else
                {
                    //Se provee header por lo tanto debiera existir en memoria.-
                    var dataH = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == header.IDDOCU);
                    if (dataH != null)
                    {
                        _header.ST = "Updated on " + DateTime.Today;
                        db.Entry(dataH).CurrentValues.SetValues(header); //Header ya existe >> actualizo
                    }
                    else
                    {
                        AsignaLogData();
                        db.T0601_DOCU_H.Add(header); //Header no existe >> creo con numero asignado
                    }
                }
                db.SaveChanges();

                var segmentos = db.T0602_DOCU_S.Where(c => c.IDDOCU == _header.IDDOCU);
                if (segmentos.Any())
                {
                    db.T0602_DOCU_S.RemoveRange(segmentos);
                    db.SaveChanges();
                }

                foreach (var item in _itemList)
                {
                    item.IDDOCU = _header.IDDOCU;
                    item.NASX1 = _header.NASX1;
                    item.NASX2 = _header.NASX2;
                    item.LOG_USER = _header.LOG_USER;
                    item.FECHA_HOY = DateTime.Now;
                    db.T0602_DOCU_S.Add(item);
                    db.SaveChanges();
                }

                db.SaveChanges();
                var resultado = new AsientoBase.IdentificacionAsiento
                {
                    IdDocu = _header.IDDOCU,
                    NasX1 = (decimal)_header.NASX1,
                    NasX2 = (decimal)_header.NASX2
                };
                return resultado;
            }
        }
        public void LoadAsientoFromDataBase(int idDocu)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _header = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == idDocu);
                _itemList = db.T0602_DOCU_S.Where(c => c.IDDOCU == idDocu).ToList();
            }
        }
        public T0601_DOCU_H LoadAsientoHeader(int idDocu)
        {
            return _header;
        }
        public List<T0602_DOCU_S> LoadAsientoItems(int idDocu)
        {
            return _itemList;
        }
        private void AsignaNumeroAsiento()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataAsn = new T0004_ASN();
                switch (_header.TIPO)
                {
                    case "L1":
                        dataAsn.PRE = "1";
                        dataAsn.TIPO = "1";
                        break;
                    case "L2":
                        dataAsn.PRE = "8";
                        dataAsn.TIPO = "2";
                        break;

                    default:
                        MessageBox.Show(@"Error no manejado en tipo de documento TipoLX!");
                        _header.IDDOCU = 0;
                        _header.NASX1 = -1;
                        _header.NASX2 = -1;
                        break;
                }

                var data =
                    db.T0004_ASN.SingleOrDefault(
                        c => c.XYEAR == _header.YEAR.Substring(2, 2) && c.TIPO == _header.TIPO.Substring(1, 1));
                if (data == null)
                {
                    dataAsn.ASN = 0;
                    dataAsn.XYEAR = _header.YEAR.Substring(2, 2);
                    dataAsn.XDOC = "AS";
                    dataAsn.NASX1X2 =
                        Convert.ToDecimal(dataAsn.PRE.ToString() + dataAsn.XYEAR + _header.MES.ToString() + "00000");
                    db.T0004_ASN.Add(dataAsn);
                    db.SaveChanges();
                    _header.NASX1 = Convert.ToDecimal(dataAsn.NASX1X2);
                    _header.NASX2 = 0;
                    _header.IDDOCU = GetNextNumeroAsientoIdDocu();
                }
                else
                {
                    var asn = Convert.ToString(data.ASN + 1);
                    var numeroAsiento = data.PRE.ToString() + data.XYEAR + _header.MES.ToString() +
                                        asn.PadLeft(5, '0');

                    data.ASN = (short?)(data.ASN + 1);
                    dataAsn.NASX1X2 = Convert.ToDecimal(numeroAsiento);
                    db.SaveChanges();
                    _header.NASX1 = Convert.ToDecimal(dataAsn.NASX1X2); //**move to decimal
                    _header.NASX2 = data.ASN;
                    _header.IDDOCU = GetNextNumeroAsientoIdDocu();
                }
            }
        }
        private void AsignaLogData()
        {
            _header.FECHA_HOY = DateTime.Now;
            _header.LOG_USER = Environment.UserName;
            _header.FechaOP = DateTime.Now;
            _header.StatusCancel = false;
        }
        private static int GetNextNumeroAsientoIdDocu()
        {
            return new TecserData(GlobalApp.CnnApp).T0601_DOCU_H.Max(c => c.IDDOCU) + 1;
        }
    }
}
