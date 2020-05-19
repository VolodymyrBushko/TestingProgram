using System;

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

        public override string ToString() => Rating.ToString();
    }
}
