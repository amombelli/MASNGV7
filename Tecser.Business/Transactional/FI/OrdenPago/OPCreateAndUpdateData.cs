using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using Tecser.Business.TOOLS;
using TecserEF.Entity;
using GlobalApp = Tecser.Business.MainApp.GlobalApp;


namespace Tecser.Business.Transactional.FI.OrdenPago
{
    //Toda la gestion de la generacion del documento OP T0210.T0212.T0213
    //Se toma la decision de ir grabando a Db para ir reservando los cheques
    //a medida que se va armando la OP y permitir dejar una OP con cheques reservados
    //Sin la necesidad de grabar una OP.-2018.04.11
    public class OPCreateAndUpdateData
    {
        public OPCreateAndUpdateData()
        {

        }

        public OPCreateAndUpdateData(int idOP)
        {
            _idOP = idOP;
            LoadExistingData();
        }

        private int _idVendor;
        private string _tipoLx;
        private int _idOP;
        private T0210_OP_H _header;
        private List<T0212_OP_ITEM> _itemsPago = new List<T0212_OP_ITEM>();
        private List<T0213_OP_FACT> _facturasAPagar = new List<T0213_OP_FACT>();

        public int CreaOPHeaderInicial(int vendorId, DateTime fechaOP, string tipoLx, string monedaOP, decimal exchangeRate, string comentarios = null)
        {
            var vendorData = new VendorManager().GetSpecificVendor(vendorId);
            _tipoLx = tipoLx;
            _idVendor = vendorId;

            var vendorHeaderData = new T0210_OP_H()
            {
                //IDOP
                OPFECHA = fechaOP,
                PROV_ID = vendorId,
                PROV_RS = vendorData.prov_rsocial.Truncate(50),
                PROV_TAXID = vendorData.TTAX1,
                PROV_TAXNUM = vendorData.NTAX1,
                PROV_CUIT = vendorData.NTAX1,
                MON_OP = monedaOP,
                OP_TEMP = true,
                OP_STATUS = OrdenPagoStatus.StatusOP.Proceso.ToString(),
                TIPO = tipoLx,
                OP_COM = comentarios,
                LOG_USER = Environment.UserName,
                LOG_DATE = DateTime.Now,
                Periodo = new PeriodoConversion().GetPeriodo(fechaOP),
                TC = exchangeRate,
                //IMP_OP = 
                //ImporteValores
                //ImporteIVA
                //ImporteRetIVA
                //ImporteRetIIBB
                //ImporteCreditos
                //ImporteRetGS
                //SaldoSinImputar
                //NAS = null,
                //BaseCalculoPagoRetGS
            };
            _header = vendorHeaderData;
            _header.IDOP = DefineOpNumber();

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                db.T0210_OP_H.Add(_header);
                _idOP = db.SaveChanges() > 0 ? _header.IDOP : 0;
                return _idOP;
            }
        }
        public bool AddNewItemPago(string cuentaPago, decimal importeMonedaPago, int idChequeOrIdCtaCteCreditoOp)
        {
            var datosCuentaPago = new CuentasManager().GetSpecificCuentaInfo(cuentaPago);
            var tcHeader = _header.TC;
            var importeOP = importeMonedaPago;
            if (_header.MON_OP != datosCuentaPago.CUENTA_MONEDA)
            {
                if (_header.MON_OP == "ARS")
                {
                    //OP>ARS -- ITEM>USD convertir a ARS
                    importeOP = (decimal)((decimal)importeMonedaPago * tcHeader);
                }
                else
                {
                    //OP>USD -- ITEM>ARS convertir a USD
                    importeOP = importeMonedaPago / tcHeader.Value;
                }
            }

            var i = new T0212_OP_ITEM()
            {
                IDOP = _header.IDOP,
                IDITEM = 0,
                PROVEEDOR = _idVendor,
                MON = datosCuentaPago.CUENTA_MONEDA,
                IMPORTE = importeMonedaPago,
                //TC = _header.TC.Value, //No lo puedo usar porque TC esta INT todo pasar a decimal
                MON_OP = _header.MON_OP,
                IMPORTE_OP = importeOP,
                CUENTA_O = cuentaPago,
                CK_FIN = false,
                CK_CANCEL = false,
            };
            if (cuentaPago == "CHE")
            {
                var chequeData = new ChequesManager().GetCheque(idChequeOrIdCtaCteCreditoOp);
                i.ChequeFecha = chequeData.CHE_FECHA;
                i.CH_CK = true;
                i.CH_NUM = chequeData.CHE_NUMERO;
                i.CH_BCO = chequeData.CHE_NUMERO;
                i.CH_ID = idChequeOrIdCtaCteCreditoOp;
            }

            if (cuentaPago == "OPCRED")
            {
                var ctacteDataA =
                    new TecserData(GlobalApp.CnnApp).T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idChequeOrIdCtaCteCreditoOp);
                i.ChequeFecha = null;
                i.CH_CK = false;
                i.CH_NUM = "OP@" + ctacteDataA.NUMDOC;
                i.CH_BCO = null;
                i.CH_ID = idChequeOrIdCtaCteCreditoOp;
            }
            _itemsPago.Add(i);
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                i.IDITEM = db.T0212_OP_ITEM.Max(c => c.IDITEM) + 1;
                db.T0212_OP_ITEM.Add(i);
                return db.SaveChanges() > 0;
            }
        }

        public bool AddNewOpcred(int idCtaCte)
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dataCtaCte = db.T0203_CTACTE_PROV.SingleOrDefault(c => c.IDCTACTE == idCtaCte);
                if (dataCtaCte == null)
                    return false;

                if (dataCtaCte.TDOC != "OP")
                    throw new InvalidDataException("El Tipo esperado era OP");

                return AddNewItemPago("OPCRED", Math.Abs(dataCtaCte.SALDOFACTURA),
                    Convert.ToInt32(dataCtaCte.DOC_INTERNO));
            }
        }
        private void LoadExistingData()
        {
            if (_idOP == 0)
                return;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var dh = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _idOP);
                if (dh == null)
                    throw new InvalidOperationException("No Existe el registro en T0210*OPHEADER");

                _header = dh;
                _idVendor = dh.PROV_ID;
                _tipoLx = dh.TIPO;

                var ip = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP).ToList();
                if (ip.Count > 0)
                    _itemsPago = ip;

                var lf = db.T0213_OP_FACT.Where(c => c.IDOP == _idOP).ToList();
                if (lf.Count > 0)
                    _facturasAPagar = lf;
            }
        }
        private int DefineOpNumber()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (_tipoLx == "L1")
                {
                    var data = db.T000.SingleOrDefault(c => c.ID == "OP1");
                    var numero = Convert.ToInt32(data.VALUE) + 1;
                    data.VALUE = numero.ToString();
                    db.SaveChanges();
                    return numero;
                }
            }

            var prefijoOp = _tipoLx == "L1" ? "1" : "2";
            prefijoOp = prefijoOp + new PeriodoConversion().GetYearYy(Convert.ToDateTime(_header.OPFECHA)) +
                        new PeriodoConversion().GetMesMm(Convert.ToDateTime(_header.OPFECHA));

            int newOpNumber;

            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                var data = db.T0210_OP_H.FirstOrDefault(c => c.Periodo.Equals(_header.Periodo) && c.TIPO.Equals(_tipoLx));
                if (data != null)
                {
                    newOpNumber = db.T0210_OP_H.Where(c => c.Periodo.Equals(_header.Periodo) && c.TIPO.Equals(_tipoLx))
                        .OrderByDescending(c => c.IDOP)
                        .FirstOrDefault()
                        .IDOP + 1;
                }
                else
                {
                    newOpNumber = Convert.ToInt32(prefijoOp + "001");
                }
            }
            return newOpNumber;
        }
    }
}
