using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CTMTechTest.Models;
using System.Text;
using CTMTechTest.Data;

namespace CTMTechTest.APIControllers
{
    [Produces("application/json")]
    [Route("api/TransactionsAPI")]
    public class TransactionsAPIController : Controller
    {
        private readonly DataContext _context;

        public TransactionsAPIController(DataContext context)
        {
            _context = context;
        }


        // POST: api/TransactionsAPI
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Transaction[] item)
        {
            if (ModelState.IsValid)
            {
                foreach (Transaction trans in item)
                {
                    Merchant[] possibleMerchants = _context.Merchant.Where(x => trans.Description.Replace("'","").ToUpper().Contains(x.Name.ToUpper())).ToArray<Merchant>();
                    if (possibleMerchants.Length > 0)
                    {
                        possibleMerchants = possibleMerchants.Where(x => possibleMerchants.Where(y => y.Name.Contains(x.Name)).Count() == 1).ToArray();
                        Merchant merchant = null;
                        StringBuilder builder = new StringBuilder();
                        for(int i = 0; i < trans.Description.Length; i++)
                        {
                            builder.Append(trans.Description[i]);
                            merchant = possibleMerchants.FirstOrDefault(x => builder.ToString().ToUpper().Contains(x.Name.ToUpper()));
                            if (merchant != null)
                                break;
                        }

                        trans.Merchant = merchant;
                    }
                    else
                    {
                        Merchant newMerchant = new Merchant { Name = "Unknown" };
                        _context.Merchant.Add(newMerchant);
                        trans.Merchant = newMerchant;
                    }
                    _context.Transaction.Add(trans);
                }
                await _context.SaveChangesAsync();
                return StatusCode(200);
            }
            else
                return StatusCode(500);
        }
    }
}
