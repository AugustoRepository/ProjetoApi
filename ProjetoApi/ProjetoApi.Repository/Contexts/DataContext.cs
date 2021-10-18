using Microsoft.EntityFrameworkCore;
using ProjetoApi.Repository.Entities;
using ProjetoApi.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApi.Repository.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Produto> Produto {set; get;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
