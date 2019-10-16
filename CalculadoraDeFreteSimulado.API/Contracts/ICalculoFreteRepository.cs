using System.Threading.Tasks;
using CalculadoraDeFreteSimulado.API.Models;

namespace CalculadoraDeFreteSimulado.API.Contracts
{
    public interface ICalculoFreteRepository
    {
        Task<CalculoFrete> ObterCalculoFretePorEmbarque(long codigoEmbarque);
        Task Create(CalculoFrete calculoFrete);
    }
}
