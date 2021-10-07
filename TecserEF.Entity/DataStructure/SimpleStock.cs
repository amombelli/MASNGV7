namespace TecserEF.Entity.DataStructure
{
    public class SimpleStock
    {
        public string Primario { get; set; }
        public string Estado { get; set; }
        public decimal TotalKg { get; set; }
        public string Planta { get; set; }

        public SimpleStock()
        {

        }

        public SimpleStock(string primario, string estado, decimal kg, string planta)
        {
            Primario = primario;
            Estado = estado;
            TotalKg = kg;
            Planta = planta;
        }
    }

}
