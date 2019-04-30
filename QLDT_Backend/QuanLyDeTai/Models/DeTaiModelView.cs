using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDeTai.Models
{
    public class DeTaiModelView
    {

        public DeTaiModel deTaiModel { get; set; }

        public IEnumerable<DeTaiModel> listDeTaiModels { get; set; }

    }
}