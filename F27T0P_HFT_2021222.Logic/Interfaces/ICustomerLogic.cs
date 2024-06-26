﻿using F27T0P_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Logic.Interfaces
{
    public interface ICustomerLogic
    {
        void Create(Customer item);
        void Delete(int id);
        Customer Read(int id);
        IQueryable<Customer> ReadAll();
        void Update(Customer item);

        double GetAverageGpuPriceForAPerson(int customerId);

        IEnumerable<KeyValuePair<string, int>> GetMostOwnedGpuCustomers();

        IEnumerable<KeyValuePair<string, int>> GetOwnersOrderedByNumOfGpus();

        IEnumerable<KeyValuePair<string, int>> GetLowestValueSpentCustomer();

        IEnumerable<KeyValuePair<string, int>> GetHighestValueSpentCustomer();
    }
}
