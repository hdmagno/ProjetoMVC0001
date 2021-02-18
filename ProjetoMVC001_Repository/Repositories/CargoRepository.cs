using Dapper;
using ProjetoMVC001_Repository.Contracts;
using ProjetoMVC001_Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ProjetoMVC001_Repository.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly string connectionString;

        public CargoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Cadastrar(Cargo obj)
        {
            var sql = "INSERT INTO CARGO(NOME, DESCRICAO) VALUES(@NOME, @DESCRICAO)";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }
        }
        public List<Cargo> BuscarTodos()
        {
            var sql = "SELECT * FROM CARGO ASC";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cargo>(sql).ToList();
            }
        }
        public Cargo BuscarPorId(Guid id)
        {
            var sql = "SELECT * FROM CARGO WHERE ID = @ID";

            using(var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Cargo>(sql, new { id }).FirstOrDefault();
            }
        }

        public void Atualizar(Cargo obj)
        {
            var sql = "UPDATE CARGO SET NOME = @NOME, DESCRICAO = @DESCRICAO WHERE ID = @ID";

            using(var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, obj);
            }
        }

        public void Deletar(Guid id)
        {
            var sql = "DELETE FROM CARGO WHERE ID = @ID";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(sql, new { id });
            }
        }

    }
}
