using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SammysAuto.Data;
using SammysAuto.Models;

namespace SammysAuto.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly ApplicationDbContext context;
        
        public ServiceTypeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        // GET: ServiceTypes
        public IActionResult Index()
        {
            return View(context.ServiceTypes.ToList());
        }

        //GET: ServiceType/Create
        public IActionResult Create() 
        {
            return View();
        }

        //POST: ServiceType/Create
        public async Task<IActionResult> Create(ServiceType newServiceType) 
        {
            if (ModelState.IsValid)
            {
                context.Add(newServiceType);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else return View(newServiceType);
        }

        protected override void Dispose(bool disposing){
            if (disposing) this.context.Dispose();
        }
    }
}
