using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Models
{
    public class Brand
    {
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual GpuType GpuType { get; set; }

        [ForeignKey(nameof(GpuType))]
        public int GpuTypeId { get; set; }
    }
}
