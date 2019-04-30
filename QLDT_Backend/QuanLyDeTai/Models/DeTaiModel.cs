using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class DeTaiModel
    {
        public long ID { get; set; }

        public long? ID_GiangVien { get; set; }

        public long? ID_ThucTap { get; set; }

        public long? ID_HocKy { get; set; }

        public long? ID_LoaiTT { get; set; }

        [StringLength(500)]
        public string TenDeTai { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public bool TrangThai { get; set; }
        
    }
}