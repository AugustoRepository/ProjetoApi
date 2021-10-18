using ProjetoApi.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoApi.Repository.Contracts
{
    public interface IProdutoRepository
    {
        void Create(Produto produto);
        void UpDate(Produto produto);
        void Delete(Produto produto);

        List<Produto> GetAll();
        Produto GetById(Guid id);
    }
}
