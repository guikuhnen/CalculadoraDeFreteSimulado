using CalculadoraDeFreteSimulado.API.Contracts;
using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.AspNetCore.Mvc;
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
        
        // GET: CalculoFrete/1
        [HttpGet("{codigo}")]
        public async Task<ActionResult<CalculoFrete>> GetCalculoFrete(long codigo)
        {
            var calculoFrete = await _calculoFreteRepository.ObterMelhorNegociacao(codigo);

            if (calculoFrete == null)
            {
                return NotFound();
            }

            return calculoFrete;
        }

    //    // PUT: api/CalculoFrete/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    //    // more details see https://aka.ms/RazorPagesCRUD.
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutCalculoFrete(long id, CalculoFrete calculoFrete)
    //    {
    //        if (id != calculoFrete.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _calculoFreteContext.Entry(calculoFrete).State = EntityState.Modified;

    //        try
    //        {
    //            await _calculoFreteContext.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!CalculoFreteExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/CalculoFrete
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for
    //    // more details see https://aka.ms/RazorPagesCRUD.
    //    [HttpPost]
    //    public async Task<ActionResult<CalculoFrete>> PostCalculoFrete(CalculoFrete calculoFrete)
    //    {
    //        _calculoFreteContext.CalculosFretes.Add(calculoFrete);
    //        await _calculoFreteContext.SaveChangesAsync();

    //        return CreatedAtAction("GetCalculoFrete", new { id = calculoFrete.Id }, calculoFrete);
    //    }

    //    // DELETE: api/CalculoFrete/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<CalculoFrete>> DeleteCalculoFrete(long id)
    //    {
    //        var calculoFrete = await _calculoFreteContext.CalculosFretes.FindAsync(id);
    //        if (calculoFrete == null)
    //        {
    //            return NotFound();
    //        }

    //        _calculoFreteContext.CalculosFretes.Remove(calculoFrete);
    //        await _calculoFreteContext.SaveChangesAsync();

    //        return calculoFrete;
    //    }

    //    private bool CalculoFreteExists(long id)
    //    {
    //        return _calculoFreteContext.CalculosFretes.Any(e => e.Id == id);
    //    }

    }
}
