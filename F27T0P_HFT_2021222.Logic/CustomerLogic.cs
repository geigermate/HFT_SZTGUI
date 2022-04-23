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
    public class CustomerLogic : ICustomerLogic
    {
        IRepository<Customer> repo;

        public CustomerLogic(IRepository<Customer> repo)
        {
            this.repo = repo;
        }

        public void Create(Customer item)
        {
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
            return this.repo.Read(id);
        }

        public IQueryable<Customer> ReadAll()
        {
            return this.repo.ReadAll();
        }


        //NON-CRUD

        public IEnumerable<Customer> GetMostOwnedGpuCustomers()
        {
            return (IEnumerable<Customer>)(from x in this.repo.ReadAll()
                   where x.BoughtCards.Count() >= 2
                   select x.Name);
        }

        public IEnumerable<Customer> GetOwnersOrderedByNumOfGpus()
        {
            return (IEnumerable<Customer>)(from x in this.repo.ReadAll()
                                           orderby x.BoughtCards.Count() descending
                                           group x by x.Name into g
                                           select new 
                                           {
                                               Name = g.Key,
                                               NumOfGpus = g.Sum(x => x.BoughtCards.Count())
                                           });
        }

        public IEnumerable<Customer> GetLowestValueSpentCustomer()
        {
            return (IEnumerable<Customer>)(from x in this.repo.ReadAll()
                                           group x by x.BoughtCards.Sum(gpu => gpu.BasePrice) into g
                                           orderby g.Key ascending
                                           select g.Take(1));
                   
        }

        public IEnumerable<Customer> GetHighestValueSpentCustomer()
        {
            return (IEnumerable<Customer>)(from x in this.repo.ReadAll()
                   group x by x.BoughtCards.Sum(gpu => gpu.BasePrice) into g
                   orderby g.Key descending
                   select new RichCustomer()
                   {
                       Name = (this.repo.ReadAll().Select(x => x.Name)).ToString(),
                       AllGpuValue = (int)g.Key
                   });
        }

        public class RichCustomer
        {
            public string Name { get; set; }
            public int AllGpuValue { get; set; }
        }
    }
}
