using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Result
    {
        public int Id { get; set; }
        public DateTime Dt { get; set; }
        public int Rating { get; set; }

        public virtual Test Test { get; set; }
        public virtual User User { get; set; }

        public Result() { }
    }
}
