using F27T0P_HFT_2021222.Logic.Interfaces;
using F27T0P_HFT_2021222.Models;
using F27T0P_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Logic
{
    public class GpuTypeLogic : IGpuTypeLogic
    {
        IRepository<GpuType> repo;

        public GpuTypeLogic(IRepository<GpuType> repo)
        {
            this.repo = repo;
        }

        public void Create(GpuType item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public GpuType Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<GpuType> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(GpuType item)
        {
            this.repo.Update(item);
        }


        //NON-CRUD

        public IEnumerable<GpuType> GetGpuWithoutOwner()
        {
            return (IEnumerable<GpuType>)(from x in this.repo.ReadAll()
                   where x.CustomerId.Equals(0)
                   select x.Name);
        }

        public IEnumerable<GpuType> GetGpuWithMultipleBrands()
        {
            return (IEnumerable<GpuType>)(from x in this.repo.ReadAll()
                   where x.Brands.Count >= 2
                   select x.Name);
        }

        public IEnumerable<GpuType> GetGpuWithShortestBrandName()
        {
            return (IEnumerable<GpuType>)this.repo.ReadAll()
                                                  .Select(gpu => gpu.Brands.Where(brand => brand.Name.Length <= 3));
        }
    }
}
