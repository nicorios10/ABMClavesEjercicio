using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EjercicioClavesABM.Classes;
using EjercicioClavesABM.Models;

namespace EjercicioClavesABM.Controllers
{
    public class NovedadController : Controller
    {
        private EjercicioClavesABMContext dbContext = new EjercicioClavesABMContext();

        //Lista de Novedades
        public ActionResult Index()
        {
            return View(dbContext.Novedades.ToList());
        }

        //Detalle
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedad novedad = dbContext.Novedades.Find(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //Crear - Get
        public ActionResult Create()
        {
            return View();
        }

        //Crear - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                dbContext.Novedades.Add(novedad);
                dbContext.SaveChanges();

                //Imagen
                if (novedad.ImagenFile != null)
                {
                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", novedad.NovedadId);
                    var respose = FilesHelpers.UploadPhoto(novedad.ImagenFile, folder, file);

                    if (respose)
                    {
                        var pic = string.Format("{0}/{1}", folder, file);
                        //si respose es true, actualizamos el logo de la compania
                        novedad.Imagen = pic;
                        //actalizamos la db
                        dbContext.Entry(novedad).State = EntityState.Modified;
                        dbContext.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            
            return View(novedad);
        }

        //Editar - Get
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var novedad = dbContext.Novedades.Find(id);

            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //Editar - Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Novedad novedad)
        {
            if (ModelState.IsValid)
            {
                //Imagen
                if (novedad.ImagenFile != null)
                {
                    var pic = string.Empty;

                    var folder = "~/Content/Logos";
                    var file = string.Format("{0}.jpg", novedad.NovedadId);
                    var respose = FilesHelpers.UploadPhoto(novedad.ImagenFile, folder, file);

                    if (respose)
                    {
                        pic = string.Format("{0}/{1}", folder, file);
                        //si respose es true, actualizamos el logo de la compania
                        novedad.Imagen = pic;

                    }
                }
                
                //actalizamos la db
                dbContext.Entry(novedad).State = EntityState.Modified;
                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(novedad);
        }

        //Borrar - Get
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Novedad novedad = dbContext.Novedades.Find(id);
            if (novedad == null)
            {
                return HttpNotFound();
            }
            return View(novedad);
        }

        //Borrar - Post
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Novedad novedad = dbContext.Novedades.Find(id);
            dbContext.Novedades.Remove(novedad);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
