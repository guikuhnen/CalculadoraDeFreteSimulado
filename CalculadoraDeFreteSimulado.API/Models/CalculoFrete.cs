using System;

namespace CalculadoraDeFreteSimulado.API.Models
{
    public class CalculoFrete : ModelBase
    {
        public Embarcadora Embarcadora { get; set; }

        public Transportadora Transportadora { get; set; }

        public Embarque Embarque { get; set; }

        public NegociacaoFrete MelhorNegociacaoFrete { get; set; }
        
        public double ValorCalculado { get; set; }

        public DateTime DataPrevisaoEntrega { get; set; }

        public CalculoFrete() : base (0)
        {
        }

        public CalculoFrete(long codigo, Embarcadora embarcadora, Transportadora transportadora, Embarque embarque, 
            NegociacaoFrete melhorNegociacaoFrete, double valorCalculado, DateTime dataPrevisaoEntrega) : base(codigo)
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
