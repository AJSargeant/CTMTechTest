using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTMTechTest.Models
{
    public class Transaction
    {
        public int ID { get; set; }
        public string Description { get; set; }
        
        public User User { get; set; }
        public Merchant Merchant { get; set; }
    }
}
