using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BEU_Examen;
using BEU_Examen.Transactions;

namespace EXAMEN_Biblioteca.Controllers
{
    public class LibrosController : Controller
    {
        Entities db = new Entities();
        
        // GET: Libros
        public ActionResult Index()
        {
            ViewBag.Title = "Listado de Libros";
            return View("List", LibroBLL.List());
        }

        // GET: Libros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // GET: Libros/Create
        public ActionResult Create()
        {
            ViewBag.id = new SelectList(CategoriaBLL.List(), "id", "nombre");
            return View();
        }

        // POST: Libros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,titulo,autor,isbn,fecha_publicacion,numero_ejemplares,id_categoria")] Libros libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Create(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        // GET: Libros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Libros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,titulo,autor,isbn,fecha_publicacion,numero_ejemplares,id_categoria")] Libros libro)
        {
            if (ModelState.IsValid)
            {
                LibroBLL.Update(libro);
                return RedirectToAction("Index");
            }
            return View(libro);
        }

        // GET: Alumnos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Libros libro = LibroBLL.Get(id);
            if (libro == null)
            {
                return HttpNotFound();
            }
            return View(libro);
        }

        // POST: Alumnos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroBLL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
