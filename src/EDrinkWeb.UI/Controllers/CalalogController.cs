using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EDrinkShop.ApplicationCore.Entities;
using EDrinkWeb.UI.Data;

namespace EDrinkWeb.UI.Controllers
{
    public class CalalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Calalog
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CalalogItem.Include(c => c.CatalogBrand).Include(c => c.CatalogType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Calalog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calalogItem = await _context.CalalogItem
                .Include(c => c.CatalogBrand)
                .Include(c => c.CatalogType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calalogItem == null)
            {
                return NotFound();
            }

            return View(calalogItem);
        }

        // GET: Calalog/Create
        public IActionResult Create()
        {
            ViewData["CatalogBrandId"] = new SelectList(_context.Set<CatalogBrand>(), "Id", "Id");
            ViewData["CatalogTypeId"] = new SelectList(_context.Set<CatalogType>(), "Id", "Id");
            return View();
        }

        // POST: Calalog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,ShortDescription,LongDescripptiom,Price,PictureUri,PictureThumbnailUrl,CatalogTypeId,CatalogBrandId,Id")] CalalogItem calalogItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calalogItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CatalogBrandId"] = new SelectList(_context.Set<CatalogBrand>(), "Id", "Id", calalogItem.CatalogBrandId);
            ViewData["CatalogTypeId"] = new SelectList(_context.Set<CatalogType>(), "Id", "Id", calalogItem.CatalogTypeId);
            return View(calalogItem);
        }

        // GET: Calalog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calalogItem = await _context.CalalogItem.FindAsync(id);
            if (calalogItem == null)
            {
                return NotFound();
            }
            ViewData["CatalogBrandId"] = new SelectList(_context.Set<CatalogBrand>(), "Id", "Id", calalogItem.CatalogBrandId);
            ViewData["CatalogTypeId"] = new SelectList(_context.Set<CatalogType>(), "Id", "Id", calalogItem.CatalogTypeId);
            return View(calalogItem);
        }

        // POST: Calalog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,ShortDescription,LongDescripptiom,Price,PictureUri,PictureThumbnailUrl,CatalogTypeId,CatalogBrandId,Id")] CalalogItem calalogItem)
        {
            if (id != calalogItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calalogItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalalogItemExists(calalogItem.Id))
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
            ViewData["CatalogBrandId"] = new SelectList(_context.Set<CatalogBrand>(), "Id", "Id", calalogItem.CatalogBrandId);
            ViewData["CatalogTypeId"] = new SelectList(_context.Set<CatalogType>(), "Id", "Id", calalogItem.CatalogTypeId);
            return View(calalogItem);
        }

        // GET: Calalog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calalogItem = await _context.CalalogItem
                .Include(c => c.CatalogBrand)
                .Include(c => c.CatalogType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calalogItem == null)
            {
                return NotFound();
            }

            return View(calalogItem);
        }

        // POST: Calalog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var calalogItem = await _context.CalalogItem.FindAsync(id);
            _context.CalalogItem.Remove(calalogItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalalogItemExists(int id)
        {
            return _context.CalalogItem.Any(e => e.Id == id);
        }
    }
}
