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
    public class PedidoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public PedidoController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Pedido()
        {
                                                 //Expresion   
            var listPedido=_context.Pedidos.OrderBy(s => s.ID).ToList();
            
            return View("Pedido",listPedido);
            

        }
        [HttpPost]
        public ActionResult ProductosSelect(int[] productids)
        {
            List<Producto> productos = new List<Producto>();
            foreach(var i in productids){
                var producto = _context.productos.Find(i);
                productos.Add(producto);
            }
            if(productids.Any()){
                
                ViewBag.Message="Productos agregados";
                return View(productos);
                
            }else{
            
                ViewBag.Message="Seleccione un producto";
                return RedirectToAction("Pedido");
                
            }
            
        }
    }
}