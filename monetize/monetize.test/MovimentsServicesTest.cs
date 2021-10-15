using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using monetize.application.services;
using monetize.domain.entities;
using monetize.domain.enums;
using monetize.domain.Repositories;
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
             List<Moviments> moviments = new List<Moviments>{
                new Moviments{
                    NewCurrency = Currency.USD,
                    OldCurrency = Currency.EUR,
                    Value = 10,
                    Type = MovimentEnum.Add
                },

                new Moviments{
                    NewCurrency = Currency.USD,
                    OldCurrency = Currency.EUR,
                    Value = 15,
                    Type = MovimentEnum.Convert
                }
            };


            var _movimentsRepo = new Mock<IBaseRepository<Moviments>>();
            _movimentsRepo.Setup(x => x.Read()).Returns(Task.FromResult(moviments));

            var _service = new ListMovimentsService(_movimentsRepo.Object);
            // Act
            
            Task<List<Moviments>> result = _service.Execute();

            // Assert

            StringAssert.Equals(moviments, result);
        }

    }
}
