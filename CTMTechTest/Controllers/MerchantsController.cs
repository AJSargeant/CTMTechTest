using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTMTechTest.Data;
using CTMTechTest.Models;

namespace CTMTechTest.Controllers
{
    public class MerchantsController : Controller
    {
        private readonly DataContext _context;

        public MerchantsController(DataContext context)
        {
            _context = context;
        }

        // GET: Merchants
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merchant.ToListAsync());
        }

        // GET: Merchants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merchants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] Merchant merchant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merchant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merchant);
        }

        // GET: Merchants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchant.SingleOrDefaultAsync(m => m.ID == id);
            if (merchant == null)
            {
                return NotFound();
            }
            return View(merchant);
        }

        // POST: Merchants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Merchant merchant)
        {
            if (id != merchant.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merchant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerchantExists(merchant.ID))
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
            return View(merchant);
        }

        // GET: Merchants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merchant = await _context.Merchant
                .SingleOrDefaultAsync(m => m.ID == id);
            if (merchant == null)
            {
                return NotFound();
            }

            return View(merchant);
        }

        // POST: Merchants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merchant = await _context.Merchant.SingleOrDefaultAsync(m => m.ID == id);
            _context.Merchant.Remove(merchant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MerchantExists(int id)
        {
            return _context.Merchant.Any(e => e.ID == id);
        }
    }
}
