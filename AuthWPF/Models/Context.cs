using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthWPF.Models
{
    public class Context:DbContext
    {
        public Context()
            : base("name=Context") { }
        public DbSet<User> users { get; set; }
    }
}
