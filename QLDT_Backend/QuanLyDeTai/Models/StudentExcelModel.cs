using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class StudentExcelModel
    {
        public long ID { get; set; }

        public string Masv { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool? Sex { get; set; }

        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
        
        public string Note { get; set; }
    }
}