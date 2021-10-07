namespace TecserEF.Entity.DataStructure
{

    //Utilizado para datagridview 
    public class StockLoteEstadoUbicacion
    {
        public string Material { get; set; }
        public string Estado { get; set; }
        public string Lote { get; set; }
        public string SLOC { get; set; }
        public string Planta { get; set; }
        public bool SLocDispoProd { get; set; }
        public bool EstadoDispoProd { get; set; }
        public decimal TotalKg { get; set; }


        public StockLoteEstadoUbicacion()
        {

        }

        public StockLoteEstadoUbicacion(string primario, string numeroLote, string sLoc, string estado, decimal kg, string planta, bool slocDispoProd, bool estadoDispoProd)
        {
            Material = primario;
            Estado = estado;
            TotalKg = kg;
            Planta = planta;
            SLOC = sLoc;
            Lote = numeroLote;
            SLocDispoProd = slocDispoProd;
            EstadoDispoProd = estadoDispoProd;
        }

    }
}
