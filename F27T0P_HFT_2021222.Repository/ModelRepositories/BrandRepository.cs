using F27T0P_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Repository.ModelRepositories
{
    public class BrandRepository : Repository<Brand>, IRepository<Brand>
    {
        public BrandRepository(GpuCustomerDbContext ctx) : base(ctx)
        {
        }

        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(b => b.Id == id);
        }

        public override void Update(Brand item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
