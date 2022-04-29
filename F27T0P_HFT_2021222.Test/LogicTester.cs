﻿using System;
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

        GpuTypeLogic gl;
        Mock<IRepository<GpuType>> mockGpuRepo;

        [SetUp]
        public void Init()
        {
            #region GPU Test
            //GPU Test
            var brandfor3050 = new List<Brand>()
            {
                new Brand(){Id = 1, Name = "ASUS", GpuTypeId = 1},
                new Brand(){Id = 2, Name = "PALIT", GpuTypeId = 1},
            };

            var brandfor3060 = new List<Brand>()
            {
                new Brand(){Id = 3, Name = "GIGABYTE", GpuTypeId = 2},
            };

            var brandfor3070 = new List<Brand>()
            {
                new Brand(){Id = 5, Name = "MSI", GpuTypeId = 3},
            };

            var brandfor3080 = new List<Brand>()
            {
                new Brand(){Id = 6, Name = "ZOTAC", GpuTypeId = 4},
            };

            var brandfor6800 = new List<Brand>()
            {
                new Brand(){Id = 4, Name = "SAPPHIRE", GpuTypeId = 5},
            };

            var brandfor3090 = new List<Brand>()
            {
                new Brand(){Id = 7, Name = "NVIDIA", GpuTypeId = 6}
            };

            var gpuTypes = new List<GpuType>()
            {
                new GpuType(){Id = 1, Name = "RTX 3050",  BasePrice = 160000, Brands = brandfor3050},
                new GpuType(){Id = 2, Name = "RTX 3060",  BasePrice = 250000, Brands = brandfor3060},
                new GpuType(){Id = 3, Name = "RTX 3070",  BasePrice = 320000, Brands = brandfor3070},
                new GpuType(){Id = 4, Name = "RTX 3080",  BasePrice = 450000, Brands = brandfor3080},
                new GpuType(){Id = 5, Name = "RX 6800XT",  BasePrice = 500000, Brands = brandfor6800},
                new GpuType(){Id = 6, Name = "RTX 3090", BasePrice = 900000, Brands = brandfor3090}
            }.AsQueryable();

            mockGpuRepo = new Mock<IRepository<GpuType>>();
            mockGpuRepo.Setup(xy => xy.ReadAll())
                       .Returns(gpuTypes);

            gl = new GpuTypeLogic(mockGpuRepo.Object);
            #endregion

            #region Customer test
            //Customer test
            var testGpus = new List<GpuType>()
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
                    BasePrice = 900000,
                    CustomerId = 1
                }
            };

            var boriszGpu = new List<GpuType>()
            {
                new GpuType()
                {
                    Id = 1,
                    Name = "RTX 3090Ti",
                    BasePrice = 1000000,
                    CustomerId = 2
                }
            };

            var fakeCustomers = new List<Customer>()
            {
                new Customer()
                {
                    Id = 1,
                    Name = "Tesztelo",
                    BoughtCards = testGpus,
                },

                new Customer()
                {
                    Id = 2,
                    Name = "Vadállat Borisz",
                    BoughtCards = boriszGpu
                }

            }.AsQueryable();

            mockCustomerRepo = new Mock<IRepository<Customer>>();
            mockCustomerRepo.Setup(xy => xy.ReadAll())
                            .Returns(fakeCustomers);

            cl = new CustomerLogic(mockCustomerRepo.Object);
            #endregion
        }

        [Test]
        public void AvgGpuPriceTest()
        {
            //Act
            var result = gl.GetAverageGpuPrice();

            //Assert
            Assert.That(result, Is.EqualTo(430000));
        }

        //[Test]
        //public void AVGPriceTestForAPerson()
        //{
        //    //Act
        //    var result = cl.GetAverageGpuPriceForAPerson(mockCustomerRepo.Object.Read(cl.Read(1).Id).Id);

        //    //Assert
        //    Assert.That(result, Is.EqualTo(750000));
        //}

        [Test]
        public void TestDelete()
        {
            //Act
            cl.Delete(1);

            //Assert
            mockCustomerRepo.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public void MostGpuOwnedTest()
        {
            //Arrange
            //var gpuTypes = new List<GpuType>()
            //{
            //    new GpuType(){Id = 1, Name = "RTX 3050",  BasePrice = 150000, CustomerId = 1},
            //    new GpuType(){Id = 2, Name = "RTX 3060",  BasePrice = 200000, CustomerId = 2},
            //    new GpuType(){Id = 3, Name = "RTX 3070",  BasePrice = 280000, CustomerId = 2},
            //    new GpuType(){Id = 4, Name = "RTX 3080",  BasePrice = 400000, CustomerId = 2},
            //    new GpuType(){Id = 5, Name = "RX 6800XT",  BasePrice = 500000, CustomerId = 3},
            //    new GpuType(){Id = 6, Name = "RTX 3090", BasePrice = 900000}
            //};

            //var customers = new List<Customer>()
            //{
            //    new Customer(){Id = 1, Name = "Máté"},
            //    new Customer(){Id = 2, Name = "Pista"},
            //    new Customer(){Id = 3, Name = "Palkó"},
            //};

            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Tesztelo", 2)
            };

            //Act
            var result = cl.GetMostOwnedGpuCustomers();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GpuWithoutOwner()
        {
            //Arrange


            //Act
            var result = gl.GetGpuWithoutOwner();

            //Assert
            Assert.That(result.ToArray().Length == 6);
        }

        [Test]
        public void LeastSpentCustomer()
        {
            //Arrange
            var expected = new List<KeyValuePair<string, double>>()
            {
                new KeyValuePair<string, double>("Vadállat Borisz", 1000000)
            };

            //Act
            var result = cl.GetLowestValueSpentCustomer();

            //Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
