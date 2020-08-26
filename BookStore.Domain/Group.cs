using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Group : Entity
    {
        public string GroupName { get; set; }


        public virtual ICollection<User> Users { get; set; }
    }
}
