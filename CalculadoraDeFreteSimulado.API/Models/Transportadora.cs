using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraDeFreteSimulado.API.Models
{
    [Table("Transportadora")]
    public class Transportadora : ModelBase
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
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
