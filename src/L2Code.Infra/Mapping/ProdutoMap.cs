using L2Code.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace L2Code.Infra.Mapping;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");

        builder.HasKey(p => p.ProdutoId);

        builder.OwnsOne(p => p.Dimensoes, d =>
        {
            d.Property(x => x.Comprimento).HasColumnType("decimal(18,2)");
            d.Property(x => x.Largura).HasColumnType("decimal(18,2)");
            d.Property(x => x.Altura).HasColumnType("decimal(18,2)");

            d.Property(x => x.Comprimento).HasColumnName("Comprimento");
            d.Property(x => x.Largura).HasColumnName("Largura");
            d.Property(x => x.Altura).HasColumnName("Altura");
        });

    }
}