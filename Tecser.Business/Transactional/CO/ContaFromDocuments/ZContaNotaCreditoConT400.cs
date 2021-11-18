using System.Linq;
using Tecser.Business.MainApp;
using Tecser.Business.Transactional.CO.AsientoContable;
using Tecser.Business.Transactional.FI;
using Tecser.Business.Transactional.FI.Cobranza;
using TecserEF.Entity;

namespace Tecser.Business.Transactional.CO.ContaFromDocuments
{
    /// <summary>
    /// Fecha Revision 2021.05.14
    /// Revision de Contabilizacion de Nota de Credito
    /// Siempre existe un registro en T300 + Registro en T400
    /// Se contabilizara desde T400 siempre! y luego se actualizaran los datos
    /// Luego haremos una clase nueva para hacerlo desde T300 si no tiene T400 (Ajustes/DocumentosX)
    /// </summary>
    ///
    ///
    ///
    ///
    ///
    /// Renombrar
    public class ZContaNotaCreditoConT400 : XContabilizaDocumentosBase
    {
        private T0300_NCD_H H300 = new T0300_NCD_H();
        private int _idNcd; //idNCD;

        //Nuevo constructor
        public ZContaNotaCreditoConT400(int idfactur400, int signo) : base(idfactur400)
        {
            base.Signo = signo;
            LoadExistingDocument();
        }

        /// <summary>
        /// Carga Info Submodulo T300
        /// </summary>
        private void LoadExistingDocument()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                if (base.H.IdNCD != null)
                {
                    //Carga el header de Submodulo 300
                    H300 = db.T0300_NCD_H.SingleOrDefault(c => c.IDH == H.IdNCD.Value);
                    _idNcd = H.IdNCD.Value;
                }
                else
                {
                    //no tiene submodulo 300. 
                    //Es obligatorio para ND?
                }
            }
        }


        public override ReturnContaCustomerDocument ContabilizacionCompleta()
        {
            base.AddRecordCtaCteDetalle201();
            base.UpdateSaldoCtaCte202();
            new GestionT300(_idNcd).UpdateDatosAfterConta(); //Actualiza Importes y NAS#

            var asiento = new AsCustomerDocument(VariablesProgreso.IdFactura, "NCD");

            var asientoResultado = asiento.AsientoFromCustomerNotaCreditoFromT400();
            VariablesProgreso.NumeroAsientoIdDocu = asientoResultado.IdDocu;
            VariablesProgreso.NumeroAsientoX1X2 = asientoResultado.NasX1;
            UpdateT0400AfterContabilizacion();

            new CobranzaNoImputada().AddSinImputarRecord(VariablesProgreso.IdCtaCte);
            return VariablesProgreso;
        }


        public T0300_NCD_H GetDocumentoHeader()
        {
            using (var db = new TecserData(GlobalApp.CnnApp))
            {
                return db.T0300_NCD_H.SingleOrDefault(c => c.IDH == _idNcd);
            }
        }


    }
}
