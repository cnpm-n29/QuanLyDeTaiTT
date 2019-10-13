using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class StudentModel
    {
        public StudentModel()
        {

        }

        public StudentModel(Student model)
        {
            ID = model.ID;
            Masv = model.MaSV;
            FirstName = model.FirstName;
            LastName = model.LastName;
            Sex = model.Sex;
            Birthday = model.Birthday.ToString();
            Address = model.Address;
            Email = model.Email;
            Phone = model.Phone;
            Note = model.Note;
        }

        public Student ToModel()
        {
            
            var st = new Student
            {
                ID = ID,
                MaSV = Masv,
                FirstName = FirstName,
                LastName = LastName,
                Sex = Sex,
                Birthday = DateTime.ParseExact(Birthday, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                Address = Address,
                Email = Email,
                Phone = Phone,
                FacultyID = FacultyId,
                Note = Note,
                CreateBy = CreateBy,
                ModifiedBy=ModifiedBy
            };
            return st;
        }

        public Student ToModelNoBirthday()
        {

            var st = new Student
            {
                ID = ID,
                MaSV = Masv,
                FirstName = FirstName,
                LastName = LastName,
                Sex = Sex,
                Birthday = null,
                Address = Address,
                Email = Email,
                Phone = Phone,
                FacultyID = FacultyId,
                Note = Note,
                CreateBy = CreateBy,
                ModifiedBy = ModifiedBy
            };
            return st;
        }


        public long ID { get; set; }
        

        public string Masv { get; set; }

        public long? FacultyId { get; set; }

        public string FieldName { get; set; }

        public string TeacherName { get; set; }

        public string FullName { get; set; }

        public string ClassBC { get; set; }

        public string Error { get; set; }

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

        public long? StudentPracticeID { get; set; }

        public string Faculty { get; set; }
    }

}