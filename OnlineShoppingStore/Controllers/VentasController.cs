﻿using System;
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
    public class VentasController : Controller
    {
        private VentasEntities1 db = new VentasEntities1();

        // GET: Ventas
        public ActionResult Index()
        {
            var venta = db.Venta.Include(v => v.Cliente);
            return View(venta.ToList());
        }

        // GET: Ventas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // GET: Ventas/Create
        public ActionResult Create()
        {
            ViewBag.Cliente_idCliente = new SelectList(db.Cliente, "idCliente", "nombre");
            return View();
        }

        // POST: Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVenta,totalVenta,fecha_Venta,Cliente_idCliente")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Venta.Add(venta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cliente_idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.Cliente_idCliente);
            return View(venta);
        }

        // GET: Ventas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cliente_idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.Cliente_idCliente);
            return View(venta);
        }

        // POST: Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVenta,totalVenta,fecha_Venta,Cliente_idCliente")] Venta venta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cliente_idCliente = new SelectList(db.Cliente, "idCliente", "nombre", venta.Cliente_idCliente);
            return View(venta);
        }

        // GET: Ventas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venta venta = db.Venta.Find(id);
            if (venta == null)
            {
                return HttpNotFound();
            }
            return View(venta);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venta venta = db.Venta.Find(id);
            db.Venta.Remove(venta);
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
