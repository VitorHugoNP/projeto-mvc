using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoMVC.Models
{
    [Table("filmes")]
    public class Filme
    {
        public Filme(int id, string titulo, string sinopse, string genero, string classificacao, DateTime data_lancamento)
        {
            Id = id;
            Titulo = titulo;
            Sinopse = sinopse;
            Genero = genero;
            Classificacao = classificacao;
            Data_lancamento = data_lancamento;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_lancamento { get; set; }

    }
}
