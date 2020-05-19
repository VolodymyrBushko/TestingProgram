using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Context : DbContext
    {
        public Context(string connect)
            :base(connect)
        {
        }

        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Result> Results { get; set; }
    }
}
