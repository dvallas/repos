using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlipSideModels;
using FLipSide.DAL;

namespace FLipSide.Controllers
{
    public class NewStoriesController : Controller
    {
        private NewStoriesContext db = new NewStoriesContext();

        //GET: NewStories
        public async Task<ActionResult> Index()
        {
            return View(await db.Stories.ToListAsync());
        }

        //public async Task<ActionResult> Index()
        //{
        //    var s = db.Stories.ToListAsync();
        //    // return View(await _context.Story.ToListAsync());
        //    return View(s);
        //}

        // GET: NewStories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = await db.Stories.FindAsync(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: NewStories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewStories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,dateran,slug,summary,link,byline,lean,is_active,topic,shouldrun")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Stories.Add(story);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(story);
        }

        // GET: NewStories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = await db.Stories.FindAsync(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: NewStories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,dateran,slug,summary,link,byline,lean,is_active,topic,shouldrun")] Story story)
        {
            if (ModelState.IsValid)
            {
                db.Entry(story).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: NewStories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = await db.Stories.FindAsync(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: NewStories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Story story = await db.Stories.FindAsync(id);
            db.Stories.Remove(story);
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
