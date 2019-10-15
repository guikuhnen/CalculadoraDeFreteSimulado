using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CalculadoraDeFreteSimulado.API.Context;
using CalculadoraDeFreteSimulado.API.Models;

namespace CalculadoraDeFreteSimulado.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculoFreteController : ControllerBase
    {
        private readonly CalculoFreteContext _calculoFreteContext;
        private readonly EmbarqueContext _embarqueContext;
        private readonly NegociacaoFreteContext _negociacaoFreteContext;

        public CalculoFreteController(CalculoFreteContext calculoFreteContext, EmbarqueContext embarqueContext, 
            NegociacaoFreteContext negociacaoFreteContext)
        {
            _calculoFreteContext = calculoFreteContext;
            _embarqueContext = embarqueContext;
            _negociacaoFreteContext = negociacaoFreteContext;
        }

        // GET: api/CalculoFrete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalculoFrete>>> GetCalculosFretes()
        {
            return await _calculoFreteContext.CalculosFretes.ToListAsync();
        }

        // GET: api/CalculoFrete/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalculoFrete>> GetCalculoFrete(long id)
        {
            var calculoFrete = await _calculoFreteContext.CalculosFretes.FindAsync(id);

            if (calculoFrete == null)
            {
                return NotFound();
            }

            return calculoFrete;
        }

        // PUT: api/CalculoFrete/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculoFrete(long id, CalculoFrete calculoFrete)
        {
            if (id != calculoFrete.Id)
            {
                return BadRequest();
            }

            _calculoFreteContext.Entry(calculoFrete).State = EntityState.Modified;

            try
            {
                await _calculoFreteContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalculoFreteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CalculoFrete
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<CalculoFrete>> PostCalculoFrete(CalculoFrete calculoFrete)
        {
            _calculoFreteContext.CalculosFretes.Add(calculoFrete);
            await _calculoFreteContext.SaveChangesAsync();

            return CreatedAtAction("GetCalculoFrete", new { id = calculoFrete.Id }, calculoFrete);
        }

        // DELETE: api/CalculoFrete/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CalculoFrete>> DeleteCalculoFrete(long id)
        {
            var calculoFrete = await _calculoFreteContext.CalculosFretes.FindAsync(id);
            if (calculoFrete == null)
            {
                return NotFound();
            }

            _calculoFreteContext.CalculosFretes.Remove(calculoFrete);
            await _calculoFreteContext.SaveChangesAsync();

            return calculoFrete;
        }

        private bool CalculoFreteExists(long id)
        {
            return _calculoFreteContext.CalculosFretes.Any(e => e.Id == id);
        }
    }
}
