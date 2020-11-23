using Contatos.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
    {
        public DataContext (DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Contatos.Models.Contato> Contato { get; set; }

        public DbSet<Contatos.Models.Emails> Email { get; set; }

    public DbSet<Contatos.Models.Telefone> Telefone { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.Entity<Contato>()
  .Property<int>("IdContato");

        builder.Entity<Emails>()
  .Property<int>("IdContato"); 

        builder.Entity<Emails>()
  .HasOne(c => c.Contato)
  .WithMany(p => p.Emails)
  .HasForeignKey("IdContato");


        builder.Entity<Telefone>()
  .HasOne(c => c.Contato)
  .WithMany(p => p.Telefones)
  .HasForeignKey("IdContato");
    }



}
