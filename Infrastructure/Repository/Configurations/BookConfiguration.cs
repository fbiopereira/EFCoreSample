using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Livro");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasColumnName("Nome").IsRequired();
            builder.Property(p => p.Publisher).HasColumnType("VARCHAR(100)").HasColumnName("Editora").IsRequired();
        }
    }
}
