using System.Net;
using System.Threading.Tasks;
using lunch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lunch.Controllers
{
    public class RestaurantController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            var items = await DocumentDBRepository<Restaurant>.GetItemsAsync(d => d.HasDailyOfferToday);
            return View(items);
        }

        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Name,Description,Address")] Restaurant item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Restaurant>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Name,Description,Completed")] Restaurant item)
        {
            if (ModelState.IsValid)
            {
                await DocumentDBRepository<Restaurant>.UpdateItemAsync(item.Id, item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Restaurant item = await DocumentDBRepository<Restaurant>.GetItemAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }
    }
}