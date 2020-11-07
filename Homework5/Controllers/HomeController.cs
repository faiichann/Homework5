using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Homework5.Models;
using Homework5.Model.db;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework5.Controllers
{
    public class HomeController : Controller
    {
        WebBlogContext db = new WebBlogContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Post post)
        {
            post.UserId = Convert.ToInt32(HttpContext.Request.Form["Id"].ToString());
            post.UserName = HttpContext.Request.Form["name"].ToString();
            post.UserPost = HttpContext.Request.Form["post"].ToString();
            post.UserDate = Convert.ToDateTime(HttpContext.Request.Form["date"].ToString());

            if (ModelState.IsValid)
            {
                db.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(post);
        }

        public IActionResult Index()
        {
            var ps = from p in db.Post select p;
            return View(ps);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
