namespace CalculadoraDeFreteSimulado.API.Models
{
    public class Transportadora : ModelBase
    {
        public string Nome { get; set; }

        public Transportadora() : base (0)
        {
        }

        public Transportadora(long codigo, string nome) : base(codigo)
        {
            this.Nome = nome;
        }
    }
}
