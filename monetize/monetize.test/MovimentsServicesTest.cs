using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using monetize.domain.entities;
using monetize.domain.services;
using Moq;

namespace monetize.test
{
    [TestClass]
    public class MovimentsServiceTest
    {

       [TestMethod]
        public void Test_List_Moviments_Expect_Returns_List_of_Balance()
        {
            // Arrange
            var MockListMovimentsService = new Mock<IListMovimentsService>().Object;
            List<Moviments> moviments = new List<Moviments>{
                new Moviments(),
                new Moviments(),
            };

            // Act
            
            Task<List<Moviments>> result = MockListMovimentsService.Execute();

            // Assert

            StringAssert.Equals(moviments, result);
        }

    }
}
