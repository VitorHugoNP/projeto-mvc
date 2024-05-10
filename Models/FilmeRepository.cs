using Npgsql;
using System.Linq.Expressions;

namespace ProjetoMVC.Models
{
    public class FilmeRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;

        public FilmeRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Filme> GetAll()
        {

            var filmes = new List<Filme>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM filmes";
                using NpgsqlCommand command = new(query, connection);
                using NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    filmes.Add(new Filme
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Titulo = reader["Titulo"].ToString(),
                        Sinopse = reader["Sinopse"].ToString(),
                        Genero = reader["Genero"].ToString(),
                        Classificacao = reader["Classificacao"].ToString(),
                        Data_lancamento = Convert.ToDateTime(
                            reader["Data_lancamento"])
                    });
                }
            }

            return filmes;
        }

        public void Add(Filme filme)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "INSERT INTO filmes (titulo, sinopse, genero, classificacao, data_lancamento) " +
                    "VALUES (@Titulo, @Sinopse, @Genero, @Classificacao, @Data_lancamento)";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Titulo", filme.Titulo);
                command.Parameters.AddWithValue("Sinopse", filme.Sinopse);
                command.Parameters.AddWithValue("Genero", filme.Genero);
                command.Parameters.AddWithValue("Classificacao", filme.Classificacao);
                command.Parameters.AddWithValue("Data_lancamento", filme.Data_lancamento);

                command.ExecuteNonQuery();
            }
        }
    
        public Filme GetById(int id)
        {
            var filme = new Filme();
            using(var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Filmes WHERE id = @id";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);
                using NpgsqlDataReader reader = command.ExecuteReader();
                
                    filme.Id = Convert.ToInt32(reader["Id"]);
                    filme.Titulo = reader["Titulo"].ToString();
                    filme.Sinopse = reader["Sinopse"].ToString();
                    filme.Genero = reader["Genero"].ToString();
                    filme.Classificacao = reader["Classificacao"].ToString();
                    filme.Data_lancamento = Convert.ToDateTime(
                        reader["Data_lancamento"]);
            }
            return filme;
        }

        public void Update(Filme filme)
        {
            var resultado = GetById(filme.Id);
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE filmes " +
                    "SET titulo = @Titulo, sinopse = @Sinopse, genero = @Genero, " +
                    "classificacao = @Classificacao, " +
                    "data_lancamento = @Data_lancamento " +
                    "WHERE id = @id";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("Titulo", resultado.Titulo);
                command.Parameters.AddWithValue("Sinopse", resultado.Sinopse);
                command.Parameters.AddWithValue("Genero", resultado.Genero);
                command.Parameters.AddWithValue("Classificacao", resultado.Classificacao);
                command.Parameters.AddWithValue(
                    "Data_lancamento", resultado.Data_lancamento);
                command.Parameters.AddWithValue("id", filme.Id);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var query = "DELETE FROM filmes WHERE id = @id";
                using var command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}
