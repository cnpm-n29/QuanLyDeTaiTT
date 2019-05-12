using QuanLyDeTai.Core;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class TeacherDAL
    {
        private DefaultDbContent context = new DefaultDbContent();

        public Teacher GetByMagv(string magv)
        {
            //Get from database
            var user = context.Teachers
                .Where(i => i.MaGV == magv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .FirstOrDefault();
            return user;
        }
        
        
        
        public bool Update(Teacher model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Teachers.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.MaGV = model.MaGV;
                item.SubjectID = model.SubjectID;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.Birthday = model.Birthday;
                item.Address = model.Address;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.Password = PasswordHash.EncryptionPasswordWithSalt(model.Password, PasswordHash.GeneratePasswordSalt());
                item.ModifiedBy = model.ModifiedBy;
                item.ModifiedTime = DateTime.Now;
                item.Note = model.Note;

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Teacher model)
        {
            try
            {
                //Initialization empty item
                var item = new Teacher();

                //Set value for item with value from model
                item.MaGV = model.MaGV;
                item.SubjectID = model.SubjectID;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Sex = model.Sex;
                item.Birthday = model.Birthday;
                item.Address = model.Address;
                item.Email = model.Email;
                item.Phone = model.Phone;
                item.PasswordSalt = PasswordHash.GeneratePasswordSalt();
                item.Password = PasswordHash.EncryptionPasswordWithSalt(model.Password, PasswordHash.GeneratePasswordSalt());
                item.CreateBy = model.ModifiedBy;
                item.CreateTime = DateTime.Now;
                item.Note = model.Note;

                //Add item to entity
                context.Teachers.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id, long person)
        {
            try
            {
                //Tương tự update
                var item = context.Teachers.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
                item.DeletedBy = person;
                item.DeletedTime = DateTime.Now;

                //Change database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
