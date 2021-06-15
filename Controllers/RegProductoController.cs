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
    public class RegProductoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public RegProductoController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult RegProducto()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult RegProducto(Producto objRegProducto){

            if (ModelState.IsValid)
            {
                _context.Add(objRegProducto);
                _context.SaveChanges();

                 return View(objRegProducto);   
            }
            return View();

        }    
    }
}
