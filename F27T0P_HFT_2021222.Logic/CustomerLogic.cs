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
    }
}
