using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F27T0P_HFT_2021222.Models;
using F27T0P_HFT_2021222.Repository;
using F27T0P_HFT_2021222.Logic.Interfaces;

namespace F27T0P_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomerStatController : ControllerBase
    {
        ICustomerLogic cl;

        public CustomerStatController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet("{customerId}")]
        public double GetAverageGpuPriceForAPerson(int customerId)
        {
            return cl.GetAverageGpuPriceForAPerson(customerId);
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetMostOwnedGpuCustomers()
        {
            return cl.GetMostOwnedGpuCustomers();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetOwnersOrderedByNumOfGpus()
        {
            return cl.GetOwnersOrderedByNumOfGpus();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetLowestValueSpentCustomer()
        {
            return cl.GetLowestValueSpentCustomer();
        }

        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> GetHighestValueSpentCustomer()
        {
            return cl.GetHighestValueSpentCustomer();
        }
    }
}
