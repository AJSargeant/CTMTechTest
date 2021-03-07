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
                return RedirectToAction("Index", "Home");
            }
            return View(merchant);
        }
    }
}
