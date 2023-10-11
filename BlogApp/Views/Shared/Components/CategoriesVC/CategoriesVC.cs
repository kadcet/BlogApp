using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace BlogApp.Views.Shared.Components.CategoriesVC
{
    //[ViewComponent]

    public class CategoriesVC:ViewComponent
    {
        private readonly BlogDbContext context;

        public CategoriesVC(BlogDbContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var model=context.Categories.ToList();
            // eğer özelleştirme yapmazsam dönecek olduğu Default isimli partial view
            return View(model);
        }
    }
}
