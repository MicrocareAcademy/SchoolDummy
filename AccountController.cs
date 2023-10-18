using Microsoft.AspNetCore.Mvc;
using SchoolDummy.Entities;
using SchoolDummy.Models;

namespace SchoolDummy
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public IActionResult SubmitLogin(LoginModel loginModel)
        {
            var dbContext = new SchoolDBContext();

            User userObj = dbContext.Users.FirstOrDefault(p => 
                                         p.Username == loginModel.Username && 
                                         p.Password == loginModel.Password);

            if(userObj == null)
            {

            }
            else
            {
                return RedirectToAction("Dashboard", "Home");
            }
            
        }

        public IActionResult RegisterForm()
        {
            var model = new RegisterModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult SaveUser(RegisterModel registerModel)
        {
            // Logic
            var dbContext = new SchoolDBContext();

            User newUser = new User();
            newUser.Username = registerModel.Username;
            newUser.Password = registerModel.Password;
            newUser.Email = registerModel.Email;

            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return RedirectToAction("Login");
        }


    }
}
