using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CTMTechTest.Controllers;
using CTMTechTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace CTMTechTestCoreUnitTests
{
    [TestClass]
    public class ViewControllerTests
    {
        #region MerchantsController tests
        [TestMethod]
        public void TestMerchantCreationView()
        {
            var context = new Mock<DataContext>();
            MerchantsController controller = new MerchantsController(context.Object);
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMerchantIndexView()
        {
            var context = new Mock<DataContext>();
            MerchantsController controller = new MerchantsController(context.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
        #endregion

        #region TransactionsController tests

        [TestMethod]
        public void TestTransactionIndexView()
        {
            var context = new Mock<DataContext>();
            var controller = new TransactionsController(context.Object);
            var result = controller.Index();
            Assert.IsNotNull(result);
        }
        #endregion
    }
}
