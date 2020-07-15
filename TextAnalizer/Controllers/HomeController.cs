using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextAnalizer.Models;
using TextAnalizer.Services;

namespace TextAnalizer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WordsAmount _wordsAmount;

        public HomeController(ILogger<HomeController> logger, WordsAmount wordsAmount)
        {
            _logger = logger;
            _wordsAmount = wordsAmount;
        }

        public IActionResult Index(string inputText)
        {
            WordsInTextViewModel wordsInTextViewModel = new WordsInTextViewModel();
            if (inputText != null)
            {
                wordsInTextViewModel.InputText = inputText;
                wordsInTextViewModel.WordInText = _wordsAmount.TextAnalize(inputText);
            }
            return View(wordsInTextViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
