using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sales.Backend.Models;
using Sales.Common.Models;
using Sales.Backend.Helpers;

namespace Sales.Backend.Controllers
{
    [Authorize]
    public class ShopsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Shops
        public async Task<ActionResult> Index()
        {
            var shops = db.Shops.Include(s => s.Seller);
            return View(await shops.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = await db.Shops.FindAsync(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName");
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ShopView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Shops";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                }

                var shop = this.ToShop(view, pic);
                db.Shops.Add(shop);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", view.SellerId);
            return View(view);
        }

        private Shop ToShop(ShopView view, string pic)
        {
            return new Shop
            {
                SellerId = view.SellerId,
                ImagePath = pic,
                ShopName = view.ShopName,
                ShopAddres = view.ShopAddres,
                Latitude = view.Latitude,
                Longitude = view.Longitude,
                ShopPhone = view.ShopPhone
            };
        }

        // GET: Shops/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = await db.Shops.FindAsync(id);

            if (shop == null)
            {
                return HttpNotFound();
            }
            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", shop.SellerId);

            var view = this.ToView(shop);
            return View(view);
        }

        private ShopView ToView(Shop shop)
        {
            return new ShopView
            {
                SellerId = shop.SellerId,
                ImagePath = shop.ImagePath,
                ShopName = shop.ShopName,
                ShopAddres = shop.ShopAddres,
                Latitude = shop.Latitude,
                Longitude = shop.Longitude,
                ShopPhone = shop.ShopPhone
            };
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ShopView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.ImagePath;
                var folder = "~/Content/Shops";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = $"{folder}/{pic}";
                }

                var shop = this.ToShop(view, pic);
                this.db.Entry(shop).State = EntityState.Modified;
                await this.db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SellerId = new SelectList(db.Sellers, "SellerId", "SellerName", view.SellerId);
            return View(view);
        }

        // GET: Shops/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shop shop = await db.Shops.FindAsync(id);
            if (shop == null)
            {
                return HttpNotFound();
            }
            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Shop shop = await db.Shops.FindAsync(id);
            db.Shops.Remove(shop);
            await db.SaveChangesAsync();
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
