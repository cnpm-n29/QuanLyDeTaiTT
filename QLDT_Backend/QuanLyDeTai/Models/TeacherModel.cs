using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class TeacherModel
    {
        public long ID { get; set; }
        
        public string MaGV { get; set; }

        public long? SubjectID { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public bool? Sex { get; set; }
        
        public string Birthday { get; set; }
        
        public string Address { get; set; }
        
        public string Email { get; set; }
        
        public string Phone { get; set; }
        
        public string Password { get; set; }
        
        public string PasswordSalt { get; set; }

        public long? CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedTime { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedTime { get; set; }
        
        public string Note { get; set; }
    }
}