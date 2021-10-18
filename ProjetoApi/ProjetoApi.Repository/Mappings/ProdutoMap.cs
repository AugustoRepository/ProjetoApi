using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoApi.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApi.Repository.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto).HasColumnName("IdProduto").IsRequired();

            builder.Property(p => p.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();

            builder.Property(p => p.Preco).HasColumnName("Preco").HasColumnType("decimal(18,2)").IsRequired();

            builder.Property(p => p.Quantidade).HasColumnName("Quantidade").IsRequired();

            builder.Property(p => p.DataCadastro).HasColumnName("DataCadastro").IsRequired();

            builder.Property(p => p.DataUltimaAlteracao).HasColumnName("DataUltimaAteracao").IsRequired();
        }
    }
}
