using System.Collections.Generic;

namespace WebServicesAFIP
{
    public struct EstructuraPadronAfipA5
    {
        public string Denominacion { get; set; }
        public string TipoPersona { get; set; }
        public int TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Estado { get; set; }
        public string Direccion { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
        public string CodPostal { get; set; }
        public List<int> Impuestos { get; set; }
        public List<int> Actividad { get; set; }
        public string IVA { get; set; }
        public string Monotributo { get; set; }
        public int ActividadMonotributo { get; set; }
        public string Empleador { get; set; }
    }
}







