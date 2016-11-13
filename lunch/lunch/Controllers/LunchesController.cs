using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lunch.Models;
using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace lunch.Controllers
{
    public class LunchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lunches
        public ActionResult Index()
        {
            return View(db.Lunches.ToList());
        }

        // GET: Lunches/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lunch lunch = db.Lunches.Find(id);
            if (lunch == null)
            {
                return HttpNotFound();
            }
            return View(lunch);
        }


        [HttpPost]
        [ActionName("UploadMenu")]
        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string fileContent = new StreamReader(file.InputStream).ReadToEnd();
                    Lunch lunch = JsonConvert.DeserializeObject<Lunch>(fileContent);
                    await DocumentDBRepository<Lunch>.CreateItemAsync(lunch);
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Upload failed: " + ex;
                return RedirectToAction("Index");
            }
        }

        // GET: Lunches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lunches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,Price")] Lunch lunch)
        {
            if (ModelState.IsValid)
            {
                db.Lunches.Add(lunch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lunch);
        }

        // GET: Lunches/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lunch lunch = db.Lunches.Find(id);
            if (lunch == null)
            {
                return HttpNotFound();
            }
            return View(lunch);
        }

        // POST: Lunches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Price")] Lunch lunch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lunch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lunch);
        }

        // GET: Lunches/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lunch lunch = db.Lunches.Find(id);
            if (lunch == null)
            {
                return HttpNotFound();
            }
            return View(lunch);
        }

        // POST: Lunches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Lunch lunch = db.Lunches.Find(id);
            db.Lunches.Remove(lunch);
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
