using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using XFPanelJexus.Web.Models.SqlService;

namespace XFPanelJexus.Web.Views.Test
{
    public class JexusSqlsController : Controller
    {
        private readonly SQLContext _context;

        public JexusSqlsController(SQLContext context)
        {
            _context = context;
        }

        // GET: JexusSqls
        public async Task<IActionResult> Index()
        {
            return View(await _context.jexusSqls.ToListAsync());
        }

        // GET: JexusSqls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jexusSql = await _context.jexusSqls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jexusSql == null)
            {
                return NotFound();
            }

            return View(jexusSql);
        }

        // GET: JexusSqls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JexusSqls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NameID,DownM,Email,DateTime,SHType,FilePath,Sitename")] JexusSql jexusSql)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jexusSql);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jexusSql);
        }

        // GET: JexusSqls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jexusSql = await _context.jexusSqls.FindAsync(id);
            if (jexusSql == null)
            {
                return NotFound();
            }
            return View(jexusSql);
        }

        // POST: JexusSqls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,NameID,DownM,Email,DateTime,SHType,FilePath,Sitename")] JexusSql jexusSql)
        {
            if (id != jexusSql.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jexusSql);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JexusSqlExists(jexusSql.ID))
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
            return View(jexusSql);
        }

        // GET: JexusSqls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jexusSql = await _context.jexusSqls
                .FirstOrDefaultAsync(m => m.ID == id);
            if (jexusSql == null)
            {
                return NotFound();
            }

            return View(jexusSql);
        }

        // POST: JexusSqls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jexusSql = await _context.jexusSqls.FindAsync(id);
            _context.jexusSqls.Remove(jexusSql);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Test(string email)
        {
            var a=_context.jexusSqls.Where(k => k.Email == email).OrderByDescending(k => k.DateTime).ToList();
            return View(a);
        }
        private bool JexusSqlExists(int id)
        {
            return _context.jexusSqls.Any(e => e.ID == id);
        }
    }
}
