using System.Threading.Tasks;
using CalculadoraDeFreteSimulado.API.Context;
using CalculadoraDeFreteSimulado.API.Contracts;
using CalculadoraDeFreteSimulado.API.Models;

namespace CalculadoraDeFreteSimulado.API.Repositories
{
    public class CalculoFreteRepository : RepositoryBase<CalculoFrete>, ICalculoFreteRepository
    {
        private readonly EmbarqueContext _embarqueContext;
        private readonly NegociacaoFreteContext _negociacaoFreteContext;

        public CalculoFreteRepository(CalculoFreteContext calculoFreteContext, EmbarqueContext embarqueContext,
            NegociacaoFreteContext negociacaoFreteContext)
            : base(calculoFreteContext)
        {
            _embarqueContext = embarqueContext;
            _negociacaoFreteContext = negociacaoFreteContext;
        }

        public Task<CalculoFrete> ObterMelhorNegociacao(long codigo)
        {
            throw new System.NotImplementedException();
        }
    }
}