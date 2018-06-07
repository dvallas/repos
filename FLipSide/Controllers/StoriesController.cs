using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FlipSideDataAccess;
using FlipSideModels;
using FLipSide.DAL;

namespace FLipSide.Controllers
{
    public class StoriesController : Controller
    {
        private NewStoriesContext db = new NewStoriesContext();

        //GET: NewStories
        public async Task<ActionResult> Index()
        {
            return View(await db.Story.ToListAsync());
        }

        // GET: NewStories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = await db.Story.FindAsync(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: NewStories/Create
        public ActionResult Create()
        {
            var dataFile = Server.MapPath("~/App_Logs/data.txt");
            System.IO.File.WriteAllText(@dataFile, "entering Create");
            Log.Info("entering Create with blank form");
            return View();
        }

        private Story CreateStoryObject(IEnumerable<string> vals)
        {
            try
            {
                var stry = new Story()
                {
                    dateran = DateTime.Parse(vals.ElementAt(0)),
                    slug = vals.ElementAt(1),
                    summary = vals.ElementAt(2),
                    link = vals.ElementAt(3),
                    byline = vals.ElementAt(4),
                    lean = int.Parse(vals.ElementAt(5)),
                    topic = vals.ElementAt(6),
                    shouldrun = DateTime.Parse(vals.ElementAt(7)),
                    is_active = int.Parse(vals.ElementAt(8))
                };
                return stry;
            }
            catch (Exception e)

            {
                Log.Info(e.Message + e.InnerException);
                Console.WriteLine(e);
                return new Story();
            }

        }


        // POST: Stories/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IEnumerable<string> vals)
        {
            Log.Info("Create action started... vals count: "+ vals.Count());
            //System.IO.File.WriteAllText("aaTestLog.log", "coming from the Create Post method");
            try
            {
                Log.Info("Story object created.  Sending to Write");
                var stry = CreateStoryObject(vals);
                Log.Info("Story object created.  Sending to Write");
                var result = await new DA(new FlipSideNet.DAL.FlipSideDataContext()._Context).WriteStory(stry);
                if (!ModelState.IsValid) return View(stry);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                Log.Info(e.Message + e.InnerException);
                Console.WriteLine(e);
                return View();
            }

        }

        // GET: NewStories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = await db.Story.FindAsync(id);
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
            Story story = await db.Story.FindAsync(id);
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
            Story story = await db.Story.FindAsync(id);
            db.Story.Remove(story);
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
