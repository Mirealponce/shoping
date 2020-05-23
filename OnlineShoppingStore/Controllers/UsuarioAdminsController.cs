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
    public class UsuarioAdminsController : Controller
    {
        private VentasEntities1 db = new VentasEntities1();

        // GET: UsuarioAdmins
        public ActionResult Index()
        {
            return View(db.UsuarioAdmin.ToList());
        }

        // GET: UsuarioAdmins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAdmin usuarioAdmin = db.UsuarioAdmin.Find(id);
            if (usuarioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuarioAdmin);
        }

        // GET: UsuarioAdmins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsuarioAdmins/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuarioAdmin,nombreAdmin,clave")] UsuarioAdmin usuarioAdmin)
        {
            if (ModelState.IsValid)
            {
                db.UsuarioAdmin.Add(usuarioAdmin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuarioAdmin);
        }

        // GET: UsuarioAdmins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAdmin usuarioAdmin = db.UsuarioAdmin.Find(id);
            if (usuarioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuarioAdmin);
        }

        // POST: UsuarioAdmins/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuarioAdmin,nombreAdmin,clave")] UsuarioAdmin usuarioAdmin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuarioAdmin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuarioAdmin);
        }

        // GET: UsuarioAdmins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioAdmin usuarioAdmin = db.UsuarioAdmin.Find(id);
            if (usuarioAdmin == null)
            {
                return HttpNotFound();
            }
            return View(usuarioAdmin);
        }

        // POST: UsuarioAdmins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioAdmin usuarioAdmin = db.UsuarioAdmin.Find(id);
            db.UsuarioAdmin.Remove(usuarioAdmin);
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
