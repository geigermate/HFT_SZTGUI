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
using Microsoft.AspNetCore.SignalR;
using F27T0P_HFT_2021222.Endpoint.Services;

namespace F27T0P_HFT_2021222.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerLogic cl;
        IHubContext<SignalRHub> hub;

        public CustomerController(ICustomerLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
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
            var customerToDelete = cl.Read(id);
            cl.Delete(id);
            hub.Clients.All.SendAsync("CustomerDeleted", customerToDelete);
        }

        [HttpPut]
        public void Update([FromBody] Customer customer)
        {
            cl.Update(customer);
            hub.Clients.All.SendAsync("CustomerUpdated", customer);
        }

        [HttpPost]
        public void Create([FromBody] Customer customer)
        {
            cl.Create(customer);
            hub.Clients.All.SendAsync("CustomerCreated", customer);
        }
    }
}
