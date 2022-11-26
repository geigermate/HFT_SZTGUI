using F27T0P_HFT_2021222.Logic.Interfaces;
using F27T0P_HFT_2021222.Models;
using F27T0P_HFT_2021222.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace F27T0P_HFT_2021222.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            if (item.BrandName.Length <= 2)
            {
                throw new ArgumentException("Brand name too short...");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Brand Read(int id)
        {
            return this.repo.Read(id) ?? throw new ArgumentException("Brand with the specified id doesn't exist.");
        }

        public IQueryable<Brand> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Brand item)
        {
            this.repo.Update(item);
        }
    }
}
