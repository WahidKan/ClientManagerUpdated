using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManager.Models
{
    public class Client
    {
        public int ID { get; set; }
        public int Industry_ID { get; set; }
        public string Client_Name { get; set; }
        public string? Client_Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public int? Contact_Number { get; set; }
        public string? Email { get; set; }
    }
}
