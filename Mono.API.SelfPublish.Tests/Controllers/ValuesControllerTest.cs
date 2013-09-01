using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.API.SelfPublish;
using Mono.API.SelfPublish.Controllers;

namespace Mono.API.SelfPublish.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            IEnumerable<string> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("value1", result.ElementAt(0));
            Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            controller.Post(null);

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            BooksController controller = new BooksController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
