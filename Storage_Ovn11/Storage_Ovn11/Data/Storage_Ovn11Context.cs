using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Storage_Ovn11.Models
{
    public class Storage_Ovn11Context : DbContext
    {
        public Storage_Ovn11Context (DbContextOptions<Storage_Ovn11Context> options)
            : base(options)
        {
        }

        public DbSet<Storage_Ovn11.Models.Product> Product { get; set; }
    }
}
