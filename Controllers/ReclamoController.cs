using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FyJCel.Models;
using FyJCel.Data;
//using System.Web;

namespace FyJCel.Controllers
{
    public class ReclamoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public ReclamoController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult ReclamosProducto(){
            return View();
        }

        [HttpPost]
        public  IActionResult CrearReclamo(Reclamo objReclamo){

            if (ModelState.IsValid)
            {
                 objReclamo.Mensaje = "Reclamo enviado ... ";

                _context.Add(objReclamo);
                _context.SaveChanges();

                 return View(objReclamo);   
            }
            return View();
        }
    }
}