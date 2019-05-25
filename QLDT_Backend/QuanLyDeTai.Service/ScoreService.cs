using QuanLyDeTai.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class ScoreService
    {
        private ScoreDAL scoreDAL = new ScoreDAL();
        public Object GetBySinhvienAndLoaiTT(long idltt, long idsv)
        {
            return scoreDAL.GetBySinhvienAndLoaiTT(idltt,idsv);
        }
     }
}
