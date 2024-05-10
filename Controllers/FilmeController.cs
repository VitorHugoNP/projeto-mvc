using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class FilmeController : Controller
    {
        private readonly FilmeRepository repository;

        public FilmeController(FilmeRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var filmes = repository.GetAll();
            return View(filmes);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult AddFilme(Filme filme)
        {
            repository.Add(filme);
            return RedirectToAction("Index");
        }

        public IActionResult Detalhes(int id)
        {
            var filme = repository.GetById(id);
            return View(filme);
        }
        
        public IActionResult UpdateFilme(Filme filme)
        {
            repository.Update(filme);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFilme(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
