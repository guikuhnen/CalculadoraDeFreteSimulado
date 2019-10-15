using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraDeFreteSimulado.API.Models
{
    [Table("NegociacaoFrete")]
    public class NegociacaoFrete : ModelBase
    {
        [Required(ErrorMessage = "Para uma negociacao de frete e necessario que uma Embarcadora esteja vinculada.")]
        public Embarcadora Embarcadora { get; set; }

        [Required(ErrorMessage = "Para uma negociacao de frete e necessario que uma Transportadora esteja vinculada.")]
        public Transportadora Transportadora { get; set; }

        [Required(ErrorMessage = "A faixa de peso inicial e obrigatoria.")]
        public double FaixaPesoInicio { get; set; }

        [Required(ErrorMessage = "A faixa de peso final e obrigatoria.")]
        public double FaixaPesoFim { get; set; }

        [Required(ErrorMessage = "O preco por quilometro e obrigatorio.")]
        public double PrecoQuilometro { get; set; }

        [Required(ErrorMessage = "A categoria do veiculo e obrigatoria.")]
        public CategoriaVeiculoEnum CategoriaVeiculo { get; set; }

        [Required(ErrorMessage = "O prazo de entrega em dias e obrigatorio.")]
        public double PrazoEntregaDias { get; set; }

        public NegociacaoFrete() : base (0)
        {
        }

        public NegociacaoFrete(long codigo, Embarcadora embarcadora, Transportadora transportadora, double faixaPesoInicio, double faixaPesoFim, 
            double precoQuilometro, CategoriaVeiculoEnum categoriaVeiculo, double prazoEntregaDias) : base (codigo)
        {
            this.Embarcadora = embarcadora;
            this.Transportadora = transportadora;
            this.FaixaPesoInicio = faixaPesoInicio;
            this.FaixaPesoFim = faixaPesoFim;
            this.PrecoQuilometro = precoQuilometro;
            this.CategoriaVeiculo = categoriaVeiculo;
            this.PrazoEntregaDias = prazoEntregaDias;
        }
    }
}
