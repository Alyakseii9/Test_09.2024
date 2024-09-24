using Microsoft.AspNetCore.Mvc;
using System.Web.Http.ModelBinding;

namespace My_1_w.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }


  /*  [HttpPost]  
    [ValidateAntiForgeryToken]  
    public async Task<IActionResult> Login(LoginModel model)// IActionResult Edit(CatalogItemViewModel catalogItemViewModel)
    {
     if (ModelState.isValid)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Passoword);
        }
        
        
    }   */
}
