using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Data.DAL
{
    public class PracticeTypeDAL
    {
        private DefaultDbContext context = new DefaultDbContext();

        public PracticeType GetById(long id)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.PracticeTypes
                .Where(i => i.ID == id )
                .FirstOrDefault();
            return user;
        }

        

        public PracticeType GetByLoaiTTvaHocKy(long? id_loaitt,long? id_hocky)
        {
            context.Configuration.ProxyCreationEnabled = false;
            //Get from database
            var user = context.PracticeTypes
                .Where(i => i.PracticeID == id_loaitt && i.SemesterID==id_hocky)
                .FirstOrDefault();
            return user;
        }

        public IEnumerable<Practice> GetByHocKy( long? id_hocky)
        {
            context.Configuration.ProxyCreationEnabled = false;
            var user = from d in context.PracticeTypes
                       join c in context.Semesters on d.SemesterID equals c.ID
                       join s in context.Practices on d.PracticeID equals s.ID
                       where d.SemesterID == id_hocky
                       select s;
            return user;
        }

        public bool Create(PracticeType model)
        {
            try
            {
                //Initialization empty item
                var item = new PracticeType();

                //Set value for item with value from model
                item.PracticeID = model.PracticeID;
                item.SemesterID = model.SemesterID;

                //Add item to entity
                context.PracticeTypes.Add(item);
                //Save to database
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
