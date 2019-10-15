namespace CalculadoraDeFreteSimulado.API.Models
{
    public class Embarcadora : ModelBase
    {
        public string Nome { get; set; }

        public Embarcadora () : base(0)
        {
        }

        public Embarcadora(long codigo, string nome) : base (codigo)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}
