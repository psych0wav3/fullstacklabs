using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using monetize.application.services;
using monetize.domain.dtos;
using monetize.domain.entities;
using monetize.domain.enums;
using monetize.domain.Repositories;
using monetize.domain.services;
using Moq;

namespace monetize.test
{
    [TestClass]
    public class BalanceServiceTest
    {
        [TestMethod]
        public void Test_Update_Balance_Expect_Returns_void_true()
        {
            // Arrange
            List<Balance> balances = new List<Balance>{
                new Balance{
                    Value = 20,
                    Currency = Currency.BRL
                },

                new Balance{
                    Value = 30,
                    Currency = Currency.USD
                }
            };
            Balance balance = new Balance();

            Moviments moviment = new Moviments();

                // Balance Repo config
            var _balanceRepo = new Mock<IBaseRepository<Balance>>();
            _balanceRepo.Setup(x => x.Read()).Returns(Task.FromResult(balances));
            _balanceRepo.Setup(x => x.Update(It.IsAny<Balance>()));
            _balanceRepo.Setup(x => x.SaveChangesAsync());

                // Moviments Repo config
            var _movimentRepo = new Mock<IBaseRepository<Moviments>>();
            _movimentRepo.Setup(x => x.Create(It.IsAny<Moviments>())).Returns(Task.FromResult(moviment));
            _movimentRepo.Setup(x => x.SaveChangesAsync());

            

            var _balanceMock = new Mock<IBalance>();
            _balanceMock.Setup(x => x.UpdateValue(It.IsAny<Double>()));
            
            UpdateBalanceService _service = new UpdateBalanceService(_balanceRepo.Object, _movimentRepo.Object);

            UpdateBalanceDTO _updateDTO = new UpdateBalanceDTO
            {
                Value = 12.45,
                
                Currency = Currency.BRL,
            };
            
            var result = true;
            
            // Act
            try
            {   
                _service.Execute(_updateDTO);
                // Assert

            }catch(Exception)
            {
                result = false;
            }
            // Assert
            
                Assert.IsTrue(result);   
        }

        [TestMethod]
        public void Test_Create_Balance_Expect_Returns_void_true()
        {
            // Arrange
            var _balanceRepo = new Mock<IBaseRepository<Balance>>();
            _balanceRepo.Setup(x => x.Create(It.IsAny<Balance>()));
            _balanceRepo.Setup(x => x.SaveChangesAsync());

            CreateBalanceService _service = new CreateBalanceService(_balanceRepo.Object);

            CreateBalanceDTO _balance = new CreateBalanceDTO{
                Value = 30,
                Currency = Currency.USD
            };

            var result = true;
            // Act
            try
            {   
                _service.Execute(_balance);
            }
            catch(Exception)
            {
                result = false;
            }   
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Test_List_Balance_Expect_Returns_List_of_Balance()
        {
            // Arrange
             List<Balance> balances = new List<Balance>{
                new Balance{
                    Value = 20,
                    Currency = Currency.BRL
                },

                new Balance{
                    Value = 30,
                    Currency = Currency.USD
                }
            };

            var _balanceRepo = new Mock<IBaseRepository<Balance>>();
            _balanceRepo.Setup(x => x.Read()).Returns(Task.FromResult(balances));
            
            var _service = new ListBalanceService(_balanceRepo.Object);
            
            // Act
            
            Task<List<Balance>> result = _service.Execute();

            // Assert

            StringAssert.Equals(balances, result);
        }

        [TestMethod]
        public void Test_convert_Balance_Expect_Returns_void_true()
        {
           // Arrange
            List<Balance> balances = new List<Balance>{
                new Balance{
                    Value = 20,
                    Currency = Currency.BRL
                },

                new Balance{
                    Value = 30,
                    Currency = Currency.USD
                }
            };
            Balance balance = new Balance();

            Moviments moviment = new Moviments();

                // Balance Repo config
            var _balanceRepo = new Mock<IBaseRepository<Balance>>();
            _balanceRepo.Setup(x => x.Read()).Returns(Task.FromResult(balances));
            _balanceRepo.Setup(x => x.Update(It.IsAny<Balance>()));
            _balanceRepo.Setup(x => x.SaveChangesAsync());

                // Moviments Repo config
            var _movimentRepo = new Mock<IBaseRepository<Moviments>>();
            _movimentRepo.Setup(x => x.Create(It.IsAny<Moviments>())).Returns(Task.FromResult(moviment));
            _movimentRepo.Setup(x => x.SaveChangesAsync());

            var inMemorySettings = new Dictionary<string, string> {
                {"IOF", "1"},
                {"spread", "1"},
                {"USD", "1"},
                {"EUR", "1"},
            };
            IConfiguration configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(inMemorySettings)
            .Build();

            var _balanceMock = new Mock<IBalance>();
            _balanceMock.Setup(x => x.UpdateValue(It.IsAny<Double>()));
            
            ConvertBalanceService _service = new ConvertBalanceService(_balanceRepo.Object, _movimentRepo.Object, configuration);

            ConvertBalanceDTO _convertDTO = new ConvertBalanceDTO
            {
                Value = 12.45,
                
                Currency = Currency.BRL,
            };
            
            var result = true;
            
            // Act
            try
            {   
                _service.Execute(_convertDTO);
                // Assert

            }catch(Exception)
            {
                result = false;
            }
            // Assert
            
                Assert.IsTrue(result);   
            
        }


    }
}
