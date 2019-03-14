using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Storage_Ovn11.Models
{
    public class ProductSearchViewModel
    {
        public List<SelectListItem> Products { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public int CategoryId { get; set; }
        public string SearchString { get; set; }

        public List<Product> ProductsResult { get; set; }
    }
}
