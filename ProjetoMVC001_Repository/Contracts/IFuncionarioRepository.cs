using ProjetoMVC001_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC001_Repository.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        List<Funcionario> BuscarPorNome(string nome);
        Funcionario BuscarPorCPF(string cpf);
    }
}
