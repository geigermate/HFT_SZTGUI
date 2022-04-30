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
    public class GpuTypeController : ControllerBase
    {
        IGpuTypeLogic gpuLogic;

        public GpuTypeController(IGpuTypeLogic gpuLogic)
        {
            this.gpuLogic = gpuLogic;
        }

        [HttpGet]
        public IEnumerable<GpuType> ReadAll()
        {
            return gpuLogic.ReadAll();
        }

        [HttpGet("{id}")]
        public GpuType Read(int id)
        {
            return gpuLogic.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            gpuLogic.Delete(id);
        }

        [HttpPut]
        public void Update([FromBody] GpuType gpu)
        {
            gpuLogic.Update(gpu);
        }

        [HttpPost]
        public void Create([FromBody] GpuType gpu)
        {
            gpuLogic.Create(gpu);
        }
    }
}
