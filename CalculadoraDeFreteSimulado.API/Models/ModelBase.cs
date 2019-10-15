namespace CalculadoraDeFreteSimulado.API.Models
{
    public class ModelBase
    {
        public long Id { get; set; }

        public long Codigo { get; set; }

        public ModelBase(long codigo)
        {
            Codigo = codigo;
        }
    }
}