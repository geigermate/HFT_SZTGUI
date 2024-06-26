﻿using F27T0P_HFT_2021222.Logic.Interfaces;
using F27T0P_HFT_2021222.Models;
using F27T0P_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Logic
{
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Create(Customer item)
        {
            if (item.Name == "")
            {
                throw new ArgumentException("Person name doesn't exist.");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public void Update(Customer item)
        {
            this.repo.Update(item);
        }

        public Customer Read(int id)
        {
            return this.repo.Read(id) ?? throw new ArgumentException("Customer with the specified id doesn't exist.");
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.repo.ReadAll();
        }


        //NON-CRUDS

        public double GetAverageGpuPriceForAPerson(int customerId)
        {
            return this.repo.Read(customerId).BoughtCards.Average(x => x.BasePrice) ?? -1;
        }

        public IEnumerable<KeyValuePair<string, int>> GetMostOwnedGpuCustomers()
        {
            //return from c in this.repo.ReadAll()
            //       let max = this.repo.ReadAll().Max(c => c.BoughtCards.ToArray().Length)
            //       where c.BoughtCards.Count() >= max
            //       select new KeyValuePair<string, int>(c.Name, c.BoughtCards.Count());

            //Újra írva a Controller miatt
            var q = from c in this.repo.ReadAll()
                    orderby c.BoughtCards.Count() descending
                    select new KeyValuePair<string, int>(c.Name, (int)(c.BoughtCards.Count()));

            return q.Take(1);
        }

        public IEnumerable<KeyValuePair<string, int>> GetOwnersOrderedByNumOfGpus()
        {
            //var q = from x in this.repo.ReadAll()
            //        orderby x.BoughtCards.Count() descending
            //        group x by x.Name into g
            //        select new KeyValuePair<string, int>(g.Key, g.Sum(x => x.BoughtCards.Count()));

            //Újra írva a Controller miatt
            var q = from x in this.repo.ReadAll()
                    orderby x.BoughtCards.Count() descending
                    select new KeyValuePair<string, int>(x.Name, (int)(x.BoughtCards.Count()));

            return q;
        }

        public IEnumerable<KeyValuePair<string, int>> GetLowestValueSpentCustomer()
        {
            var q = from x in this.repo.ReadAll()
                    orderby x.BoughtCards.Sum(gpu => gpu.BasePrice) ascending
                    select new KeyValuePair<string, int>(x.Name, x.BoughtCards.Sum(gpu => gpu.BasePrice) ?? 0);

            return q.Take(1);
        }

        public IEnumerable<KeyValuePair<string, int>> GetHighestValueSpentCustomer()
        {
            var q = from x in this.repo.ReadAll()
                    orderby x.BoughtCards.Sum(gpu => gpu.BasePrice) descending
                    select new KeyValuePair<string, int>(x.Name, x.BoughtCards.Sum(gpu => gpu.BasePrice) ?? 0);

            return q.Take(1);
        }

    }
}
