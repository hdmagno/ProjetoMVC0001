using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoMVC001_Repository.Entities
{
    public class Funcionario
    {
        #region Atributos

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Salario { get; set; }
        public DateTime DataAdmissao { get; set; }

        #endregion

        #region Relacionamentos

        public Guid CargoId { get; set; }
        public Cargo Cargo { get; set; }

        public Guid DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        #endregion
    }
}
