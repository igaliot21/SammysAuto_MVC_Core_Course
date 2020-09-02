using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        // Details: ServiveTypes/Details/1
        public async Task<IActionResult> Details(int? id){
            if (id == null) return NotFound();
            var serviceType = await context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null) return NotFound();
            return View(serviceType);
        }

        //Edit : ServiceTypes/Edit/1
        public async Task<IActionResult> Edit(int? id){
            if (id == null) return NotFound();
            var serviceType = await context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null) return NotFound();
            return View(serviceType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServiceType serviceType)        {
            if (id != serviceType.Id) return NotFound();
            if (ModelState.IsValid){
                context.Update(serviceType);
                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(serviceType);
        }

        //Delete : ServiceTypes/Delete/1
        public async Task<IActionResult> Delete(int? id){
            if (id == null) return NotFound();
            var serviceType = await context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (serviceType == null) return NotFound();
            return View(serviceType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveServiceType(int id){
            var serviceType = await context.ServiceTypes.SingleOrDefaultAsync(m => m.Id == id);
            context.ServiceTypes.Remove(serviceType);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        protected override void Dispose(bool disposing){
            if (disposing) this.context.Dispose();
        }
    }
}
