using System;
using System.Linq;
using Tecser.Business.MainApp;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.FI
{

    /// <summary>
    /// El Status Registrado se maneja desde GestionT400 por su complejidad
    /// </summary>
    public class GestionT400Status
    {
        private readonly int _idFactura;
        public DocumentFIStatusManager.StatusHeader Status { private set; get; }
        public T0400_FACTURA_H Header400 { private set; get; }

        public GestionT400Status(int idFactura)
        {
            _idFactura = idFactura;
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                Header400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                Status = new DocumentFIStatusManager().MapStatusHeaderFromText(Header400.StatusFactura);
            }
        }

        public DocumentFIStatusManager.StatusHeader SetPendienteCae()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                Status = DocumentFIStatusManager.StatusHeader.PendienteCAE;
                Header400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                Header400.StatusFactura = Status.ToString();
                db.SaveChanges();
                return Status;
            }
        }
        public DocumentFIStatusManager.StatusHeader SetContabilizada(int idctacte, int iddocu, decimal nasx1)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                Status = DocumentFIStatusManager.StatusHeader.Contabilizada;
                Header400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                Header400.StatusFactura = Status.ToString();
                Header400.IdCtaCte = idctacte;
                Header400.NAS = iddocu;
                Header400.NASX1X2 = nasx1;
                db.SaveChanges();
                //Check T0300 - NCD
                if (Header400.IdNCD != null)
                {
                    var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == Header400.IdNCD.Value);
                    if (t3 != null)
                    {
                        t3.idCtaCte = idctacte;
                        t3.ASIENTO = iddocu;
                        db.SaveChanges();
                    }
                }
                else
                {
                    var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.idFacturaT0400 == _idFactura);
                    if (t3 != null)
                    {
                        t3.idCtaCte = idctacte;
                        t3.ASIENTO = iddocu;
                        db.SaveChanges();
                    }
                }
                return Status;
            }
        }

        /// <summary>
        /// Con CAE Aprobado - Setea Status y Setea el numero de documento en todas las tablas
        /// 
        /// </summary>
        public DocumentFIStatusManager.StatusHeader SetAprobadaCae(string numeroCae, DateTime fechaVencimientoCae, string puntoVta, string numeroDocAfip)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                Header400 = db.T0400_FACTURA_H.SingleOrDefault(c => c.IDFACTURA == _idFactura);
                Header400.StatusFactura = Status.ToString();
                Status = DocumentFIStatusManager.StatusHeader.Aprobada;
                Header400.CAE = numeroCae;
                Header400.CAE_VTO = fechaVencimientoCae;
                Header400.PV_AFIP = Convert.ToInt32(puntoVta).ToString("D4");
                Header400.ND_AFIP = Convert.ToInt64(numeroDocAfip).ToString("D8");
                Header400.NumeroDoc = Convert.ToInt32(puntoVta).ToString("D4") + "-" +
                                      Convert.ToInt64(numeroDocAfip).ToString("D8");
                db.SaveChanges();
                var l401 = db.T0401_FACTURA_I.Where(c => c.IDFactura == _idFactura).ToList();
                foreach (var l in l401)
                {
                    l.NUMFACTURA = Header400.NumeroDoc;
                }
                db.SaveChanges();
                //Check T0300 - NCD
                if (Header400.IdNCD != null)
                {
                    var t3 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == Header400.IdNCD.Value);
                    if (t3 != null)
                    {
                        t3.NDOC = Header400.NumeroDoc;
                        t3.TEMP = false;
                        db.SaveChanges();
                    }
                }
                //Check T0055
                if (Header400.IDRemito != null)
                {
                    var t55 = db.T0055_REMITO_H.SingleOrDefault(c => c.IDREMITO == Header400.IDRemito);
                    if (t55 != null)
                    {
                        t55.NUMFACTURA = Header400.NumeroDoc;
                        db.SaveChanges();
                    }
                }

                //Check T201
                string oldNumber = "9999-99999999";
                int idCtacte = 0;
                if (Header400.IdCtaCte != null)
                {
                    idCtacte = Header400.IdCtaCte.Value;
                    var c201 = db.T0201_CTACTE.SingleOrDefault(c => c.IDCTACTE == idCtacte);
                    if (c201 != null)
                    {
                        oldNumber = c201.NUMDOC;
                        c201.NUMDOC = Header400.NumeroDoc;
                        c201.CK = "K";
                    }

                    var c202 = db.T0202_CTACTESALDOS.SingleOrDefault(c =>
                        c.IDCLIENTE == c201.IDCLI && c.NUFACTN == oldNumber);
                    if (c202 != null)
                    {
                        c202.NUFACTN = Header400.NumeroDoc;
                    }
                    db.SaveChanges();
                }

                //check T0207
                var c207 = db.T0207_SPLITFACTURAS.Where(c => c.IDCTACTE == idCtacte).ToList();
                foreach (var ix in c207)
                {
                    //ix.NDOC = Header400.TIPO_DOC+"#"+Header400.NumeroDoc;
                    ix.NDOC = Header400.NumeroDoc;
                }
                db.SaveChanges();

                //chek T0208
                var c208 = db.T0208_COB_NO_APLICADA.Where(c => c.IDCTACTE == idCtacte).ToList();
                foreach (var ix in c208)
                {
                    ix.NRECIBO = Header400.NumeroDoc;
                }
                db.SaveChanges();

                //Asiento
                if (Header400.NAS != null)
                {
                    var h600 = db.T0601_DOCU_H.SingleOrDefault(c => c.IDDOCU == Header400.NAS);
                    if (h600 != null)
                    {
                        h600.REFE = Header400.NumeroDoc;
                        var h602 = db.T0602_DOCU_S.Where(c => c.IDDOCU == Header400.NAS).ToList();
                        foreach (var ix in h602)
                        {
                            ix.REFE = Header400.NumeroDoc;
                        }
                    }
                    db.SaveChanges();
                }
                return Status;
            }
        }
    }
}
