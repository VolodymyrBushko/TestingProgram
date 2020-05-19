using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Test
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        public DateTime Dt { get; set; }
        public int PassTime { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Result> Results { get; set; }

        public Test() => Results = new List<Result>();
    }
}
