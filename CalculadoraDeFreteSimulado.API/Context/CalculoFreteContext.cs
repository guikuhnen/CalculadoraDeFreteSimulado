using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraDeFreteSimulado.API.Context
{
    public class CalculoFreteContext : DbContext
    {
        public CalculoFreteContext(DbContextOptions<CalculoFreteContext> options)
            : base(options)
        {
        }

        public DbSet<CalculoFrete> CalculosFretes { get; set; }
        public DbSet<Embarcadora> Embarcadoras { get; set; }
        public DbSet<Embarque> Embarques { get; set; }
        public DbSet<NegociacaoFrete> NegociacoesFretes { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
    }
}