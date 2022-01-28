using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestDb.ApplicationCore;

namespace TestDb.PublicApi.Models
{
    public class ProductUpdateBindingTarget
    {
        [Required]
        public Guid Id { get; set; } 

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}