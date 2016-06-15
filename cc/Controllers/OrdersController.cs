using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using cc.Models;

namespace cc.Controllers
{
    public class OrdersController : Controller
    {
        private Model_cc db = new Model_cc();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            var orders = db.Orders.Include(o => o.Data_Area).Include(o => o.Data_City).Include(o => o.Data_Province).Include(o => o.Order_Details);
            return View(await orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.區域 = new SelectList(db.Data_Area, "AreaCode", "AreaName");
            ViewBag.城市 = new SelectList(db.Data_City, "CityCode", "CityName");
            ViewBag.省府 = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName");
            ViewBag.OrderID = new SelectList(db.Order_Details, "OrderID", "相關客戶");
            return View();
        }

        // POST: Orders/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderID,OrderDate,代理,客戶,訂購日期,發貨日期,送貨地址,省府,城市,區域,運送方式,備註,ShipVia")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.區域 = new SelectList(db.Data_Area, "AreaCode", "AreaName", order.區域);
            ViewBag.城市 = new SelectList(db.Data_City, "CityCode", "CityName", order.城市);
            ViewBag.省府 = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", order.省府);
            ViewBag.OrderID = new SelectList(db.Order_Details, "OrderID", "相關客戶", order.OrderID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.區域 = new SelectList(db.Data_Area, "AreaCode", "AreaName", order.區域);
            ViewBag.城市 = new SelectList(db.Data_City, "CityCode", "CityName", order.城市);
            ViewBag.省府 = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", order.省府);
            ViewBag.OrderID = new SelectList(db.Order_Details, "OrderID", "相關客戶", order.OrderID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderID,OrderDate,代理,客戶,訂購日期,發貨日期,送貨地址,省府,城市,區域,運送方式,備註,ShipVia")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.區域 = new SelectList(db.Data_Area, "AreaCode", "AreaName", order.區域);
            ViewBag.城市 = new SelectList(db.Data_City, "CityCode", "CityName", order.城市);
            ViewBag.省府 = new SelectList(db.Data_Province, "ProvinceCode", "ProvinceName", order.省府);
            ViewBag.OrderID = new SelectList(db.Order_Details, "OrderID", "相關客戶", order.OrderID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Orders.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Orders.FindAsync(id);
            db.Orders.Remove(order);
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
