using System.Collections.Generic;

namespace Tables
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public Group() => Users = new List<User>();

        public override string ToString() => Title;
    }
}
