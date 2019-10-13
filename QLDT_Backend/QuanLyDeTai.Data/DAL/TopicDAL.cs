using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuanLyDeTai.Data.DAL
{
    public class TopicDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public IQueryable GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       where d.ID == id && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                       select new
                       {
                           ID=d.ID,
                           TopicName = d.TopicName,
                           Description = d.Description,
                           Status = d.Status,
                           SemesterID = t.SemesterID,
                           PracticeID = t.PracticeID,
                           FieldID=d.FieldID
                       };
            return user;
        }

        public Topic ChangeStatus(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.ID == id)
                .FirstOrDefault();
            user.Status = !user.Status;
            context.SaveChanges();
            return user;
        }

        public IEnumerable<Topic> GetByTT(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.PracticeTypeID == id)
                .ToList();
            return user;
        }

        public IQueryable GetListByTT(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt && d.TeacherID != id_gv && d.TopicName.Contains(search) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && (x.IsDeleted == false || x.IsDeleted.Equals(null))
                       select new
                       {
                           d.ID,
                           d.TopicName,
                           d.Description,
                           d.Status,
                           x.FirstName,
                           x.LastName,
                           a.FieldName
                       };
            return user.OrderBy(a => a.FieldName).Skip(pageNumber * pageSize).Take(pageSize);
        }

        public int GetListByTTCount(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt && d.TeacherID != id_gv && d.TopicName.Contains(search) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && (x.IsDeleted == false || x.IsDeleted.Equals(null))
                       select new
                       {
                           d.ID,
                           d.TopicName,
                           d.Description,
                           d.Status,
                           x.FirstName,
                           x.LastName,
                           a.FieldName
                       };
            return user.Count();
        }


        public IQueryable GetListByTTAll(long? id_tt,long? id_bm, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt && (x.FirstName.Contains(search)|| x.LastName.Contains(search)) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && (x.IsDeleted == false || x.IsDeleted.Equals(null))&&x.SubjectID==id_bm
                       select new
                       {
                           d.ID,
                           d.TopicName,
                           d.Description,
                           d.Status,
                           x.FirstName,
                           x.LastName,
                           a.FieldName
                       };
            return user.OrderBy(a => a.LastName).Skip(pageNumber * pageSize).Take(pageSize);
        }

        public int GetListByTTAllCount(long? id_tt, long? id_bm, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt && (x.FirstName.Contains(search) || x.LastName.Contains(search)) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && (x.IsDeleted == false || x.IsDeleted.Equals(null)) && x.SubjectID == id_bm
                       select new
                       {
                           d.ID,
                           d.TopicName,
                           d.Description,
                           d.Status,
                           x.FirstName,
                           x.LastName,
                           a.FieldName
                       };
            return user.Count();
        }

        public IQueryable GetListByTTAndSubjectId(long? id_tt,long? id_gv, long? id_bm, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt &&d.TeacherID!=id_gv && d.TopicName.Contains(search) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && x.SubjectID == id_bm && (x.IsDeleted == false || x.IsDeleted.Equals(null))
                        select new
                        {
                            d.ID,
                            d.TopicName,
                            d.Description,
                            d.Status,
                            x.FirstName,
                            x.LastName,
                            a.FieldName
                        };
            return user.OrderBy(a=>a.FieldName).Skip(pageNumber * pageSize).Take(pageSize);
        }

        public int GetListByTTAndSubjectIdCount(long? id_tt, long? id_gv, long? id_bm, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = from d in context.Topics
                       join t in context.PracticeTypes on d.PracticeTypeID equals t.ID
                       join x in context.Teachers on d.TeacherID equals x.ID
                       join a in context.Fields on d.FieldID equals a.ID
                       where d.PracticeTypeID == id_tt && d.TeacherID != id_gv && d.TopicName.Contains(search) && (d.IsDeleted == false || d.IsDeleted.Equals(null))
                        && x.SubjectID == id_bm && (x.IsDeleted == false || x.IsDeleted.Equals(null))
                       select new
                       {
                           d.ID,
                           d.TopicName,
                           d.Description,
                           d.Status,
                           x.FirstName,
                           x.LastName,
                           a.FieldName
                       };
            return user.Count();
        }


        public IQueryable GetListByTTvaMaGV1(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Include(i => i.Field)
                .Where(i => i.PracticeTypeID == id_tt && i.TopicName.Contains(search) && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .OrderBy(i => i.Field.FieldName)
                .Skip(pageNumber * pageSize).Take(pageSize)
                .Select(i => new { i.ID, i.TopicName, i.Description, i.Status, i.Field.FieldName });
            return user;
            //context.Configuration.ProxyCreationEnabled = false;
            ////Get from database
            //var user = context.Topics
            //    .Where(i => i.PracticeTypeID == id_tt && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            //    .ToList();
            //return user;
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt,long? id_gv,long? fieldId,string search,int pageNumber,int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            
            var user = context.Topics.Include("Field")
            //.Include(i => i.Field)
            .Where(i => i.PracticeTypeID == id_tt && i.FieldID == fieldId && i.TopicName.Contains(search) && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            .Select(i=>new { i.ID,i.TopicName,i.Description,i.Field.FieldName})

            .OrderBy(i => i.ID)
            .Skip(pageNumber * pageSize).Take(pageSize);
            //context.Configuration.ProxyCreationEnabled = false;
            ////Get from database
            //var user = context.Topics
            //    .Where(i => i.PracticeTypeID == id_tt && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            //    .ToList();
            return user;
        }

        public IEnumerable<Topic> GetListByTTvaMaGV2(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database

            var user = context.Topics
            //.Include(i => i.Field)
            .Where(i => i.PracticeTypeID == id_tt && i.TopicName.Contains(search) && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            
            .OrderBy(i => i.ID)
            .Skip(pageNumber * pageSize).Take(pageSize).ToList();
            //context.Configuration.ProxyCreationEnabled = false;
            ////Get from database
            //var user = context.Topics
            //    .Where(i => i.PracticeTypeID == id_tt && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            //    .ToList();
            return user;
        }

        public IQueryable GetListByTTvaMaGV(long? id_tt, long? id_gv, string search, int pageNumber, int pageSize)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database

            var user = context.Topics.Include("Field")
            //.Include(i => i.Field)
            .Where(i => i.PracticeTypeID == id_tt && i.TopicName.Contains(search) && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            .Select(i => new { i.ID, i.TopicName, i.Description, i.Field.FieldName })
            .OrderBy(i => i.ID)
            .Skip(pageNumber * pageSize).Take(pageSize);
            //context.Configuration.ProxyCreationEnabled = false;
            ////Get from database
            //var user = context.Topics
            //    .Where(i => i.PracticeTypeID == id_tt && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
            //    .ToList();
            return user;
        }


        public int getCount(long? id_tt, long? id_gv,string search)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.Topics
                .Where(i => i.PracticeTypeID == id_tt && i.TopicName.Contains(search) && i.TeacherID == id_gv && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
                .Count();
            return user;
        }

        public IEnumerable<Topic> GetList(long ID)
        {
            var post = context.Topics
                .Where(i => i.TeacherID == ID && (i.IsDeleted == false || i.IsDeleted.Equals(null)))
               .ToList();
            return post;
        }
        

        public bool Update(Topic model)
        {
            try
            {
                //Get item user with Id from database
                var item = context.Topics.Where(i => i.ID == model.ID).FirstOrDefault();

                //Set value item with value from model

                item.PracticeTypeID = model.PracticeTypeID;
                item.FieldID = model.FieldID;
                item.TopicName = model.TopicName;
                item.Description = model.Description;
                item.Status = model.Status;
                

                //Save change to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Topic model)
        {
            try
            {
                //Initialization empty item
                var item = new Topic();

                //Set value for item with value from model
                item.TeacherID = model.TeacherID;
                item.PracticeTypeID = model.PracticeTypeID;
                item.FieldID = model.FieldID;
                item.TopicName = model.TopicName;
                item.Description = model.Description;
                item.Status = model.Status;

                //Add item to entity
                context.Topics.Add(item);
                //Save to database
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                //Tương tự update
                var item = context.Topics.Where(i => i.ID == id).FirstOrDefault();

                //Remove item.

                item.IsDeleted = true;

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
