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
    public class TransactionsController : Controller
    {
        private readonly DataContext _context;

        public TransactionsController(DataContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transaction.Include(t => t.Merchant).ToListAsync());
        } 

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.ID == id);
        }
    }
}
