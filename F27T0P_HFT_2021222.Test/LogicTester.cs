using System;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using F27T0P_HFT_2021222.Logic;
using F27T0P_HFT_2021222.Logic.Interfaces;
using F27T0P_HFT_2021222.Repository.ModelRepositories;
using F27T0P_HFT_2021222.Repository;
using F27T0P_HFT_2021222.Models;

namespace F27T0P_HFT_2021222.Test
{
    [TestFixture]
    public class LogicTester
    {
        CustomerLogic cl;
        Mock<IRepository<Customer>> mockCustomerRepo;

        [SetUp]
        public void Init()
        {
            var gpus = new List<GpuType>()
            {
                new GpuType()
                {
                    Id = 1,
                    Name = "GTX 1660",
                    BasePrice = 150000,
                    CustomerId = 1
                },

                new GpuType()
                {
                    Id = 2,
                    Name = "RX 6950XT",
                    BasePrice = 1350000,
                    CustomerId = 1
                }
            };

            var fakeCustomers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Tesztelo",
                    BoughtCards = gpus,
                }
            }.AsQueryable();

            mockCustomerRepo = new Mock<IRepository<Customer>>();
            mockCustomerRepo.Setup(xy => xy.ReadAll())
                            .Returns(fakeCustomers.AsQueryable());

            cl = new CustomerLogic(mockCustomerRepo.Object);
        }

        [Test]
        public void AVGPriceTest()
        {
            //Act
            var result = cl.GetAverageGpuPrice();

            //Assert
            Assert.That(result, Is.EqualTo(750000));
        }

        [Test]
        public void TestDelete()
        {
            // Act
            cl.Delete(1);

            // Assert
            mockCustomerRepo
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
