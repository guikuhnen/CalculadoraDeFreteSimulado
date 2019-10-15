using System.ComponentModel.DataAnnotations;

namespace CalculadoraDeFreteSimulado.API.Models
{
    public abstract class ModelBase
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "O codigo e obrigatorio.")]
        public long Codigo { get; set; }

        public ModelBase(long codigo)
        {
            Codigo = codigo;
        }
    }
}