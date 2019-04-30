using QuanLyDeTai.Core;
using QuanLyDeTai.Data.DAL;
using QuanLyDeTai.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDeTai.Service
{
    public class GiangVienService
    {
        public GiangVien LoginByCredential(string magv, string password)
        {
            GiangVienDAL giangVienDAL = new GiangVienDAL();

            if (string.IsNullOrEmpty(magv) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var gv = giangVienDAL.GetByMagv(magv);
            if (gv == null)
            {
                return null;
            }

            var passwordSalt = gv.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == gv.MatKhau)
            {
                return gv;
            }
            else
            {
                return null;
            }
        }

        public IQueryable XetQuyen(long id)
        {
            //List<string> listQuyen = new List<string>();
            //ChucVuGVDAL chucVuGVDAL = new ChucVuGVDAL();
            //Quyen_CVDAL Quyen_CVDAL = new Quyen_CVDAL();
            //QuyenDAL quyen = new QuyenDAL();
            //List<ChucVuGV> chucVus = chucVuGVDAL.GetChucVu(id);

            //foreach (ChucVuGV chucVu in chucVus)
            //{
            //    List<Quyen_CV> quyen_CVs = Quyen_CVDAL.GetChucVu(chucVu.ID_ChucVu);
            //    foreach (Quyen_CV quyen_CV in quyen_CVs)
            //    {
            //        var q = quyen.GetById(quyen_CV.ID_Quyen);
            //        listQuyen.Add(q.Quyen1);
            //    }
            //}
            QuyenDAL quyen = new QuyenDAL();
            IQueryable list = quyen.GetById(id); 
            return list;
        }
    }
}
