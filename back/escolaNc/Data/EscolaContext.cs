using escolaNc.Modelos;
using Microsoft.EntityFrameworkCore;

namespace escolaNc.Data
{
    public class EscolaContext : DbContext
    {
        public EscolaContext(DbContextOptions<EscolaContext> options) : base(options) {}
        public DbSet<Usuario> USUARIOS { get; set; }
        public DbSet<Servico> SERVICOS { get; set; }
        public DbSet<Contratados> SERVICOS_CONTRATADOS { get; set; }
        public DbSet<Registro> USER_LOGIN { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contratados>().Property(e => e.id_servicos_contratados)
            .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);
        }
    }
}
