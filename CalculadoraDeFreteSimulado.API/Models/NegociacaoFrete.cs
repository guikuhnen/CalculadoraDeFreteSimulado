namespace CalculadoraDeFreteSimulado.API.Models
{
    public class NegociacaoFrete : ModelBase
    {
        public Embarcadora Embarcadora { get; set; }
        
        public Transportadora Transportadora { get; set; }

        public double FaixaPesoInicio { get; set; }

        public double FaixaPesoFim { get; set; }

        public double PrecoQuilometro { get; set; }

        public CategoriaVeiculoEnum CategoriaVeiculo { get; set; }

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
