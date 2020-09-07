using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string option=null, string search=null)
        {
            var users = new List<ApplicationUser>();
            if (option == "email" && search != null)
            {
                users = this.context.ApplicationUsers.Where(u => u.Email.ToLower().Contains(search.ToLower())).ToList();
            }
            else
            {
                if (option == "name" && search != null)
                {
                    users = this.context.ApplicationUsers.Where(u => u.FirstName.ToLower().Contains(search.ToLower())
                            || u.LastName.ToLower().Contains(search.ToLower())).ToList();
                }
                else
                {
                    if (option == "phone" && search != null)
                    {
                        users = this.context.ApplicationUsers.Where(u => u.PhoneNumber.ToLower().Contains(search.ToLower())).ToList();
                    }
                }
            }
            if (option == null) {
                users = this.context.ApplicationUsers.ToList();
            }
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) this.context.Dispose();
        }
    }
}
