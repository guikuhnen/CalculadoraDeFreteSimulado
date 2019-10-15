using CalculadoraDeFreteSimulado.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CalculadoraDeFreteSimulado.API.Context
{
    public class EmbarqueContext : DbContext
    {
        public EmbarqueContext(DbContextOptions<EmbarqueContext> options)
            : base(options)
        {
        }

        public DbSet<Embarque> Embarques { get; set; }
        public DbSet<Embarcadora> Embarcadoras { get; set; }
    }
}