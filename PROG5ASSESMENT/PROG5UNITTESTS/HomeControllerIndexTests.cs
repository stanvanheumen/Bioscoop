using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG5ASSESMENT.Controllers;
using System.Web;
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
            //Assert.AreEqual("Hello, world!", result.ViewBag.Message);
        }
    }
}
