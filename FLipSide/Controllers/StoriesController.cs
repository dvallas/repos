using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using FlipSideModels;
using FlipSideDataAccess;
using FlipSideNet.DAL;

namespace FlipSide.Controllers
{
    public class StoriesController : Controller
    {
        public readonly FlipSideDataContext _context = new FlipSideDataContext();


        public StoriesController(FlipSideDataContext context)
        {
            _context = context;
        }

        public StoriesController()
        {
            ;
        }

        // GET: Stories/Home
        public async Task<ActionResult> Home()
        {
            //make this async
            return View(_context.DisplayPage) ;

            //this is how Create connects to the method in the DA class
            //var stry = CreateStoryObject(vals);
            //var result = new DA().WriteStory(stry);
            //if (!ModelState.IsValid) return View(stry);
            //return RedirectToAction(nameof(Home));

        }


        public async Task<ActionResult> Index()
        {
            var s = _context.Story.ToList();
           // return View(await _context.Story.ToListAsync());
            return View(s);
        }

        // GET: Stories/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Story
                .SingleOrDefaultAsync(m => m.id == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        private Story CreateStoryObject(IEnumerable<string> vals)
        {
            //int thisLean =int.Parse(vals.ElementAt(5));
            try
            {
                //var stry = (Story) vals;
                var stry = new Story()
                {
                    dateran = DateTime.Parse(vals.ElementAt(0)),
                    slug = vals.ElementAt(1),
                    summary = vals.ElementAt(2),
                    link = vals.ElementAt(3),
                    byline = vals.ElementAt(4),
                    //lean = thisLean,
                    lean = 1,
                    topic = vals.ElementAt(6),
                    shouldrun= DateTime.Parse(vals.ElementAt(7))
                };
                return stry;
            }catch(Exception e)

            {
                return new Story();
            }

        }

        // GET: Stories/Create
        public ActionResult Create()
        {
            return PartialView();
        }


        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,dateRan,slug,summary,byline,link,lean,topic")] Story story)
        //public async Task<IActionResult> Create(int id, DateTime dateRan, string slug, string summary, string byline, string link, int lean, string topic)
        public async Task<ActionResult> Create(IEnumerable<string> vals)
        {
            var stry = CreateStoryObject(vals);
            var result = await new DA().WriteStory(stry);
            if (!ModelState.IsValid) return View(stry);
            return RedirectToAction(nameof(Index));

        }

        // GET: Stories/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Story.SingleOrDefaultAsync(m => m.id == id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind(Include = "dateran,slug,summary,byline,link,lean,shouldrun,id")] Story story)
        {
            if (id != story.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryExists(story.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        private ActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        // GET: Stories/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.Story
                .SingleOrDefaultAsync(m => m.id == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var story = await _context.Story.SingleOrDefaultAsync(m => m.id == id);
            _context.Story.Remove(story);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryExists(int id)
        {
            return _context.Story.Any(e => e.id == id);
        }
    }
}