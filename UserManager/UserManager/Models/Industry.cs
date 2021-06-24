using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManager.Models
{
    public class Industry
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Industry_Name { get; set; }
    }
}
