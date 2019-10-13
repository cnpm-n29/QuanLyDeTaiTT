using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyDeTai.Data.Entities;

namespace QuanLyDeTai.Data.DAL
{
    public class ReportDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public Teacher getListByStudentPractice(long studentPracticeId)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from s in context.StudentPracticeRelationships
                       join r in context.Reports on s.ID equals r.StudentPracticeID
                       join t in context.Teachers on r.TeacherID equals t.ID
                       where r.StudentPracticeID==studentPracticeId &&(t.IsDeleted==false || t.IsDeleted.Equals(null))&&(t.IsDeleted == false || t.IsDeleted.Equals(null))
                       select t;

            return user.FirstOrDefault();
        }


        public bool Update(Report model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Reports.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model
                item.StudentPracticeID = model.StudentPracticeID;
                item.TeacherID = model.TeacherID;
                item.ModifyBy = model.ModifyBy;
                item.ModifyTime = DateTime.Now;
                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Report model)
        {
            try
            {
                //Initialization empty item
                var item = new Report();

                //Set value for item with value from model
                item.StudentPracticeID = model.StudentPracticeID;
                item.TeacherID = model.TeacherID;
                item.CreateBy = model.CreateBy;
                item.CreateTime = DateTime.Now;
                //Add item to entity
                context.Reports.Add(item);
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
                var item = context.Reports.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;
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
