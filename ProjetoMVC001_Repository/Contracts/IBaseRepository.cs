using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC001_Repository.Contracts
{
    public interface IBaseRepository<T> where T : class
    {
        void Cadastrar(T obj);
        List<T> BuscarTodos();
        void Atualizar(T obj);
        void Deletar(Guid id);
    }
}
