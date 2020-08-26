using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BookStore.Domain
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int GroupId { get; set; }

        public virtual ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();

        public virtual Group Group{ get; set; }

       
    }
}
