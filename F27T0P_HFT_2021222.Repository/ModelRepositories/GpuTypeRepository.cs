using F27T0P_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Repository.ModelRepositories
{
    public class GpuTypeRepository : Repository<GpuType>, IRepository<GpuType>
    {
        public GpuTypeRepository(GpuCustomerDbContext ctx) : base(ctx)
        {
        }

        public override GpuType Read(int id)
        {
            return ctx.GpuTypes.FirstOrDefault(gpu => gpu.Id == id);
        }

        public override void Update(GpuType item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
