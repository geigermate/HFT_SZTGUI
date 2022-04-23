﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected GpuCustomerDbContext ctx;

        public Repository(GpuCustomerDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public IQueryable<T> Readall()
        {
            return ctx.Set<T>();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
        }

        public abstract T Read(int id);

        public abstract void Update(T item);
    }
}