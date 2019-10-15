using System.Threading.Tasks;
using CalculadoraDeFreteSimulado.API.Models;

namespace CalculadoraDeFreteSimulado.API.Contracts
{
    public interface ICalculoFreteRepository : IRepositoryBase<CalculoFrete>
    {
        Task<CalculoFrete> ObterMelhorNegociacao(long codigo);
    }
}
