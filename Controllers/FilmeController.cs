using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class FilmeController : Controller
    {
        private readonly IFilmeRepository _repository;

        public FilmeController(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var filmes = _repository.GetAll();
            return View(filmes);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult AddFilme(Filme filme)
        {
            _repository.AddFilme(filme);
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            var filme = _repository.GetById(id);
            return View(filme);
        }
        
        public IActionResult UpdateFilme(Filme filme)
        {
            _repository.UpdateFilme(filme);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFilme(int id)
        {
            _repository.DeleteFilme(id);
            return RedirectToAction("Index");
        }
    }
}
