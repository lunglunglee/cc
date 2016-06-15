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
    public class Order_DetailController : Controller
    {
        private Model_cc db = new Model_cc();

        // GET: Order_Detail
        public async Task<ActionResult> Index()
        {
            var order_Details = db.Order_Details.Include(o => o.Category).Include(o => o.Endded).Include(o => o.Order).Include(o => o.Pay).Include(o => o.代理表);
            return View(await order_Details.ToListAsync());
        }

        // GET: Order_Detail/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = await db.Order_Details.FindAsync(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // GET: Order_Detail/Create
        public ActionResult Create()
        {
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱");
            ViewBag.貨品狀況 = new SelectList(db.Enddeds, "EnddedId", "貨品狀況");
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶");
            ViewBag.支付方式 = new SelectList(db.Pays, "PayId", "支付方法");
            ViewBag.訂購代理 = new SelectList(db.代理表, "EmployeeID", "代理稱謂");
            return View();
        }

        // POST: Order_Detail/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderID,訂購日期,訂購代理,訂購貨品,價格,件數,Discount,支付方式,相關客戶,貨品狀況,More")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Detail);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Detail.訂購貨品);
            ViewBag.貨品狀況 = new SelectList(db.Enddeds, "EnddedId", "貨品狀況", order_Detail.貨品狀況);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Detail.OrderID);
            ViewBag.支付方式 = new SelectList(db.Pays, "PayId", "支付方法", order_Detail.支付方式);
            ViewBag.訂購代理 = new SelectList(db.代理表, "EmployeeID", "代理稱謂", order_Detail.訂購代理);
            return View(order_Detail);
        }

        // GET: Order_Detail/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = await db.Order_Details.FindAsync(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Detail.訂購貨品);
            ViewBag.貨品狀況 = new SelectList(db.Enddeds, "EnddedId", "貨品狀況", order_Detail.貨品狀況);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Detail.OrderID);
            ViewBag.支付方式 = new SelectList(db.Pays, "PayId", "支付方法", order_Detail.支付方式);
            ViewBag.訂購代理 = new SelectList(db.代理表, "EmployeeID", "代理稱謂", order_Detail.訂購代理);
            return View(order_Detail);
        }

        // POST: Order_Detail/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderID,訂購日期,訂購代理,訂購貨品,價格,件數,Discount,支付方式,相關客戶,貨品狀況,More")] Order_Detail order_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Detail).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.訂購貨品 = new SelectList(db.Categories, "CategoryID", "貨品名稱", order_Detail.訂購貨品);
            ViewBag.貨品狀況 = new SelectList(db.Enddeds, "EnddedId", "貨品狀況", order_Detail.貨品狀況);
            ViewBag.OrderID = new SelectList(db.Orders, "OrderID", "客戶", order_Detail.OrderID);
            ViewBag.支付方式 = new SelectList(db.Pays, "PayId", "支付方法", order_Detail.支付方式);
            ViewBag.訂購代理 = new SelectList(db.代理表, "EmployeeID", "代理稱謂", order_Detail.訂購代理);
            return View(order_Detail);
        }

        // GET: Order_Detail/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Detail order_Detail = await db.Order_Details.FindAsync(id);
            if (order_Detail == null)
            {
                return HttpNotFound();
            }
            return View(order_Detail);
        }

        // POST: Order_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order_Detail order_Detail = await db.Order_Details.FindAsync(id);
            db.Order_Details.Remove(order_Detail);
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
