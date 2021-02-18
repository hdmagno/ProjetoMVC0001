using ProjetoMVC001_Repository.Contracts;
using ProjetoMVC001_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace ProjetoMVC001_Repository.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly string connectionString;

        public FuncionarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Cadastrar(Funcionario obj)
        {
            var sql = @"INSERT INTO FUNCIONARIO(NOME, SALARIO, DATAADMISSAO, CARGO_ID, DEPARTAMENTO_ID)
                        VALUES(@NOME, @SALARIO, @DATAADMISSAO, @CARGOID, @DEPARTAMENTOID";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }
        }
        public List<Funcionario> BuscarTodos()
        {
            var sql = "SELECT * FROM FUNCIONARIO ASC";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(sql).ToList();
            }
        }

        public Funcionario BuscarPorCPF(string cpf)
        {
            var sql = "SELECT * FROM FUNCIONARIO WHERE CPF = @CPF";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(sql, new { cpf }).FirstOrDefault();
            }
        }

        public List<Funcionario> BuscarPorNome(string nome)
        {
            var sql = "SELECT * FROM FUNCIONARIO WHERE NOME LIKE @NOME";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(sql, new { nome }).ToList();
            }
        }

        public void Atualizar(Funcionario obj)
        {
            var sql = @"UPDATE FUNCIONARIO SET NOME = @NOME, SALARIO = @SALARIO, DATAADMISSAO = @DATAADMISSAO, 
                        CARGO_ID = @CARGOID, DEPARTAMENTO_ID = @DEPARTAMENTOID
                        WHERE ID = @ID";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }

        }

        public void Deletar(Guid id)
        {
            var sql = "DELETE FROM FUNCIONARIO WHERE ID = @ID";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { id });
            }
        }
    }
}
