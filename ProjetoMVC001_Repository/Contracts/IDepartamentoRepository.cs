using ProjetoMVC001_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC001_Repository.Contracts
{
    public interface IDepartamentoRepository : IBaseRepository<Departamento>
    {
        Departamento BuscarPorId(Guid id);
    }
}
