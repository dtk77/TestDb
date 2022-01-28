using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TestDb.ApplicationCore
{
    public class Product : BaseEntity
    {


        public string Name { get; set; }

        public string Description { get; set; }


        public void UpdateDetails(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}



