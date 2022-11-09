using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Alquiler;

namespace Alquiler.Controllers
{
    public class vehiculosController : Controller
    {
        private AlquilerEntities db = new AlquilerEntities();

        // GET: vehiculos
        public ActionResult Index()
        {
            var vehiculos = db.vehiculos.Include(v => v.EstadosVehiculo).Include(v => v.tipoVehiculo);
            return View(vehiculos.ToList());
        }

        // GET: vehiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // GET: vehiculos/Create
        public ActionResult Create()
        {
            ViewBag.idEstado = new SelectList(db.EstadosVehiculo, "IdEstado", "nombre");
            ViewBag.idTipoVehiculo = new SelectList(db.tipoVehiculo, "idtipo", "tipo");
            return View();
        }

        // POST: vehiculos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idVehiculo,matricula,marca,modelo,idTipoVehiculo,idEstado,PesoToneladas")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.vehiculos.Add(vehiculos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstado = new SelectList(db.EstadosVehiculo, "IdEstado", "nombre", vehiculos.idEstado);
            ViewBag.idTipoVehiculo = new SelectList(db.tipoVehiculo, "idtipo", "tipo", vehiculos.idTipoVehiculo);
            return View(vehiculos);
        }

        // GET: vehiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstado = new SelectList(db.EstadosVehiculo, "IdEstado", "nombre", vehiculos.idEstado);
            ViewBag.idTipoVehiculo = new SelectList(db.tipoVehiculo, "idtipo", "tipo", vehiculos.idTipoVehiculo);
            return View(vehiculos);
        }

        // POST: vehiculos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idVehiculo,matricula,marca,modelo,idTipoVehiculo,idEstado,PesoToneladas")] vehiculos vehiculos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehiculos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstado = new SelectList(db.EstadosVehiculo, "IdEstado", "nombre", vehiculos.idEstado);
            ViewBag.idTipoVehiculo = new SelectList(db.tipoVehiculo, "idtipo", "tipo", vehiculos.idTipoVehiculo);
            return View(vehiculos);
        }

        // GET: vehiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vehiculos vehiculos = db.vehiculos.Find(id);
            if (vehiculos == null)
            {
                return HttpNotFound();
            }
            return View(vehiculos);
        }

        // POST: vehiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vehiculos vehiculos = db.vehiculos.Find(id);
            db.vehiculos.Remove(vehiculos);
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
