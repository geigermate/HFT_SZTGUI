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
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;

        public CustomerController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return cl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }

        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            cl.Update(customer);
        }

        [HttpPost]
        public void Create([FromBody] Customer customer)
        {
            cl.Create(customer);
        }
    }
}
