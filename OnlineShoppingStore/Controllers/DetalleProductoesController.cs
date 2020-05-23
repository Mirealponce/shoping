using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.DAL;

namespace OnlineShoppingStore.Controllers
{
    public class DetalleProductoesController : Controller
    {
        private VentasEntities1 db = new VentasEntities1();

        // GET: DetalleProductoes
        public ActionResult Index()
        {
            var detalleProducto = db.DetalleProducto.Include(d => d.Producto);
            return View(detalleProducto.ToList());
        }
        public ActionResult listas()
        {
            return View();
        }

        public ActionResult detalleProducto( int id)
        {
            var filtro = db.DetalleProducto.Where(detalle => detalle.Producto_idProducto==id);
            ViewBag.Producto_talla = new SelectList(filtro, "Talla", "Talla");
            return View(filtro);
        }
        // GET: DetalleProductoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProducto.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Create
        public ActionResult Create()
        {
            ViewBag.Producto_idProducto = new SelectList(db.Producto, "idProducto", "nombreProducto");
            return View();
        }

        // POST: DetalleProductoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idDetalleProducto,Talla,CantidadStock,Producto_idProducto")] DetalleProducto detalleProducto)
        {
            if (ModelState.IsValid)
            {
                db.DetalleProducto.Add(detalleProducto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Producto_idProducto = new SelectList(db.Producto, "idProducto", "nombreProducto", detalleProducto.Producto_idProducto);
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProducto.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            ViewBag.Producto_idProducto = new SelectList(db.Producto, "idProducto", "Foto", detalleProducto.Producto_idProducto);
            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idDetalleProducto,Talla,CantidadStock,Producto_idProducto")] DetalleProducto detalleProducto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleProducto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Producto_idProducto = new SelectList(db.Producto, "idProducto", "Foto", detalleProducto.Producto_idProducto);
            return View(detalleProducto);
        }

        // GET: DetalleProductoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleProducto detalleProducto = db.DetalleProducto.Find(id);
            if (detalleProducto == null)
            {
                return HttpNotFound();
            }
            return View(detalleProducto);
        }

        // POST: DetalleProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleProducto detalleProducto = db.DetalleProducto.Find(id);
            db.DetalleProducto.Remove(detalleProducto);
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
