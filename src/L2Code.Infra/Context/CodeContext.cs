using L2Code.Domain.Entidades;
using L2Code.Domain.Interfaces;
using L2Code.Infra.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace L2Code.Infra.Context;

public class CodeContext : DbContext, IUnitOfWork
{
    public CodeContext(DbContextOptions<CodeContext> options) : base(options) { }
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoMap());
    }

    public async Task<int> Commit()
    {
        return await base.SaveChangesAsync();
    }
}

public class CleaningDbContextFactory : IDesignTimeDbContextFactory<CodeContext>
{
    public CodeContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CodeContext>();
        optionsBuilder.UseSqlServer(
            "Server=sql,1200;Database=azure-code;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True");

        return new CodeContext(optionsBuilder.Options);
    }
}