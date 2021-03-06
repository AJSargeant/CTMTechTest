using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CTMTechTest.Controllers;

namespace CTMTechTestUnitTests
{
    [TestClass]
    public class ViewControllerTests
    {
        
        public void Setup()
        {

        }

#region MerchantController tests
        [TestMethod]
        public void TestCreationView()
        {
            var controller = new MerchantsController();
            var result = controller.Create() as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }
#endregion
    }
}
