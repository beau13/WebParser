using Microsoft.AspNetCore.Mvc;
using ElibraryParserWeb.Models;
using ElibraryParserWeb.Services;
using System.Diagnostics;

namespace ElibraryParserWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly SimpleParser _parser;

        public HomeController()
        {
            _parser = new SimpleParser();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Parse(string url)
        {
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    TempData["Error"] = "Введите URL статьи";
                    return RedirectToAction("Index");
                }

                // Парсим статью
                var publication = await _parser.ParseElibraryArticleAsync(url);

                // Возвращаем результат на ту же страницу
                ViewBag.Result = publication;
                ViewBag.OriginalUrl = url;

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Ошибка: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
