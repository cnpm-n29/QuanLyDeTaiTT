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
    public class SinhVienService
    {
        public SinhVien LoginByCredential(string masv, string password)
        {
            SinhVienDAL sinhVienDAL = new SinhVienDAL();

            if (string.IsNullOrEmpty(masv) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var sv = sinhVienDAL.GetByMasv(masv);
            if (sv == null)
            {
                return null;
            }

            var passwordSalt = sv.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == sv.MatKhau)
            {
                return sv;
            }
            else
            {
                return null;
            }
        }
    }
}
