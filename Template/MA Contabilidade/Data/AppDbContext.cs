using Cozastore.Models;
using CozaStore.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TCCKakitas.Data;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {        
    }

    public DbSet<Servico> Servicos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        AppDbSeed seed = new(builder);

        #region Relacionamento de Muitos para Muitos - Servico
        builder.Entity<Servico>()
            .HasOne(e => e.Documento)
            .WithMany(p => p.Servico)
            .HasForeignKey(e => e.DocumentoId);
        
        #endregion
    
    }
}