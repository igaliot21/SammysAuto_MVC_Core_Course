using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;

namespace SammysAuto.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext context;
        public UsersController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var users = this.context.ApplicationUsers.ToList();
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) this.context.Dispose();
        }
    }
}
