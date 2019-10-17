using CalculadoraDeFreteSimulado.API.Context;
using CalculadoraDeFreteSimulado.API.Contracts;
using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDeFreteSimulado.API.Repositories
{
    public class CalculoFreteRepository : ICalculoFreteRepository
    {
        private readonly CalculoFreteContext _calculoFreteContext;
        private readonly EmbarqueContext _embarqueContext;
        private readonly NegociacaoFreteContext _negociacaoFreteContext;

        public CalculoFreteRepository(CalculoFreteContext calculoFreteContext, EmbarqueContext embarqueContext,
            NegociacaoFreteContext negociacaoFreteContext)
        {
            _calculoFreteContext = calculoFreteContext;
            _embarqueContext = embarqueContext;
            _negociacaoFreteContext = negociacaoFreteContext;
        }

        public async Task<CalculoFrete> ObterCalculoFretePorEmbarque(long codigoEmbarque)
        {
            try
            {
                Embarque embarque = new Embarque();
                embarque = await _embarqueContext.Embarques
                    .Where(e => e.Codigo == codigoEmbarque)
                    .Include(e => e.Embarcadora)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                if (embarque == null)
                    throw new Exception("Nao foi possivel localizar o embarque.");

                goTo_BuscarCalculoFreteResultado:
                    CalculoFrete calculoFreteResultado = new CalculoFrete();
                    calculoFreteResultado = await _calculoFreteContext.CalculosFretes
                        .Where(c => c.Embarque.Id.Equals(embarque.Id))
                        .Include(c => c.Embarcadora)
                        .Include(c => c.Transportadora)
                        .Include(c => c.Embarque)
                        .Include(c => c.MelhorNegociacaoFrete)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                if (calculoFreteResultado == null)
                {
                    NegociacaoFrete negociacaoFrete = new NegociacaoFrete();
                    negociacaoFrete = await _negociacaoFreteContext.NegociacoesFretes
                        .Where(n => n.Embarcadora.Codigo == embarque.Embarcadora.Codigo
                            && (n.FaixaPesoEmToneladasInicio <= embarque.PesoEmToneladas && n.FaixaPesoEmToneladasFim >= embarque.PesoEmToneladas)
                            && n.CategoriaVeiculo == embarque.CategoriaVeiculo)
                        .OrderBy(n => n.PrecoQuilometro)
                        .ThenBy(n => n.PrazoEntregaDias)
                        .Include(n => n.Embarcadora)
                        .Include(n => n.Transportadora)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();

                    if (negociacaoFrete == null)
                        throw new Exception("Nao foi possivel localizar uma negociacao de frete.");

                    calculoFreteResultado = new CalculoFrete(negociacaoFrete.Embarcadora, negociacaoFrete.Transportadora, embarque,
                        negociacaoFrete, embarque.Quilometragem * negociacaoFrete.PrecoQuilometro,
                        embarque.DataColeta.AddDays(negociacaoFrete.PrazoEntregaDias));

                    _calculoFreteContext.Entry(calculoFreteResultado.Embarcadora).State = EntityState.Added;
                    _calculoFreteContext.Entry(calculoFreteResultado.Transportadora).State = EntityState.Added;
                    _calculoFreteContext.Entry(calculoFreteResultado.Embarque).State = EntityState.Added;
                    _calculoFreteContext.Entry(calculoFreteResultado.MelhorNegociacaoFrete).State = EntityState.Added;

                    await this.Create(calculoFreteResultado);

                    goto goTo_BuscarCalculoFreteResultado;
                }

                return calculoFreteResultado;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Create(CalculoFrete calculoFrete)
        {
            _calculoFreteContext.CalculosFretes.Add(calculoFrete);
            await _calculoFreteContext.SaveChangesAsync();
        }
    }
}