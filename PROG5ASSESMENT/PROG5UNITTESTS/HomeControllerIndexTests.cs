using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG5ASSESMENT.Controllers;
using System.Web.Mvc;

namespace PROG5UNITTESTS
{
    [TestClass]
    public class HomeControllerIndexTests
    {
        [TestMethod]
        public void HomeIndexTests()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual(null, result.Model);
        }
    }
}
