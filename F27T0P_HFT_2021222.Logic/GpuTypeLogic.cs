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
            if (item.Name == "")
            {
                throw new ArgumentException("GPU can't exist with no name...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public GpuType Read(int id)
        {
            return this.repo.Read(id) ?? throw new ArgumentException("GPU with the specified id doesn't exist.");
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

        public double GetAverageGpuPrice()
        {
            return this.repo.ReadAll().Average(g => g.BasePrice) ?? 0;
        }

        public IEnumerable<string> GetGpuWithoutOwner()
        {
            return from x in this.repo.ReadAll()
                   where x.CustomerId.Equals(0)
                   select x.Name;
        }

        public IEnumerable<string> GetGpuWithMultipleBrands()
        {
            return from x in this.repo.ReadAll()
                   where x.Brands.Count() > 1
                   select x.Name;
        }

        //public IEnumerable<KeyValuePair<string, string>> GetGpuWithShortestBrandName()
        //{
        //    //return this.repo.ReadAll().Select(gpu => gpu.Brands.Where(brand => brand.Name.Length <= 3));
        //    return from x in this.repo.ReadAll()
        //           select new KeyValuePair<string, string>(x.Name, x.Brands.);
        //}
    }
}
