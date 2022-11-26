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
    public class BrandController : ControllerBase
    {
        IBrandLogic brandLogic;
        IHubContext<SignalRHub> hub;

        public BrandController(IBrandLogic brandLogic, IHubContext<SignalRHub> hub)
        {
            this.brandLogic = brandLogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Brand> ReadAll()
        {
            return brandLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Brand Read(int id)
        {
            return brandLogic.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var brandToDelete = this.brandLogic.Read(id);
            brandLogic.Delete(id);
            hub.Clients.All.SendAsync("BrandDeleted", brandToDelete);
        }

        [HttpPut]
        public void Update([FromBody] Brand brand)
        {
            brandLogic.Update(brand);
            hub.Clients.All.SendAsync("BrandUpdated", brand);
        }

        [HttpPost]
        public void Create([FromBody] Brand brand)
        {
            brandLogic.Create(brand);
            hub.Clients.All.SendAsync("BrandCreated", brand);
        }
    }
}