using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CTMTechTest.APIControllers;
using CTMTechTest.Data;
using CTMTechTest.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CTMTechTestCoreUnitTests
{
    [TestClass]
    public class APIControllerTests
    {
        private Merchant[] Merchants = 
        {
            new Merchant{ID = 1, Name = "Uber"},
            new Merchant{ID = 2, Name = "Sainsburys"},
            new Merchant{ID = 3, Name = "Amazon"},
            new Merchant{ID = 4, Name = "Uber Eats"}
        };

        private TransactionsAPIController SetupController()
        {
            var context = new Mock<DataContext>();
            context.Object.Merchant = Utils.GetQueryableMockDbSet(Merchants);
            context.Object.Transaction = Utils.GetQueryableMockDbSet(new List<Transaction>());
            return new TransactionsAPIController(context.Object);
        }

        [TestMethod]
        public void TestBasicMerchantTransaction()
        {
            TransactionsAPIController controller = SetupController();
            Transaction trans = new Transaction { Description = "uber help.uber.com" };
            trans = controller.AddMerchant(trans);
            Assert.AreEqual("Uber", trans.Merchant.Name);
        }

        [TestMethod]
        public void TestCompoundMerchantTransaction()
        {
            TransactionsAPIController controller = SetupController();
            Transaction trans = new Transaction { Description = "uber eats help.uber.com" };
            trans = controller.AddMerchant(trans);
            Assert.AreEqual("Uber Eats", trans.Merchant.Name);
        }


        [TestMethod]
        public void TestSpecialCharacterMerchantTransaction()
        {
            TransactionsAPIController controller = SetupController();
            Transaction trans = new Transaction { Description = "sainsbury's sprmrkts lt london" };
            trans = controller.AddMerchant(trans);
            Assert.AreEqual("Sainsburys", trans.Merchant.Name);
        }

        [TestMethod]
        public void TestNewMerchantTransaction()
        {
            TransactionsAPIController controller = SetupController();
            Transaction trans = new Transaction { Description = "netflix.com 866-716-0414" };
            trans = controller.AddMerchant(trans);
            Assert.AreEqual("Unknown", trans.Merchant.Name);
        }
    }
}
