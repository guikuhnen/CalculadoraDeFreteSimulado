using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CalculadoraDeFreteSimulado.API.Models
{
    [Table("Embarque")]
    public class Embarque : ModelBase
    {
        [Required(ErrorMessage = "Para um embarque e necessario que uma Embarcadora esteja vinculada.")]
        public Embarcadora Embarcadora { get; set; }

        [Required(ErrorMessage = "A origem e obrigatoria.")]
        public string Origem { get; set; }

        [Required(ErrorMessage = "O destino e obrigatorio.")]
        public string Destino { get; set; }

        [Required(ErrorMessage = "A quilometragem e obrigatoria.")]
        public double Quilometragem { get; set; }

        [Required(ErrorMessage = "A categoria do veiculo e obrigatoria.")]
        public CategoriaVeiculoEnum CategoriaVeiculo { get; set; }

        [Required(ErrorMessage = "O peso em toneladas e obrigatorio.")]
        public double PesoEmToneladas { get; set; }

        [Required(ErrorMessage = "A data da coleta e obrigatoria.")]
        public DateTime DataColeta { get; set; }

        public Embarque() : base (0)
        {
        }

        public Embarque(long codigo, Embarcadora embarcadora, string origem, string destino, double quilometragem, CategoriaVeiculoEnum categoria, 
            double pesoEmToneladas, DateTime dataColeta) : base (codigo)
        {
            this.Embarcadora = embarcadora;
            this.Origem = origem;
            this.Destino = destino;
            this.Quilometragem = quilometragem;
            this.CategoriaVeiculo = categoria;
            this.PesoEmToneladas = pesoEmToneladas;
            this.DataColeta = dataColeta;
        }
    }
}
