using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraDeFreteSimulado.API.Context
{
    public class NegociacaoFreteContext : DbContext
    {
        public NegociacaoFreteContext(DbContextOptions<NegociacaoFreteContext> options)
            : base(options)
        {
        }

        public DbSet<NegociacaoFrete> NegociacoesFretes { get; set; }
        public DbSet<Embarcadora> Embarcadoras { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
    }
}