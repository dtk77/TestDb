using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestDb.ApplicationCore;

namespace TestDb.PublicApi.Models
{
    public class ProductBindingTarget
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }


        public Product ToProduct() => new()
        {
            Name = this.Name,
            Description = this.Description,
        };
    }
}
