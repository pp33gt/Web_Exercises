using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Storage_Ovn11.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required, MaxLength(20), MinLength(3)]
        public string Name { get; set; }
        public int Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public string Category { get; set; }
        public string Shelf { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
    }
}
