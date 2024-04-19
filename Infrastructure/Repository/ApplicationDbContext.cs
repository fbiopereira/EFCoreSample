using Core.Entity;
using Infrastructure.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ApplicationDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext()
        {
                
        }

        public ApplicationDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Order> Order { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer(_connectionString);

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //OPÇÃO 1: CONFIGURANDO TUDO NO ONMODEL CREATING (FLUENT API)

            //modelBuilder.Entity<Client>(e =>
            //{
            //    e.ToTable("Cliente");
            //    e.HasKey(p => p.Id);
            //    e.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
            //    e.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
            //    e.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasColumnName("Nome").IsRequired();
            //    e.Property(p => p.BirthDate).HasColumnType("DATETIME").HasColumnName("DataNascimento");
            //}
            //);

           // modelBuilder.Entity<Book>(e =>
           // {
           //     e.ToTable("Livro");
           //     e.HasKey(p => p.Id);
           //     e.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
           //     e.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
           //     e.Property(p => p.Name).HasColumnType("VARCHAR(100)").HasColumnName("Nome").IsRequired();
           //     e.Property(p => p.Publisher).HasColumnType("VARCHAR(100)").HasColumnName("Editora").IsRequired();
           // }
           //);

          //  modelBuilder.Entity<Order>(e =>
          //  {
          //      e.ToTable("Pedido");
          //      e.HasKey(p => p.Id);
          //      e.Property(p => p.Id).HasColumnType("INT").ValueGeneratedNever().UseIdentityColumn();
          //      e.Property(p => p.CreationDate).HasColumnType("DATETIME").HasColumnName("DataCriacao").IsRequired();
          //      e.Property(p => p.ClientId).HasColumnType("INT").HasColumnName("IdCliente").IsRequired();
          //      e.Property(p => p.BookId).HasColumnType("INT").HasColumnName("IdLivro").IsRequired();

          //      e.HasOne(p => p.Client).WithMany(c => c.Orders).HasPrincipalKey(c => c.Id).HasConstraintName("FK_Pedido_Cliente");
          //      e.HasOne(p => p.Book).WithMany(b => b.Orders).HasPrincipalKey(b => b.Id).HasConstraintName("FK_Pedido_Livro");
          //  }
          //);


            // OPÇÃO 2: Usando configurations individualmente
            // modelBuilder.ApplyConfiguration(new ClientConfiguration());
            // modelBuilder.ApplyConfiguration(new BookConfiguration());
            // modelBuilder.ApplyConfiguration(new OrderConfiguration());


            //OPCAO 3: Usando configurations automaticamente (FLUENT API)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        }
    }
}
