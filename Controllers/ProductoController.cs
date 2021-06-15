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
    public class ProductoController : Controller
    {

        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public ProductoController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        //Descendiente Mayor a Menor
        //Ascendiente Menor a Mayor
        public IActionResult ListProducto()
        {
                                                 //Expresion   
            var listProductos=_context.productos.OrderBy(s => s.ID).ToList();
            ViewBag.Message="Porfavor, seleccione un producto";
            return View("ListProducto",listProductos);
            
        }

        




        public IActionResult Create()
        {
            return View();
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
                return RedirectToAction("ListProducto");
                
            }
            
        }

        [HttpPost]
        public ActionResult ProductosGrabar(int[] productids, int[] cantidades )
        {
            List<Producto> productos = new List<Producto>();

            for(int i = 0; i<productids.Count(); i++)
            {
                    var objPedido = new Pedido();
                    var objProducto = _context.productos.Find(productids[i]);

                    objPedido.pedi_id_produ = productids[i];
                    objPedido.pedi_cantidad = cantidades[i];
                    objPedido.pedi_precio = objProducto.prod_precio;
            
                    _context.Add(objPedido);
                    _context.SaveChanges();
                    
            }


            //retorno al listado de productos
            var listProductos=_context.productos.OrderBy(s => s.ID).ToList();
            ViewBag.mensajeGrabar = "Los datos se grabaron con éxito - su pedido llegará en una hora a su domicilio";
            return View("ListProducto",listProductos);
            /*return View("ConfirmProducto");*/
        }
        /*[HttpPost]
        public IActionResult ConfirmProducto(String Mens){
            ViewBag.mensajeGrabar = "Los datos se grabaron con éxito - su pedido llegará aprox. en una hora a su domicilio";
            return RedirectToAction("Index");
        }


        public IActionResult ConfirmProducto(){
            
            return View();
        }
        */
       public IActionResult RegProducto()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult RegProducto(Producto objRegProducto){

            if (ModelState.IsValid)
            {
                string[] nombreImagen = objRegProducto.prod_imagen.Split("\\");
        
                objRegProducto.prod_imagen = "/images/" + nombreImagen.Last();

                _context.Add(objRegProducto);
                _context.SaveChanges();

                 ViewBag.mensajeGrabarProducto = "Producto grabado correctamente";
                 ViewBag.Imagen = "/images/" + nombreImagen.Last();
            }
            else
            {
                ViewBag.mensajeGrabarProducto = "Se ha producido un error";
            }
           
            return View();

            //var listProductos=_context.productos.OrderBy(s => s.ID).ToList();
            //return View("ListProducto",listProductos);
            

        }    

/*  inicio comentarios   */
        // GET: http://localhost:5000/Contacto/Edit/6 MUESTRA Contacto
        public IActionResult EditProducto(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var producto = _context.productos.Find(id);
            ViewBag.Imagen = producto.prod_imagen;
            if(producto == null){
                return NotFound();
            }
            return View(producto);
        }

        //POST: http://localhost:5000/Contacto/Edit/ graba contacto
        [HttpPost]
        public IActionResult EditProducto(int id, Producto objRegProducto, string hdnRutaImagen)
        {
            if (ModelState.IsValid)
            {
                string nombreImagen = "";
                string RutaImagen = "";

                if (!string.IsNullOrEmpty(objRegProducto.prod_imagen))
                {
                    string[] nombreImagenSplit = objRegProducto.prod_imagen.Split("\\");
                    nombreImagen = nombreImagenSplit.Last();
                    RutaImagen = "/images/" + nombreImagen; 
                    objRegProducto.prod_imagen = RutaImagen;
                }
                else{
                   //var imagenOriginal = _context.productos.Find(id).prod_imagen;
                   //objRegProducto.prod_imagen = imagenOriginal;
                   //RutaImagen = imagenOriginal;

                   objRegProducto.prod_imagen = hdnRutaImagen;
                   RutaImagen = hdnRutaImagen;
                }
                             
                ViewBag.Imagen = RutaImagen;

                _context.Update(objRegProducto);
                _context.SaveChanges();

                 ViewBag.mensajeGrabarProducto = "Producto grabado correctamente";
                 System.Console.WriteLine(ViewBag.Imagen);
            }
            else
            {
                ViewBag.mensajeGrabarProducto = "Se ha producido un error";
            }
            return View(objRegProducto);
        }


       public IActionResult MantProducto()
        {
            var MantProductos=_context.productos.OrderBy(s => s.ID).ToList();
            return View("MantProducto",MantProductos);
        }

        // GET: http://localhost:5000/Contacto/Delete/6 MUESTRA Contacto
        public IActionResult DelProd(int? id)
        {
            var producto = _context.productos.Find(id);
            _context.productos.Remove(producto);
            _context.SaveChanges();
            return RedirectToAction(nameof(MantProducto));
        }

         public IActionResult Buscar(string texto)
        {
            var textoABuscar = texto.ToUpper();

            var listProductos=_context.productos.Where(x => x.prod_nombre.ToUpper().IndexOf(textoABuscar)>=0);
            
            listProductos = listProductos.OrderBy(s => s.ID);
                  
            return View("ListProducto",listProductos);

        }

        public IActionResult ReclamosProducto(){
            return View();
        }
        
        
    }
}
