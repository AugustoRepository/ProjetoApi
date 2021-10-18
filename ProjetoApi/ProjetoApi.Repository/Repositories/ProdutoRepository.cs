using Microsoft.EntityFrameworkCore;
using ProjetoApi.Repository.Contexts;
using ProjetoApi.Repository.Contracts;
using ProjetoApi.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoApi.Repository.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext dataContext;

        public ProdutoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void Create(Produto produto)
        {
            dataContext.Produto.Add(produto);
            dataContext.SaveChanges();
        }

        public void UpDate(Produto produto)
        {
            dataContext.Entry(produto).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public void Delete(Produto produto)
        {
            dataContext.Produto.Remove(produto);
            dataContext.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return dataContext.Produto.OrderByDescending(p => p.DataCadastro).ToList();
        }

        public Produto GetById(Guid id)
        {
            return dataContext.Produto.Find(id);
        }
    }
}
