using F27T0P_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Logic.Interfaces
{
    public interface IGpuTypeLogic
    {
        void Create(GpuType item);
        void Delete(int id);
        GpuType Read(int id);
        IQueryable<GpuType> ReadAll();
        void Update(GpuType item);
    }
}
