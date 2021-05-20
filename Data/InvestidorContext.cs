using API_Investidor.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Investidor.Data
{
    public partial class InvestidorContext : DbContext
    {
        public InvestidorContext(DbContextOptions<InvestidorContext> options)
            : base(options) { }

        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Artigo> artigo { get; set; }
        public DbSet<EBook> ebook { get; set; }
        public DbSet<Live> live { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>()
                .HasKey(t => t.IDCATEGORIA);

            modelBuilder.Entity<Categoria>()
            .Property(t => t.IDCATEGORIA)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Cliente>()
                .HasKey(t => t.IDCLIENTE);

            modelBuilder.Entity<Cliente>()
            .Property(t => t.IDCLIENTE)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<Artigo>()
                .HasKey(t => t.IDARTIGO);

            modelBuilder.Entity<Artigo>()
                .HasOne(d => d.CLIENTE)
                .WithMany()
                .HasForeignKey("IDCLIENTE");

            modelBuilder.Entity<Artigo>()
                .HasOne(d => d.CATEGORIA)
                .WithMany()
                .HasForeignKey("IDCATEGORIA");

            modelBuilder.Entity<EBook>()
                .HasKey(t => t.IDEBOOK);

            modelBuilder.Entity<EBook>()
                .HasOne(d => d.CLIENTE)
                .WithMany()
                .HasForeignKey("IDCLIENTE");

            modelBuilder.Entity<Live>()
                .HasKey(t => t.IDLIVE);

            modelBuilder.Entity<Live>()
                .HasOne(d => d.CLIENTE)
                .WithMany()
                .HasForeignKey("IDCLIENTE");

            modelBuilder.Entity<Live>()
                .HasOne(d => d.CATEGORIA)
                .WithMany()
                .HasForeignKey("IDCATEGORIA");
        }
    }
}
