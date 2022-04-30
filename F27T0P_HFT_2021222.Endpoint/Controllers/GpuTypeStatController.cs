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
    public class GpuTypeStatController : ControllerBase
    {
        IGpuTypeLogic gpuLogic;

        public GpuTypeStatController(IGpuTypeLogic gpuLogic)
        {
            this.gpuLogic = gpuLogic;
        }

        [HttpGet]
        public double GetAverageGpuPrice()
        {
            return gpuLogic.GetAverageGpuPrice();
        }

        [HttpGet]
        public IEnumerable<string> GetGpuWithoutOwner()
        {
            return gpuLogic.GetGpuWithoutOwner();
        }

        [HttpGet]
        public IEnumerable<string> GetGpuWithMultipleBrands()
        {
            return gpuLogic.GetGpuWithMultipleBrands();
        }
    }
}