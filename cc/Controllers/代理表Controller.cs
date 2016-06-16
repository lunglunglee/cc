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
    public class 代理表Controller : Controller
    {
        private Model_cc db = new Model_cc();

        // GET: 代理表
        public async Task<ActionResult> Index()
        {
            return View(await db.代理表.ToListAsync());
        }

        // GET: 代理表/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            代理表 代理表 = await db.代理表.FindAsync(id);
            if (代理表 == null)
            {
                return HttpNotFound();
            }
            return View(代理表);
        }

        // GET: 代理表/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 代理表/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "EmployeeID,代理稱謂,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] 代理表 代理表)
        {
            if (ModelState.IsValid)
            {
                db.代理表.Add(代理表);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(代理表);
        }

        // GET: 代理表/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            代理表 代理表 = await db.代理表.FindAsync(id);
            if (代理表 == null)
            {
                return HttpNotFound();
            }
            return View(代理表);
        }

        // POST: 代理表/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "EmployeeID,代理稱謂,FirstName,Title,TitleOfCourtesy,BirthDate,HireDate,Address,City,Region,PostalCode,Country,HomePhone,Extension,Photo,Notes,ReportsTo,PhotoPath")] 代理表 代理表)
        {
            if (ModelState.IsValid)
            {
                db.Entry(代理表).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(代理表);
        }

        // GET: 代理表/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            代理表 代理表 = await db.代理表.FindAsync(id);
            if (代理表 == null)
            {
                return HttpNotFound();
            }
            return View(代理表);
        }

        // POST: 代理表/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            代理表 代理表 = await db.代理表.FindAsync(id);
            db.代理表.Remove(代理表);
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
