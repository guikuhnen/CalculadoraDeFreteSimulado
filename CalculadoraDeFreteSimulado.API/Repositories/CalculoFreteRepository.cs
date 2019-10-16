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
                embarque = await _embarqueContext.Embarques.Where(x => x.Codigo == codigoEmbarque).FirstOrDefaultAsync();

                if (embarque == null)
                    throw new Exception("Nao foi possivel localizar o embarque.");

                NegociacaoFrete negociacaoFrete = new NegociacaoFrete();
                negociacaoFrete = await _negociacaoFreteContext.NegociacoesFretes
                    .Where(n => n.Embarcadora.Codigo == embarque.Embarcadora.Codigo
                        && (n.FaixaPesoInicio <= embarque.Peso && n.FaixaPesoFim >= embarque.Peso)
                        && n.CategoriaVeiculo == embarque.CategoriaVeiculo)
                    .OrderBy(n => n.PrecoQuilometro)
                    .ThenBy(n => n.PrazoEntregaDias)
                    .FirstOrDefaultAsync();

                if (negociacaoFrete == null)
                    throw new Exception("Nao foi possivel localizar uma negociacao de frete.");
                
                CalculoFrete calculoFreteResultado = new CalculoFrete(negociacaoFrete.Embarcadora, negociacaoFrete.Transportadora, embarque, 
                    negociacaoFrete, embarque.Quilometragem * negociacaoFrete.PrecoQuilometro, 
                    embarque.DataColeta.AddDays(negociacaoFrete.PrazoEntregaDias));                

                await this.Create(calculoFreteResultado);

                return await this._calculoFreteContext.CalculosFretes.FindAsync(calculoFreteResultado.Id);
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