using Microsoft.Ajax.Utilities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class TopicStudentController : BaseController
    {
        private PracticeService practiceService = new PracticeService();
        private ScoreService scoreService = new ScoreService();
        private TopicService deTaiService = new TopicService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        private StudentPracticeService sinhVienTTService = new StudentPracticeService();
        private StudentTeacherService phanCongGVService = new StudentTeacherService();
        private TeacherService teacherService = new TeacherService();
        StudentFieldService StudentFieldService = new StudentFieldService();
        // GET: DeTaiSinhVienTT
        public ActionResult ChooseTopic()
        {
            
            return View();
        }

        public ActionResult MonitorProgress()
        {
            ViewBag.id = "MonitorProgress";
            return View();
        }

        public JsonResult GetByThucTap(long IDTT, string search, int pageNumber = 0, int pageSize = 10)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
            if (svtt == null)
            {
                return Json(new { TotalRecords = 0, Error = "Chưa được phân thực tập" }, JsonRequestBehavior.AllowGet);
            }
            var status = topicStudentService.CheckTopicUser(svtt.ID);
            var detai = topicStudentService.getTopicChoose(svtt.ID);

            var b = 0;
            foreach(var s in status)
            {
                b++;
            }

            if (status != null && b!=0 && detai == null) {
                return Json(new { TotalRecords = 0, ChooseTopic = status }, JsonRequestBehavior.AllowGet);
            }
            else if (detai != null)
            {
                return Json(new { TotalRecords = 0, Detai = detai }, JsonRequestBehavior.AllowGet);
            }
            var Giangvien = phanCongGVService.GetBySinhVien(idsv);
            if (Giangvien != null && svtt != null)
            {
                long? idgv = Giangvien.TeacherID;
                long? IDLoaiTT = svtt.PracticeTypeID;
                var total = deTaiService.getCount(IDLoaiTT, idgv, search);
                var field = StudentFieldService.GetByStudent(idsv);
                List<object> result=new List<object>();
                IQueryable list= (IQueryable)null;
                if (field.Count==0)
                {
                    list = deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv, search, pageNumber, pageSize);
                    result.Add(list);
                }
                else
                {
                    foreach (var a in field)
                    {
                        var dem = 0;
                        list = deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv, a.FieldID, search, pageNumber, pageSize);
                        foreach(var l in list)
                        {
                            dem++;
                        }
                        if (dem>0)
                        {
                            result.Add(list);
                        }
                        

                    }
                }
                return Json(new { TotalRecords = total, List = result.ToList() }, JsonRequestBehavior.AllowGet);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = 0, Error = "Chưa được phân giảng viên" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listLoaiTT(long? id = null)
        {
            PracticeService thucTapService = new PracticeService();
            return Json(thucTapService.GetAllLoaiTT(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Add(List<TopicStudentModel> list)
        {
            foreach (TopicStudentModel topicStudent in list)
            {
                long id_student = long.Parse(Session["UserId"].ToString());
                var sinhvienTT = sinhVienTTService.GetBySinhVienvaLoaiTT(id_student, topicStudent.SemesterID);
                topicStudent.StudentPracticeID = sinhvienTT.ID;
                var m = new TopicStudent
                {
                    StudentPracticeID = topicStudent.StudentPracticeID,
                    TopicID = topicStudent.TopicID,
                    Order = topicStudent.Order,
                    CreateBy = topicStudent.CreateBy,
                    CreateTime = topicStudent.CreateTime,
                };
                topicStudentService.Create(m);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveTopic()
        {
            ViewBag.id = "SaveTopic";
            return View();
        }

        //public JsonResult GetListByStudentPracticeID(long IDTT)
        //{
        //    long idsv = long.Parse(Session["UserId"].ToString());
        //    var svtt = sinhVienTTService.GetBySinhVienvaLoaiTT(idsv, IDTT);
        //    var Giangvien = phanCongGVService.GetBySinhVien(idsv);
        //    long? idgv = Giangvien.TeacherID;
        //    long? IDLoaiTT = 0;
        //    IDLoaiTT = svtt.ID_TT;
        //    return Json(deTaiService.GetListByTTvaMaGV(IDLoaiTT, idgv), JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetListForSave(long IDHK, long IDTT,string search, int pageNumber=0, int pageSize=100)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = deTaiService.getCount(thuctap.ID, id_gv, search);
            var list = deTaiService.GetListByTTvaMaGV2(thuctap.ID, id_gv, search, pageNumber, pageSize);
            var count=new List<int>();
            IQueryable listStudent;
            for(int i=0;i<list.Count();i++)
            {
                count.Add(topicStudentService.getCount(list.ToArray()[i].ID));
                listStudent = topicStudentService.GetListByTopicId(list.ToArray()[i].ID);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = list,Count=count}, JsonRequestBehavior.AllowGet);
            

        }

        public JsonResult getListByTopicId(long TopicID)
        {
            return Json(topicStudentService.GetListByTopicId(TopicID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckUserChoose(long TopicID)
        {
            long id = long.Parse(Session["UserId"].ToString());
            var a = topicStudentService.GetListByTopicIdNotIncludeUser(TopicID, id);
            return Json(topicStudentService.GetListByTopicIdNotIncludeUser(TopicID,id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ChangeStatus(long id)
        {
            return Json(topicStudentService.ChangeStatus(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT, string search, int pageNumber = 0, int pageSize = 100)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = topicStudentService.GetCount(thuctap.ID, id_gv, search);
            var list = topicStudentService.GetListByTTvaMaGV(thuctap.ID, id_gv, search);
            var resultsList = new List<TopicStudentModel>();
            foreach (var item in list)
            {
                var ID = (long)item.GetType().GetProperty("ID").GetValue(item, null);
                bool? result;
                if (item.GetType().GetProperty("Result").GetValue(item, null) != null)
                {
                    result = (bool)item.GetType().GetProperty("Result").GetValue(item, null);
                }
                else
                {
                    result = null;
                }

                var topic = new TopicStudentModel
                {
                    ID = ID,
                    TopicName = (string)item.GetType().GetProperty("TopicName").GetValue(item, null),
                    FirstName = (string)item.GetType().GetProperty("FirstName").GetValue(item, null),
                    LastName = (string)item.GetType().GetProperty("LastName").GetValue(item, null),
                    MaSV = (string)item.GetType().GetProperty("MaSV").GetValue(item, null),

                    Progress = (int)item.GetType().GetProperty("Progress").GetValue(item, null),
                    Result = result


                };
                var check = scoreService.GetByTopicStudent2(ID);
                if (check != null)
                {
                    topic.TeacherScore = check.TeacherScore;
                    
                }
                resultsList.Add(topic);
            }
            

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(resultsList , JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetByKHvaLoaiTT2(long IDHK, long IDTT, string masv,string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            IQueryable listtc = null;
            var total = 0;
            if (teacherService.GetRole(Session["Username"].ToString(), "Trưởng bộ môn"))
            {
                var bomon = teacherService.GetByMagv(Session["Username"].ToString()).SubjectID;
                listtc = topicStudentService.GetListByTTvaBoMon(thuctap.ID, bomon,masv, studentname, pageNumber, pageSize);
                total= topicStudentService.GetListByTTvaBoMonCount(thuctap.ID, bomon, masv, studentname, pageNumber, pageSize);
            }
            else
            {
                listtc = topicStudentService.GetListByTT(thuctap.ID, masv, studentname, pageNumber, pageSize);
                total = topicStudentService.GetListByTTCount(thuctap.ID, masv, studentname, pageNumber, pageSize);
            }
            var resultsList = new List<TopicStudentModel>();
            foreach (var item in listtc)
            {
                var ID = (long)item.GetType().GetProperty("ID").GetValue(item, null);
                bool? result;
                if (item.GetType().GetProperty("Result").GetValue(item, null) != null)
                {
                    result = (bool)item.GetType().GetProperty("Result").GetValue(item, null);
                }
                else
                {
                    result = null;
                }
                var topic = new TopicStudentModel
                {
                    ID = ID,
                    TopicName = (string)item.GetType().GetProperty("TopicName").GetValue(item, null),
                    FirstName = (string)item.GetType().GetProperty("FirstName").GetValue(item, null),
                    LastName = (string)item.GetType().GetProperty("LastName").GetValue(item, null),
                    MaSV = (string)item.GetType().GetProperty("MaSV").GetValue(item, null),
                    TeacherName= (string)item.GetType().GetProperty("TeacherName").GetValue(item, null),
                    Progress = (int)item.GetType().GetProperty("Progress").GetValue(item, null),
                    Result = result

                };
                var check = scoreService.GetByTopicStudent2(ID);
                if (check != null)
                {
                    topic.TeacherScore = check.TeacherScore;

                }
                resultsList.Add(topic);
            }


            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(resultsList, JsonRequestBehavior.AllowGet);


        }

        public JsonResult GetById(long id)
        {
            return Json(topicStudentService.GetById(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Plus(long id,int progress)
        {
            topicStudentService.Plus(id, progress);
            return Json(topicStudentService.GetById(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Result(long id, bool result)
        {

            return Json(topicStudentService.Result(id, result), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Test(long PracticeID, long SemesterID)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            IQueryable List = null;
            var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            if (Session["Quyen"].ToString().Contains("Phân hội đồng chấm thi"))
            {
                var bomon = teacherService.GetByMagv(Session["Username"].ToString()).SubjectID;
                List = topicStudentService.GetListByTTvaBoMon(thuctap.ID, bomon, "", "", 0, 50);

            }
            else if (Session["Quyen"].ToString().Contains("Xem list thực tập"))
            {
                List = topicStudentService.GetListByTT(thuctap.ID, "", "", 0, 50);
            }
            else
            {
                List = topicStudentService.getExport(thuctap.ID, id_gv, "");

            }

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(List, JsonRequestBehavior.AllowGet);


        }


        private Stream CreateExcelFile(long PracticeID, long SemesterID, Stream stream = null)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            IQueryable List = null;
            var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            if (Session["Quyen"].ToString().Contains("Phân hội đồng chấm thi"))
            {
                var bomon = teacherService.GetByMagv(Session["Username"].ToString()).SubjectID;
                List = topicStudentService.GetListByTTvaBoMon(thuctap.ID, bomon, "", "", 0, 50);

            }
            else if (Session["Quyen"].ToString().Contains("Xem list thực tập"))
            {
                List = topicStudentService.GetListByTT(thuctap.ID, "", "", 0, 50);
            }
            else
            {
                List = topicStudentService.getExport(thuctap.ID, id_gv, "");

            }
            var resultsList=new List<TopicStudentModel>();
     
            foreach (var item in List)
            {
                var ID = (long)item.GetType().GetProperty("ID").GetValue(item, null);
                bool? result;
                if (item.GetType().GetProperty("Result").GetValue(item, null) != null)
                {
                    result = (bool)item.GetType().GetProperty("Result").GetValue(item, null);
                }
                else
                {
                    result = null;
                }
                var topic = new TopicStudentModel
                {
                    ID = ID,
                    TopicName = (string)item.GetType().GetProperty("TopicName").GetValue(item, null),
                    FirstName = (string)item.GetType().GetProperty("FirstName").GetValue(item, null),
                    LastName = (string)item.GetType().GetProperty("LastName").GetValue(item, null),
                    MaSV = (string)item.GetType().GetProperty("MaSV").GetValue(item, null),
                    Birthday = (DateTime)item.GetType().GetProperty("Birthday").GetValue(item, null),
                    Progress = (int)item.GetType().GetProperty("Progress").GetValue(item, null),
                    Result = result

                };
                var check = scoreService.GetByTopicStudent2(ID);
                if (check != null)
                {
                    topic.TeacherScore = check.TeacherScore;

                }
                resultsList.Add(topic);
            }

            string practice = practiceService.GetByIdPractice(PracticeID).PracticeName;
            using (var excelPackage = new ExcelPackage(stream ?? new MemoryStream()))
            {
                // Tạo author cho file Excel
                excelPackage.Workbook.Properties.Author = "Hanker";
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "EPP test background";
                // Add Sheet vào file Excel
                excelPackage.Workbook.Worksheets.Add("First Sheet");
                // Lấy Sheet bạn vừa mới tạo ra để thao tác 
                var workSheet = excelPackage.Workbook.Worksheets[1];
                // Đổ data vào Excel file
                workSheet.Cells[1, 1].LoadFromCollection(resultsList, false);
                BindingFormatForExcel(workSheet, resultsList,practice);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }


        [HttpGet]
        public ActionResult Export(long PracticeID, long SemesterID)
        {
            
            try
            {
                string semerter = practiceService.GetByIdSemester(SemesterID).SemesterName;
                string practice = practiceService.GetByIdPractice(PracticeID).PracticeName;
                // Gọi lại hàm để tạo file excel
                var stream = CreateExcelFile(PracticeID, SemesterID);
                // Tạo buffer memory strean để hứng file excel
                var buffer = stream as MemoryStream;
                // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                // Dòng này rất quan trọng, vì chạy trên firefox hay IE thì dòng này sẽ hiện Save As dialog cho người dùng chọn thư mục để lưu
                // File name của Excel này là ExcelDemo
                var filename = practice + "_" + semerter;
                Response.AddHeader("Content-Disposition", "attachment; filename="+filename+".xlsx");
                // Lưu file excel của chúng ta như 1 mảng byte để trả về response
                Response.BinaryWrite(buffer.ToArray());
                // Send tất cả ouput bytes về phía clients
                Response.Flush();
                Response.End();
                // Redirect về luôn trang index <img draggable="false" class="emoji" alt="😀" src="https://s0.wp.com/wp-content/mu-plugins/wpcom-smileys/twemoji/2/svg/1f600.svg">
                return View("MonitorProgress");
            }
            catch(Exception ex)
            {
                return View("MonitorProgress");
            }
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<TopicStudentModel> listItems,string practice)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 5;
            //worksheet.Cells[4, 6].AutoFitColumns(5);
            //gộp hàng
            worksheet.Cells["A1:H1"].Merge = true;
            worksheet.Cells["A2:H2"].Merge = true;
            worksheet.Cells["A3:B3"].Merge = true;
            worksheet.Cells["C3:D3"].Merge = true;
            //căn giữa
            worksheet.Cells["A1:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //thiếp lập font và cỡ chữ
            worksheet.Cells["A1:H2"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH ĐỀ TÀI THỰC TẬP";
            worksheet.Cells[2, 1].Value = practice+" ngành KS CNTT";
            worksheet.Cells["A3:H3"].Style.Font.SetFromFont(new Font("Times New Roman", 10));
            worksheet.Cells[3, 1].Value = "Thời gian học :";
            // Tự động xuống hàng khi text quá dài
            //worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[4, 1].Value = "STT";
            worksheet.Cells[4, 2].Value = "Mã SV";
            worksheet.Cells[4, 3].Value = "Họ tên";
            worksheet.Cells[4, 4].Value = "Ngày sinh";
            worksheet.Cells[4, 5].Value = "Đề tài";
            worksheet.Cells[4, 6].Value = "Tiến độ";
            worksheet.Cells[4, 7].Value = "Kết quả";
            worksheet.Cells[4, 8].Value = "Điểm GVHD";
            using (var range = worksheet.Cells["I1:R"+listItems.Count()])
            {

                range.Value = "";
            }
            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A3:H4"])
            {

                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Times New Roman", 10));
                range.Style.Font.Bold = true;
                // Set Border
                //range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            }
            // Đỗ dữ liệu từ list vào 
            if (listItems.Count() > 0)
            {
                for (int i = 0; i < listItems.Count(); i++)
                {
                    var student = listItems.ToList()[i];
                    worksheet.Cells[i + 5, 1].Value = (i + 1).ToString();
                    worksheet.Cells[i + 5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    worksheet.Cells[i + 5, 2].Value = student.MaSV;
                    worksheet.Cells[i + 5, 3].Value = student.FirstName + " " + student.LastName;
                    worksheet.Cells[i + 5, 4].Value = student.Birthday.ToString();
                    worksheet.Cells[i + 5, 5].Value = student.TopicName;
                    if (student.Progress == 0)
                    {
                        worksheet.Cells[i + 5, 6].Value = "Nhận đề tài";
                    }
                    else if (student.Progress == 1)
                    {
                        worksheet.Cells[i + 5, 6].Value = "BCTD lần 1";
                    }
                    else if (student.Progress == 2)
                    {
                        worksheet.Cells[i + 5, 6].Value = "BCTD lần 2";
                    }
                    if (student.Result == true)
                    {
                        worksheet.Cells[i + 5, 7].Value = "Đạt";
                    }
            else if (student.Result == false)
            {
                        worksheet.Cells[i + 5, 7].Value = "Không đạt";
                    }
            else
            {
                worksheet.Cells[i + 5, 7].Value = "Chưa đánh giá";
            }

                    worksheet.Cells[i + 5, 8].Value = student.TeacherScore;
                }
                // fix lại width của column 
                worksheet.Cells.AutoFitColumns();
            }
        }
    }
}