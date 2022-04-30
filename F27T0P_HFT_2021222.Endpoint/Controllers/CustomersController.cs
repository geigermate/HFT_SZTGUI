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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerLogic cl;

        public CustomersController(ICustomerLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Customer> ReadAll()
        {
            return this.cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Customer Read(int id)
        {
            return this.cl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.cl.Delete(id);
        }

        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            this.cl.Update(customer);
        }

        [HttpPost]
        public void Create([FromBody] Customer customer)
        {
            this.cl.Create(customer);
        }
    }
}
