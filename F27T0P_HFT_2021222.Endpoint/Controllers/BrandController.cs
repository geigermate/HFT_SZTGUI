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
    public class BrandController : ControllerBase
    {
        IBrandLogic brandLogic;

        public BrandController(IBrandLogic brandLogic)
        {
            this.brandLogic = brandLogic;
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
            brandLogic.Delete(id);
        }

        [HttpPut]
        public void Update([FromBody] Brand brand)
        {
            brandLogic.Update(brand);
        }

        [HttpPost]
        public void Create([FromBody] Brand brand)
        {
            brandLogic.Create(brand);
        }
    }
}