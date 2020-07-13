using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Infra.Contexts
{
    public class ModeloContext : DbContext
    {
        public ModeloContext(DbContextOptions<ModeloContext> options) : base(options) { }

        public ModeloContext()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ParticipanteEvento> ParticipanteEvento { get; set; }

        private readonly IConfiguration _configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ModeloContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
