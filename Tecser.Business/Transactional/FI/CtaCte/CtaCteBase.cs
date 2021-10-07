using System;
using System.Drawing;

namespace Tecser.Business.Transactional.FI.CtaCte
{
    /// <summary>
    /// 2018.03.27 >> Gestion de all relacionado con cuenta corriente Cliente y Proveedor
    /// Gestion de Saldos, Gestion de Tablas 201,202,203,204,207,208
    /// </summary>
    public abstract class CtaCteBase
    {
        protected CtaCteBase(int idCliVendor)
        {
            IdEntidad = idCliVendor;
            ColorOk = Color.Chartreuse;
            ColorError = Color.OrangeRed;
        }
        protected CtaCteBase(int idCliVendor, string tipoLx)
        {
            TipoLx = tipoLx;
            IdEntidad = idCliVendor;
            ColorOk = Color.Chartreuse;
            ColorError = Color.OrangeRed;
        }
        internal int IdEntidad { get; private set; } //idCliente o IdProveedor
        private string TipoLx { get; set; }

        internal Color ColorOk;
        internal Color ColorError;

        public struct Resultado
        {
            public string TipoLx;
            public bool SaldoOK;
            public Color SaldoColor;
            public Decimal SaldoDetalle; //203 - 201
            public Decimal SaldoResumen; //204 - 202
            public Decimal SaldoSinImputar; //208
        }
        public virtual Resultado GetResultadoCtaCte(string tipoLx)
        {
            var x = new Resultado()
            {
                TipoLx = tipoLx,
                SaldoColor = ColorError,
                SaldoDetalle = -99999999999,
                SaldoResumen = -99999999999,
                SaldoOK = false,
            };
            return x;
        }

        /// <summary>
        /// Actualiza el importe de SaldoFactura
        /// </summary>
        public abstract bool UpdateImporteSaldoFactura(int idCtaCte, decimal nuevoSaldoFactura);
        public abstract int AddCtaCteDetalleRecord(string tipoDocumento, string lx, DateTime fechaDoc,
            string numeroDocumento, string docInterno, string moneda, decimal importeOrigen, decimal exchangeRate,
            decimal saldoDocumento, decimal importeARS = 0, int idDocAlternativo = 0, int idDocumentoPrincipal = 0);

        public abstract void AddNewCtaCteSummaryRecord(string tipoLx);

        /// <summary>
        /// Actualiza el resuemen CtaCte sumando o restando (signo) el valor indicado.-
        /// </summary>
        public abstract bool UpdateSaldoCtaCteResumen(string tipoLx, decimal importeConSigno, string moneda = "ARS",
            decimal? exchangeRate = null, DateTime? fechaUltimaFacturacionEmitida=null);
    }
}


