using System.Collections.Generic;

namespace Tables
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Group Group { get; set; }
        public virtual ICollection<Test> Tests { get; set; }
        public virtual ICollection<Result> Results { get; set; }

        public User()
        {
            Tests = new List<Test>();
            Results = new List<Result>();
        }

        public override string ToString() => Login;
    }
}
