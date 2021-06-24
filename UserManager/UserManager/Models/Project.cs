using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
    public class Project
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int Client_ID { get; set; }
        public string Project_Name { get; set; }
        public DateTime? Date_Of_Signing { get; set; }
    }
}
