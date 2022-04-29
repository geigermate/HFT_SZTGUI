using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Models
{
    public class GpuType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        public int? BasePrice { get; set; }

        [NotMapped]
        public virtual Customer Customer { get; set; }
        
        [NotMapped]
        public virtual ICollection<Brand> Brands { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }

        public GpuType()
        {
            this.Brands = new HashSet<Brand>();
        }
    }
}
