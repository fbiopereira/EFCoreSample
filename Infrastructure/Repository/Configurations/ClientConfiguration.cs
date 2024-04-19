using Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Repository.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {

            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            builder.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
            builder.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasColumnName("Nome").IsRequired();
            builder.Property(p => p.BirthDate).HasColumnType("DATETIME").HasColumnName("DataNascimento");


        }
    }
}
