using System;

namespace CalculadoraDeFreteSimulado.API.Models
{
    public class Embarque : ModelBase
    {
        public Embarcadora Embarcadora { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public double Quilometragem { get; set; }

        public CategoriaVeiculoEnum CategoriaVeiculo { get; set; }

        public double Peso { get; set; }

        public DateTime DataColeta { get; set; }

        public Embarque() : base (0)
        {
        }

        public Embarque(long codigo, Embarcadora embarcadora, string origem, string destino, double quilometragem, CategoriaVeiculoEnum categoria, 
            double peso, DateTime dataColeta) : base (codigo)
        {
            this.Embarcadora = embarcadora;
            this.Origem = origem;
            this.Destino = destino;
            this.Quilometragem = quilometragem;
            this.CategoriaVeiculo = categoria;
            this.Peso = peso;
            this.DataColeta = dataColeta;
        }
    }
}
