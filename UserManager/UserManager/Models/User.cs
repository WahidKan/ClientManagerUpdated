using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
   public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }

    }
}
