using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string? Designation { get; set; }
        public int? Contact_Number { get; set; }
    }
}
