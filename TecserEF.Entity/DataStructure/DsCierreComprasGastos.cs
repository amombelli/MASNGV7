using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TecserEF.Entity.DataStructure
{
    //Estructura creada para generar reporte raffone cierre
    public class DsCierreComprasGastos
    {
        public int  IdFactura { get; set; }
        public int IdCtaCte { get; set; }
        public string Periodo { get; set; }
        public string RazonSocial { get; set; }
        public string Cuit { get; set; }
        public DateTime Fecha { get; set; }
        public string TD { get; set; }
        public string NumeroDoc { get; set; }
        public decimal IBruto { get; set; }
        public decimal IDescuento { get; set; }
        public decimal IBaseImpo { get; set; }
        public decimal IConceptoNoGrav { get; set; }
        public decimal Iiva10 { get; set; }
        public decimal Iiva21 { get; set; }
        public decimal Iiva27 { get; set; }
        public decimal IivaTotal { get; set; }
        public decimal IpercIIBB { get; set; }
        public decimal ApercIIBB { get; set; }
        public decimal IpercGs { get; set; }
        public decimal ApercGs { get; set; }
        public decimal IpercIva { get; set; }
        public decimal ApercIva { get; set; }
        public decimal IimpInternos { get; set; }
        public decimal IimpMunicipal { get; set; }
        public decimal IimpProvincial { get; set; }
        public decimal IimpOtros { get; set; }
        public decimal IimpuestoNoDeducTotal { get; set; } //Internos+Municipal+Provincial+Otros
        public decimal Iredondeo { get; set; }
        public decimal InetoFinal { get; set; }
        public decimal TotalKg { get; set; }
        public DateTime LogFecha { get; set; }
        public string LogUser { get; set; }
        public string TCode { get; set; }
        public string StatusDocumento { get; set; }
        public string Lx { get; set; }
        public decimal SaldoPendienteHoy { get; set; }
        public string TipoProveedor { get; set; }
        public string GLap { get; set; }
        public bool IsGasto { get; set; }

    }
}
