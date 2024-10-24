using AppPedidos.Models;
using Microsoft.EntityFrameworkCore;


namespace AppPedidos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<CategoriaProduto> CategoriaProduto { get; set; }
        public DbSet<SubcategoriaProduto> SubcategoriaProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<Convenio> Convenio { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Pedido> Pedido { get; set; }   
        public DbSet<PedidosItens> PedidosItens { get; set; }
        public DbSet<EmailEnvioModel> EmailEnvio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Hospital)
                .WithMany(c => c.Pedido)
                .HasForeignKey(p=>p.HospitalId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Paciente)
                .WithMany(c=> c.Pedido)
                .HasForeignKey(p => p.PacienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Convenio)
                .WithMany(p => p.Pedido)
                .HasForeignKey(c => c.ConvenioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Medico)
                .WithMany(c=> c.Pedido)
                .HasForeignKey(p => p.MedicosId)
                .OnDelete(DeleteBehavior.Restrict);

                 // Desabilita a exclusão em cascata para evitar múltiplos caminhos
        }
    }
}
