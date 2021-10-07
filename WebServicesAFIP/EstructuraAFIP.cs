using System;
using System.Collections.Generic;

namespace WebServicesAFIP
{
    public class FEGetDataStructure
    {
        public string DocTipo { get; set; } //80 cuit
        public string DocNumero { get; set; } // numero Cuit
        public string ComprobanteDesde { get; set; }
        public string ComprobanteHasta { get; set; }
        public DateTime FechaComprobante { get; set; }
        public decimal ImporteTotal { get; set; }
        public decimal ImporteNeto { get; set; }
        public decimal ImporteTributos { get; set; }
        public decimal ImporteIva { get; set; }
        public string Moneda { get; set; }
        public decimal Cotizacion { get; set; }
        public List<TributosAfip> TributosDetalle = new List<TributosAfip>();
        public List<TributosAfip> IvaDetalle = new List<TributosAfip>();
        public string Resultado { get; set; }
        public string CAE { get; set; }
        public DateTime VencimientoCAE { get; set; }
        public DateTime FechaProceso { get; set; }
        public string PuntoVenta { get; set; }
        public TipoComprobante TipoComprobante { get; set; }
        public bool Reprocesar { get; set; }
        public bool Reproceso { get; set; }
        public string EmisionTipo { get; set; }
        public string XmlResponse { get; set; }
        public string XmlRequest { get; set; }
        public string Wsfev1Error { get; set; }
        public string Wsfev1Observacion { get; set; }
        public string NumeroDocumentoOtorgadoCompleto { get; set; }
    }
    public class FESetDataStructure
    {
        private readonly int _idFactura;
        public bool AllowCaeRequest = false;
        //
        public TipoComprobante TipoComprobante { get; set; }
        public int PuntoVenta { get; set; }
        public DateTime FechaComprobante { get; set; }
        public int Concepto { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public long UltimoComprobanteAutorizadoAfip { get; set; }
        public string ImporteNoGravado { get; set; } //"100.00"   # importe total conceptos no gravado
        public string BaseImponible { get; set; } //"100.00"
        public string ImporteTotal { get; set; } //"122.00"
        public string ImporteNeto { get; set; } //"100.00"
        public string ImporteIVA { get; set; } //"21.00"
        public string ImporteTributos { get; set; } //"1.00"
        public string MonedaId { get; set; } //PES
        public string Cotizacion { get; set; } //"1.000"
        public List<TributosAfip> TributosDetalle = new List<TributosAfip>();
        public List<TributosAfip> IvaDetalle = new List<TributosAfip>();
        public TipoComprobante CompAsociadoTipo { get; set; }
        public string CompAsociadoPtoVta { get; set; }
        public string CompAsociadoNumero { get; set; }
        public string CompAsociadoFechaPeriodoDesde { get; set; }
        public string CompAsociadoFechaPeriodoHasta { get; set; }
       
    }

    /// <summary>
    /// Estructura para definir los tributos AFIP que son utilizado para solicitar CAE
    /// Aca documentar los IDTributos y su descripcion
    /// </summary>

    public class TributosAfip
    {
        public string IdTributo { get; set; }
        public string Descripcion { get; set; }
        public string BaseImponible { get; set; }
        public string Alicuota { get; set; }
        public string Importe { get; set; }
    }
    public class UltimosComprobantes
    {
        public string UltimaFactura { get; set; }
        public string UltimaNotaCredito { get; set; }
        public string UltimaNotaDebito { get; set; }
    }
}