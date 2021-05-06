using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NetCoreWebApp.Data;
using NetCoreWebApp.Models;

namespace NetCoreWebApp.Controllers
{
    public class PredmetiController : Controller
    {
        /*
        private readonly Context _context;

        public PredmetiController(Context context)
        {
            _context = context;
        }
        */
        static List<Predmet> predmeti = new List<Predmet>()
         {
         new Predmet(name: "OOAD", points: 5.0),
         new Predmet(name: "AFJ", points: 5.0),
         new Predmet(name: "ORM", points: 5.0),
         new Predmet(name: "RA", points: 5.0)
         };
        public PredmetiController(Context context)
        {
        }

        // GET: Predmeti
        public IActionResult Index()
        {
            return View(predmeti);
        }

        // GET: Predmeti/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = predmeti.Find(m => m.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // GET: Predmeti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Predmeti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Naziv,ECTS")] Predmet predmet)
        {
            if (ModelState.IsValid)
            {
                predmeti.Add(predmet);
                return RedirectToAction(nameof(Index));
            }
            return View(predmet);
        }

        // GET: Predmeti/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = predmeti.Find(p => p.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }
            return View(predmet);
        }

        // POST: Predmeti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Naziv,ECTS")] Predmet predmet)
        {
            if (id != predmet.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var stariPredmet = predmeti.Find(p => p.ID == id);
                    stariPredmet.ID = predmet.ID;
                    stariPredmet.Naziv = predmet.Naziv;
                    stariPredmet.ECTS = predmet.ECTS;
                    stariPredmet.UpisaniStudenti = predmet.UpisaniStudenti;
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetExists(predmet.ID))
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
            return View(predmet);
        }

        // GET: Predmeti/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = predmeti.Find(p => p.ID == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // POST: Predmeti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var predmet = predmeti.Find(p => p.ID == id);
            predmeti.Remove(predmet);
            return RedirectToAction(nameof(Index));
        }

        private bool PredmetExists(int id)
        {
            return predmeti.Any(e => e.ID == id);
        }
    }
}
