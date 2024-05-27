namespace ProjetoMVC.Models
{
    public interface IFilmeRepository
    {
        public IEnumerable<Filme> GetAll();
        public Filme GetById(int id);
        public void AddFilme(Filme filme);
        public void UpdateFilme(Filme filme);
        public void DeleteFilme(int id);
    }
}
