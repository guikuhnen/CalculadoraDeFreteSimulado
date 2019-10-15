using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraDeFreteSimulado.API.Models
{
    [Table("Embarcadora")]
    public class Embarcadora : ModelBase
    {
        [Required(ErrorMessage = "O nome e obrigatorio.")]
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
