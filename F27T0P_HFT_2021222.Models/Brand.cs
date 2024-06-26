﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace F27T0P_HFT_2021222.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; } //Itt simán csak Id volt ezért a JSClientbe nem tudta betölteni a megfelelő mezőket...

        [MaxLength(50)]
        [Required]
        public string BrandName { get; set; } //Itt simán csak név volt, átnevezés után működik...

        [NotMapped]
        [JsonIgnore]
        public virtual GpuType GpuType { get; set; }

        [ForeignKey(nameof(GpuType))]
        public int GpuTypeId { get; set; }
    }
}
