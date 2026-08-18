using Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Drawing;
using System.Collections.Generic;

namespace mvc.Models
{
    public class ITIContext : DbContext
    {
        public ITIContext(DbContextOptions<ITIContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }

}
