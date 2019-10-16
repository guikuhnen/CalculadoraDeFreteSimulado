using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraDeFreteSimulado.API.Models
{
    [Table("CalculoFrete")]
    public class CalculoFrete
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Para calcular a melhor negociacao e necessario que uma Embarcadora esteja vinculada.")]
        public Embarcadora Embarcadora { get; set; }

        [Required(ErrorMessage = "Para calcular a melhor negociacao e necessario que uma Transportadora esteja vinculada.")]
        public Transportadora Transportadora { get; set; }

        [Required(ErrorMessage = "Para calcular a melhor negociacao e necessario que um Embarque esteja vinculado.")]
        public Embarque Embarque { get; set; }

        [Required(ErrorMessage = "Para calcular a melhor negociacao e necessario que uma Negociacao esteja vinculada.")]
        public NegociacaoFrete MelhorNegociacaoFrete { get; set; }

        [Required(ErrorMessage = "O valor calculado e obrigatorio.")]
        public double ValorCalculado { get; set; }

        [Required(ErrorMessage = "A data prevista de entrega e obrigatoria.")]
        public DateTime DataPrevisaoEntrega { get; set; }

        public CalculoFrete()
        {
        }

        public CalculoFrete(Embarcadora embarcadora, Transportadora transportadora, Embarque embarque, NegociacaoFrete melhorNegociacaoFrete, 
            double valorCalculado, DateTime dataPrevisaoEntrega)
        {
            this.Embarcadora = embarcadora;
            this.Transportadora = transportadora;
            this.Embarque = embarque;
            this.MelhorNegociacaoFrete = melhorNegociacaoFrete;
            this.ValorCalculado = valorCalculado;
            this.DataPrevisaoEntrega = dataPrevisaoEntrega;
        }
    }
}
