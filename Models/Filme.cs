using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public string Classificacao { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data_lancamento { get; set; }

    }
}
