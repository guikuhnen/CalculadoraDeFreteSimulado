using CalculadoraDeFreteSimulado.API.Contracts;
using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CalculadoraDeFreteSimulado.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculoFreteController : ControllerBase
    {
        private readonly ICalculoFreteRepository _calculoFreteRepository;

        public CalculoFreteController(ICalculoFreteRepository calculoFreteRepository)
        {
            _calculoFreteRepository = calculoFreteRepository;
        }

        // GET: CalculoFrete/ObterCalculoFretePorEmbarque?codigoEmbarque={long}
        [HttpGet("ObterCalculoFretePorEmbarque")]
        public async Task<ActionResult<CalculoFrete>> ObterCalculoFretePorEmbarque(long codigoEmbarque)
        {
            try
            {
                #region Validacao de parametros

                if (codigoEmbarque.Equals(0))
                    return StatusCode((int)HttpStatusCode.BadRequest, "O parametro 'Codigo' e obrigatorio.");

                #endregion

                var calculoFrete = await _calculoFreteRepository.ObterCalculoFretePorEmbarque(codigoEmbarque);

                if (calculoFrete == null)
                    return StatusCode((int)HttpStatusCode.NotFound, "Erro ao localizar uma negociacao de frete.");

                return calculoFrete;
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, !string.IsNullOrEmpty(e.Message) ? e.Message : "Internal Server Error");
            }
        }
    }
}
