using ProjetoMVC001_Repository.Contracts;
using ProjetoMVC001_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace ProjetoMVC001_Repository.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly string connectionString;

        public DepartamentoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Cadastrar(Departamento obj)
        {
            var sql = "INSERT INTO DEPARTAMENTO(NOME, DESCRICAO) VALUES(@NOME, @DESCRICAO)";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public Departamento BuscarPorId(Guid id)
        {
            var sql = "SELECT * FROM DEPARTAMENTO WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Departamento>(sql, new { id }).FirstOrDefault();
            }
        }

        public List<Departamento> BuscarTodos()
        {
            var sql = "SELECT * FROM DEPARTAMENTO ASC";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Departamento>(sql).ToList();
            }
        }
        public void Atualizar(Departamento obj)
        {
            var sql = "UPDATE DEPARTAMENTO SET NOME = @NOME, DESCRICAO = @DESCRICAO WHERE ID = @ID";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public void Deletar(Guid id)
        {
            var sql = "DELETE FROM DEPARTAMENTO WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { id });
            }
        }
    }
}
