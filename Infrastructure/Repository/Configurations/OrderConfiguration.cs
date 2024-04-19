using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
            builder.Property(p => p.ClientId).HasColumnType("INT").HasColumnName("IdCliente").IsRequired();
            builder.Property(p => p.BookId).HasColumnType("INT").HasColumnName("IdLivro").IsRequired();            
            builder.HasOne(p => p.Client).WithMany(c => c.Orders).HasPrincipalKey(c => c.Id).HasConstraintName("FK_Pedido_Cliente");
            builder.HasOne(p => p.Book).WithMany(b => b.Orders).HasPrincipalKey(b => b.Id).HasConstraintName("FK_Pedido_Livro");

        }
    }
}
