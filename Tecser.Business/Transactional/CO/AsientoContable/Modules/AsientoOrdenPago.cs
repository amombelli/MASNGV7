using System;
using System.Collections.Generic;
using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.MasterData;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.AsientoContable.Modules
{
    public class AsientoOrdenPago : AsientoVendorSpecific
    {
        public AsientoOrdenPago(int idOP, string tcode) : base(tcode)
        {
            _idOP = idOP;
            LoadHeaderData();
            TipoDocumento = "OP";
            NumeroDocumento = idOP.ToString();
        }

        //---------------------------------------------------------------------------------------
        private readonly int _idOP;
        private T0210_OP_H _h;
        private List<T0212_OP_ITEM> _items = new List<T0212_OP_ITEM>();
        //---------------------------------------------------------------------------------------
        protected sealed override void LoadHeaderData()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                _h = db.T0210_OP_H.SingleOrDefault(c => c.IDOP == _idOP);
                if (_h == null)
                    throw new InvalidOperationException("No Existe el registro en T0210*ORDENPAGO");

                base.IdVendor = _h.PROV_ID;
                base.RazonSocial = new VendorManager().GetSpecificVendor(IdVendor).prov_rsocial;

                _items = db.T0212_OP_ITEM.Where(c => c.IDOP == _idOP).ToList();
            }
        }


        //funcion modificada 14072019 
        //OPCRED no forma parte del asiento contable porque es solo una imputacion
        //Nuevo Update 24062021 -- Cheques Emitidos propios van a pendientes de acreditacion
        private void AddSegmentoItemsPago()
        {
            var cuentaMng = new CuentasManager();
            foreach (var i in _items)
            {
                var glAccountItemPago = cuentaMng.GetGL(i.CUENTA_O);
                var descripcion1 = "Pago de Caja - " + i.CUENTA_O;
                string descripcion2 = null;

                switch (i.CUENTA_O)
                {
                    case "CHE":
                        //tratamiento especial para cheques
                        descripcion2 = "CHID@" + i.CH_ID;
                        break;

                    case "OPCRED":
                        //En OPCRED el Numero OP# credito viene en CH_NUM
                        //glAccountItemPago = new GLAccountManagement().GetApVendorGl(IdVendor); //GL AP
                        //descripcion2 = "Pago Credito Pend. Segun " + i.CH_NUM;
                        break;
                    default:
                        //tratamiento resto de items
                        descripcion2 = null;
                        break;
                }
                if (i.IMPORTE_OP == null)
                    i.IMPORTE_OP = 0;

                if (i.CUENTA_O != "OPCRED")
                {
                    //Si el ITEM es OPCRED no lo agrega al asiento
                    if (i.CH_ID == -5)
                    {
                        //El Item es un cheque propio emitido - va a cuenta Pendientes de Acreditar
                        descripcion2 = "Cheque Emitido - Pendiente";
                        glAccountItemPago = "1.0.0.50";
                        AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glAccountItemPago, descripcion1, descripcion2, _h.MON_OP, DebeHaber.Haber, (decimal)i.IMPORTE_OP, Tcode, 0, IdVendor, "T0212_OP_ITEM", i.IDITEM);
                    }
                    else
                    {
                        AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glAccountItemPago, descripcion1, descripcion2, _h.MON_OP, DebeHaber.Haber, (decimal)i.IMPORTE_OP, Tcode, 0, IdVendor, "T0212_OP_ITEM", i.IDITEM);
                    }
                }
            }
        }



        public IdentificacionAsiento GeneraAsientoFromOrdenPago()
        {
            var descripcionHeader = "OP - " + RazonSocial;

            CreaHeaderMemoria(_h.TIPO, _h.OPFECHA, TipoDocumento, _idOP.ToString(), descripcionHeader, _h.MON_OP,
                _h.IMP_OP.Value, _h.TC.Value);

            AddSegmentoItemsPago();

            if (_h.ImporteRetGS > 0)
            {
                AddSegmentoRetencionesAProveedores(GLAccountManagement.GLAccount.RetencionGS, _h.ImporteRetIIBB.Value, idTablaReferencia: _idOP);
            }

            if (_h.ImporteRetIVA > 0)
            {
                AddSegmentoRetencionesAProveedores(GLAccountManagement.GLAccount.RetencionIVA, _h.ImporteRetIIBB.Value, idTablaReferencia: _idOP);
            }

            if (_h.ImporteRetIIBB > 0)
            {
                AddSegmentoRetencionesAProveedores(GLAccountManagement.GLAccount.RetencionIIBB, _h.ImporteRetIIBB.Value, idTablaReferencia: _idOP);
            }

            GeneraSegmentoAP(TipoDocumento, NumeroDocumento, _h.TIPO, DebeHaber.Debe, _h.MON_OP, (decimal)_h.IMP_OP, "T0210_OP_H", _idOP);

            return GrabaAsiento();
        }


        ///Acreditacion de Cheques Emitidos
        public IdentificacionAsiento AsientoAcreditacionCheque(string cuentaBanco, decimal importe, DateTime fechaAcred, int idRegistro)
        {
            var glAccountItemPago = new CuentasManager().GetGL(cuentaBanco);
            var glPendienteAcred = "1.0.0.50";
            var descripcion2 = "";

            //prepara header
            var descripcionHeader = "Acreditacion de Cheque Pendiente: " + RazonSocial;
            CreaHeaderMemoria(_h.TIPO, fechaAcred, TipoDocumento, _idOP.ToString(), descripcionHeader, _h.MON_OP,
                importe, _h.TC.Value);
            //Debe de Pendiente
            AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glPendienteAcred, "Acreditacion Cheque Pendiente", descripcion2, _h.MON_OP, DebeHaber.Debe, importe, "ACH", 0, IdVendor, "T0159_CHEQUES_EMITIDOS", idRegistro);
            //Haber de Cuenta Banco
            AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glAccountItemPago, "Acreditacion Cheque Pendiente", descripcion2, _h.MON_OP, DebeHaber.Haber, importe, "ACH", 0, IdVendor, "T0159_CHEQUES_EMITIDOS", idRegistro);
            return GrabaAsiento();
        }

        public IdentificacionAsiento AsientoDesAcreditacionCheque(string cuentaBanco, decimal importe, DateTime fechaAcred, int idRegistro)
        {
            var glAccountItemPago = new CuentasManager().GetGL(cuentaBanco);
            var glPendienteAcred = "1.0.0.50";
            var descripcion2 = "";

            //prepara header
            var descripcionHeader = "Error - Acreditacion de Cheque Pendiente: " + RazonSocial;
            CreaHeaderMemoria(_h.TIPO, fechaAcred, TipoDocumento, _idOP.ToString(), descripcionHeader, _h.MON_OP,
                importe, _h.TC.Value);
            //Debe de Pendiente
            AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glPendienteAcred, "Reversal Cheque Pendiente", descripcion2, _h.MON_OP, DebeHaber.Haber, importe, "ACH", 0, IdVendor, "T0159_CHEQUES_EMITIDOS", idRegistro);
            //Haber de Cuenta Banco
            AddGenericCompleteSegment(TipoDocumento, NumeroDocumento, _h.TIPO, glAccountItemPago, "Reversal Cheque Pendiente", descripcion2, _h.MON_OP, DebeHaber.Debe, importe, "ACH", 0, IdVendor, "T0159_CHEQUES_EMITIDOS", idRegistro);
            return GrabaAsiento();
        }
    }
}

