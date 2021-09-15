using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVCUI.Filter;

namespace WebMVCUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly BookDbContext _bookDbContext;

        public AccountController(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Login(string email, string pass)
        {
            var user = _bookDbContext.Users.FirstOrDefault(w => w.Email.Equals(email) && w.Password.Equals(pass));
            if (user!=null)
            {
                HttpContext.Session.SetInt32("id", user.Id);
                HttpContext.Session.SetString("fullname",user.Name+ " "+ user.SurName);

                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }

        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetInt32("id").HasValue)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> Register(User user)
        {
            await _bookDbContext.Users.AddAsync(user);
            await _bookDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
