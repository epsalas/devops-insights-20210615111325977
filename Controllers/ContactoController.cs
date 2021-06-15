using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FyJCel.Models;
using FyJCel.Data;

namespace FyJCel.Controllers
{
    public class ContactoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public ContactoController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Descendiente Mayor a Menor
        //Ascendiente Menor a Mayor
        public IActionResult Index()
        {
                                                 //Expresion   
            var listContactos=_context.Contactos.OrderBy(s => s.ID).ToList();
            return View("List",listContactos);

        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public  IActionResult Create(Contacto objContacto){

            if (ModelState.IsValid)
            {
                 objContacto.Mensaje = "Mensaje grabado... ";

                _context.Add(objContacto);
                _context.SaveChanges();

                 return View(objContacto);   
            }
            return View();
        }

        // GET: http://localhost:5000/Contacto/Edit/6 MUESTRA Contacto
        public IActionResult Edit(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var contacto = _context.Contactos.Find(id);
            if(contacto == null){
                return NotFound();
            }
            return View(contacto);
        }

        //POST: http://localhost:5000/Contacto/Edit/ graba contacto
        [HttpPost]
        public IActionResult Edit(int id, Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _context.Update(contacto);
                _context.SaveChanges();
            }
            return View(contacto);
        }


        // GET: http://localhost:5000/Contacto/Delete/6 MUESTRA Contacto
        public IActionResult Delete(int? id)
        {
            var contacto = _context.Contactos.Find(id);
            _context.Contactos.Remove(contacto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
