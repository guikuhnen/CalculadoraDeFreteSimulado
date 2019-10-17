using CalculadoraDeFreteSimulado.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculadoraDeFreteSimulado.API.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            #region NegociacaoFreteContext

            using (var negociacaoFreteContext = new NegociacaoFreteContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NegociacaoFreteContext>>()))
            {
                // Procura por algum dado
                if (negociacaoFreteContext.NegociacoesFretes.Any())
                    return;   // DB ja foi inicializado

                negociacaoFreteContext.Embarcadoras.AddRange(
                    new Embarcadora(1, "Embarcadora A"),
                    new Embarcadora(2, "Embarcadora B"),
                    new Embarcadora(3, "Embarcadora C")
                );

                negociacaoFreteContext.Transportadoras.AddRange(
                    new Transportadora(1, "Transportadora A"),
                    new Transportadora(2, "Transportadora B"),
                    new Transportadora(3, "Transportadora C")
                );

                // Insere os dados iniciais para fazer a referencia
                negociacaoFreteContext.SaveChanges();

                List<Embarcadora> embarcadoras = new List<Embarcadora>();
                for (int i = 1; i < 4; i++)
                    embarcadoras.Add(negociacaoFreteContext.Embarcadoras.Where(e => e.Codigo.Equals(i)).FirstOrDefault());

                List<Transportadora> transportadoras = new List<Transportadora>();
                for (int i = 1; i < 4; i++)
                    transportadoras.Add(negociacaoFreteContext.Transportadoras.Where(e => e.Codigo.Equals(i)).FirstOrDefault());

                negociacaoFreteContext.NegociacoesFretes.AddRange(
                    new NegociacaoFrete(1, embarcadoras[0], transportadoras[0], 8, 11, 10, CategoriaVeiculoEnum.Carreta, 10),
                    new NegociacaoFrete(2, embarcadoras[1], transportadoras[1], 13, 15, 20, CategoriaVeiculoEnum.Toco, 18),
                    new NegociacaoFrete(3, embarcadoras[2], transportadoras[2], 20, 40, 55, CategoriaVeiculoEnum.Van, 22),
                    new NegociacaoFrete(4, embarcadoras[0], transportadoras[1], 13, 15, 20, CategoriaVeiculoEnum.Toco, 18),
                    new NegociacaoFrete(5, embarcadoras[0], transportadoras[2], 8, 11, 10.5, CategoriaVeiculoEnum.Carreta, 9)
                );

                negociacaoFreteContext.SaveChanges();
            }

            #endregion
            
            #region EmbarqueContext

            using (var embarqueContext = new EmbarqueContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EmbarqueContext>>()))
            {
                // Procura por algum dado
                if (embarqueContext.Embarques.Any())
                    return;   // DB ja foi inicializado

                embarqueContext.Embarcadoras.AddRange(
                    new Embarcadora(1, "Embarcadora A"),
                    new Embarcadora(2, "Embarcadora B"),
                    new Embarcadora(3, "Embarcadora C")
                );

                // Insere os dados iniciais para fazer a referencia
                embarqueContext.SaveChanges();

                List<Embarcadora> embarcadoras = new List<Embarcadora>();
                for (int i = 1; i < 4; i++)
                    embarcadoras.Add(embarqueContext.Embarcadoras.Where(e => e.Codigo.Equals(i)).FirstOrDefault());

                embarqueContext.Embarques.AddRange(
                    new Embarque(1, embarcadoras[0], "Endereco A", "Endereco B", 8, CategoriaVeiculoEnum.Carreta, 10,
                        new DateTime(2019, 10, 21, 08, 00, 00)),
                    new Embarque(2, embarcadoras[1], "Endereco C", "Endereco D", 12.2, CategoriaVeiculoEnum.Truck, 15.5,
                        new DateTime(2019, 10, 25, 08, 00, 00)),
                    new Embarque(3, embarcadoras[2], "Endereco E", "Endereco F", 23.07, CategoriaVeiculoEnum.Van, 38,
                        new DateTime(2019, 10, 30, 08, 00, 00)),
                    new Embarque(4, embarcadoras[0], "Endereco G", "Endereco H", 8, CategoriaVeiculoEnum.Toco, 13,
                        new DateTime(2019, 10, 21, 08, 00, 00))
                );

                embarqueContext.SaveChanges();
            }

            #endregion
        }
    }
}
