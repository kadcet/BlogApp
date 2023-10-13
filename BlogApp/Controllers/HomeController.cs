using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogDbContext _dbContext;

        public HomeController(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var model = _dbContext.Articles.ToList();
            return View(model);
        }

    }
}