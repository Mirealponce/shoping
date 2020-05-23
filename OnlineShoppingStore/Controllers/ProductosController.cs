using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.DAL;
using System.Threading.Tasks;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Controllers
{
    public class ProductosController : Controller
    {
        private VentasEntities1 db = new VentasEntities1();

        // GET: Productos
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria);
            

            return View(producto.ToList());
        }
        //filtro por categoria
        public ActionResult OrdenarPorCategoria()
        {
            var productos = from p in db.Producto
                            orderby p.precio ascending
                            select p;
            return View(productos);
       
        }
        public ActionResult filtrar(string nombre)
        {
            var filtro = db.Producto.Where(tipo => tipo.Categoria.tipoCategoria.Equals(nombre));
            return View(filtro);
        }

      
        public ActionResult AddToCart(int? id)
        {
            if (Session["cart"] == null)
            {
                List<Carrito> cart = new List<Carrito>();
                var product = db.Producto.Find(id);
                cart.Add(new Carrito()
                {
                    Productos = product,
                    Cantidad = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Carrito> cart = (List<Carrito>)Session["cart"];
                var product = db.Producto.Find(id);
                cart.Add(new Carrito()
                {
                    Productos = product,
                    Cantidad = 1
                });
                Session["cart"] = cart;
            }
            return Redirect("../../Productos/IndexClient");
        }

        public ActionResult DetalleCarrito()
        {

            return View();
        }

        //Lista productos para usuario
        public ActionResult IndexClient()
        {
            var producto = db.Producto.Include(p => p.Categoria);


            return View(producto.ToList());
        }

        // GET: Productos/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.Categoria_idCategoria = new SelectList(db.Categoria, "idCategoria", "tipoCategoria");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,Foto,nombreProducto,precio,Descripcion,Categoria_idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria_idCategoria = new SelectList(db.Categoria, "idCategoria", "tipoCategoria", producto.Categoria_idCategoria);
            return View(producto);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria_idCategoria = new SelectList(db.Categoria, "idCategoria", "tipoCategoria", producto.Categoria_idCategoria);
            return View(producto);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,Foto,nombreProducto,precio,Descripcion,Categoria_idCategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria_idCategoria = new SelectList(db.Categoria, "idCategoria", "tipoCategoria", producto.Categoria_idCategoria);
            return View(producto);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
