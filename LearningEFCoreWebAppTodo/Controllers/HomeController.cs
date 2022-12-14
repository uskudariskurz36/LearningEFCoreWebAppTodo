using LearningEFCoreWebAppTodo.Entities;
using LearningEFCoreWebAppTodo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LearningEFCoreWebAppTodo.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public IActionResult Index()
        {
            List<Todo> todos = db.Todos.ToList();

            return View(todos);
        }

        public IActionResult SampleWhereQuery()
        {
            List<Todo> todos = db.Todos.Where(x => x.Category == "work").ToList();

            return View("Index", todos);
        }
        
        public IActionResult SampleLikeQuery()
        {
            List<Todo> todos = db.Todos.Where(x => x.Title.Contains("ab")).ToList();
            //List<Todo> todos = db.Todos.Where(x => x.Title.StartsWith("lorem")).ToList();
            //List<Todo> todos = db.Todos.Where(x => x.Title.EndsWith("met.")).ToList();

            return View("Index", todos);
        }

        public IActionResult SampleFirstOrDefaultQuery()
        {
            //Todo todo = db.Todos.Where(x => x.Completed == true).FirstOrDefault();
            Todo todo = db.Todos.FirstOrDefault(x => x.Completed == true);

            return View("Index", new List<Todo> { todo });
        }

        // LINQ =  Language INtegrated Query (Dile entegre edilmiş sorgulama)

        //public IActionResult Test()
        //{
        //    var list = db.Todos.GroupBy(x => x.Category);

        //    foreach (var item in list)
        //    {
        //        string key = item.Key;
        //        int total = item.Sum(x => x.Id);
        //    }
            

        //    return View("Index", new List<Todo> { todo });
        //}

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