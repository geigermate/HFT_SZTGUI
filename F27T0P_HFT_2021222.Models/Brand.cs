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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual List<GpuType> GpuTypes { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

    }
}
