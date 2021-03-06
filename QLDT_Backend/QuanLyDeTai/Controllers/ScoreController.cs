﻿using OfficeOpenXml;
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
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class ScoreController : Controller
    {
        private PracticeService practiceService = new PracticeService();
        private StudentPracticeService studentPracticeService = new StudentPracticeService();
        private StudentService studentService = new StudentService();
        private ScoreService scoreService = new ScoreService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        // GET: Score
        public ActionResult StudentScore()
        {
            return View();
        }

        public ActionResult ListScore()
        {
            ViewBag.active = "ListScore";
            return View();
        }

        public JsonResult GetByThucTap(long IDTT)
        {
            long idsv = long.Parse(Session["UserId"].ToString());
            var svtt = scoreService.GetBySinhvienAndLoaiTT(IDTT,idsv);
            if (svtt==null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json(svtt, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT, string masv, string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = scoreService.getListByPracticeTypeIdCount(thuctap.ID, masv, studentname);
            var list = scoreService.getListByPracticeTypeIdSort(thuctap.ID, masv, studentname, pageNumber, pageSize);
          
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Create(long PracticeID, long SemesterID, float Score,long Id)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            var check = scoreService.GetByTopicStudent(Id);

            if (check != null)
            {
                Score score = new Score
                {
                    ID = check.ID,
                    TopicStudentID = Id,
                    PracticeTypeID = thuctap.ID,
                    TeacherScore = Score,
                    ModifyBy=id_gv
                };
                return Json(scoreService.UpdateNewScore(score), JsonRequestBehavior.AllowGet);
            }
            else
            {
                Score score = new Score
                {
                    TopicStudentID = Id,
                    PracticeTypeID = thuctap.ID,
                    TeacherScore = Score,
                    CreateBy = id_gv

                };
                return Json(scoreService.CreateNewScore(score), JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult CheckFalse(long Id)
        {
            var check = scoreService.GetByTopicStudent(Id);
            if (check == null)
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
            return Json(scoreService.Delete(check.ID, long.Parse(Session["UserId"].ToString())), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            var score = scoreService.GetById(ID);
            return Json(score, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ScoreModel model)
        {
            model.ModifyBy = long.Parse(Session["UserId"].ToString());
            
            bool status = scoreService.Update(model.ToModel());

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            return Json(scoreService.DeleteOldScore(id, long.Parse(Session["UserId"].ToString())), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAll(long PracticeID, long SemesterID)
        {
            var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            var practiceTypeId = thuctap.ID;
            long id_gv = long.Parse(Session["UserId"].ToString());
            var score = scoreService.getListByPracticeTypeIdAll(practiceTypeId);
            if (score.Count() == 0)
            {
                return Json("Chưa có sinh viên nào có điểm trong kì thực tập này !", JsonRequestBehavior.AllowGet);
            }
            
            return Json(scoreService.DeleteAll(practiceTypeId, id_gv), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Upload(long PracticeID, long SemesterID)
        {
            try
            {
                var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
                var practiceTypeId = thuctap.ID;
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];
                    if ((file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName)))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] filebytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(filebytes, 0, Convert.ToInt32(file.ContentLength));

                        var suppleirList = new List<ScoreModel>();

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.Single();
                            var noOfColumns = workSheet.Dimension.End.Column;
                            var noOfRows = workSheet.Dimension.End.Row;// Here is where my issue is
                            var masv = "";
                            var dem = 0;
                            var resultsList = new List<ScoreModel>();
                            if (workSheet.Cells[4, 1].Value.ToString().ToLower().Equals("stt") && workSheet.Cells[4, 2].Value.ToString().ToLower().Equals("mã sv")
                                && workSheet.Cells[4, 3].Value.ToString().ToLower().Equals("họ tên") && workSheet.Cells[4, 4].Value.ToString().ToLower().Equals("tên đề tài")
                                && workSheet.Cells[4, 5].Value.ToString().ToLower().Equals("điểm công ty") && workSheet.Cells[4, 6].Value.ToString().ToLower().Equals("điểm báo cáo")
                                && workSheet.Cells[4, 7].Value.ToString().ToLower().Equals("điểm tổng"))
                            {
                                for (int rowIterator = 5; rowIterator <= noOfRows; rowIterator++)
                                {
                                    var score = new ScoreModel();
                                    dem = 0;
                                    if (workSheet.Cells[rowIterator, 2].Value == null)
                                    {
                                        masv = "";
                                        score.MaSV = "";
                                        score.FullName = workSheet.Cells[rowIterator, 3].Value.ToString();
                                        score.TopicName = workSheet.Cells[rowIterator, 4].Value.ToString();
                                        if (workSheet.Cells[rowIterator, 5].Value == null)
                                        {
                                            score.CompanyScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.CompanyScore = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value.ToString());
                                        }
                                        if (workSheet.Cells[rowIterator, 6].Value == null)
                                        {
                                            score.TeacherScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.TeacherScore = Convert.ToDouble(workSheet.Cells[rowIterator, 6].Value.ToString());
                                        }
                                        if (workSheet.Cells[rowIterator, 7].Value == null)
                                        {
                                            score.ReportScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.ReportScore = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value.ToString());
                                        }
                                        if (workSheet.Cells[rowIterator, 8].Value == null)
                                        {
                                            score.TotalScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.TotalScore = Convert.ToDouble(workSheet.Cells[rowIterator, 8].Value.ToString());
                                        }
                                        if (dem == 0)
                                        {
                                            score.Error = "Mã sv không được để trống";
                                        }
                                        else
                                        {
                                            score.Error = "Mã sv không được để trống, Các điểm số không được để trống";
                                        }
                                        resultsList.Add(score);
                                    }
                                    else
                                    {
                                        score.MaSV = workSheet.Cells[rowIterator, 2].Value.ToString();
                                        score.FullName = workSheet.Cells[rowIterator, 3].Value.ToString();
                                        score.TopicName = workSheet.Cells[rowIterator, 4].Value.ToString();
                                        if (workSheet.Cells[rowIterator, 5].Value == null)
                                        {
                                            score.CompanyScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.CompanyScore = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value.ToString());
                                        }

                                        if (workSheet.Cells[rowIterator, 6].Value == null)
                                        {
                                            score.ReportScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.ReportScore = Convert.ToDouble(workSheet.Cells[rowIterator, 6].Value.ToString());
                                        }
                                        if (workSheet.Cells[rowIterator, 7].Value == null)
                                        {
                                            score.TotalScore = null;
                                            dem++;
                                        }
                                        else
                                        {
                                            score.TotalScore = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value.ToString());
                                        }
                                        if (dem != 0)
                                        {

                                            score.Error = "Các điểm số không được để trống";
                                        }
                                        else
                                        {
                                            masv = workSheet.Cells[rowIterator, 2].Value.ToString();
                                            var studentGetDatabase = studentService.GetByMasv(masv);
                                            if (studentGetDatabase == null)
                                            {
                                                score.Error = "Không tìm thấy sinh viên này";
                                            }
                                            else
                                            {
                                                var studentpracticeid = studentPracticeService.GetBySinhVienvaKieuTT(studentService.GetByMasv(masv).ID, practiceTypeId);
                                                if (studentpracticeid == null)
                                                {
                                                    score.Error = "Sinh viên chưa thực tập trong kì này";
                                                }
                                                else
                                                {
                                                    var topicstudent = topicStudentService.GetByStudentPracticeId(studentpracticeid.ID);
                                                    score.PracticeTypeID = practiceTypeId;
                                                    score.TopicStudentID = topicstudent.ID;
                                                    score.ModifyBy = long.Parse(Session["UserId"].ToString());
                                                    score.ID = scoreService.GetByTopicStudent2(topicstudent.ID).ID;
                                                    if (scoreService.GetByTopicStudent2(topicstudent.ID) == null)
                                                    {
                                                        score.Error = "Sinh viên này chưa được xét đạt và chưa có điểm GVHD";
                                                    }
                                                    else
                                                    {
                                                        var sc = score.ToModel();
                                                        scoreService.UpdateOldScore(score.ToModel());
                                                    }

                                                }
                                            }
                                        }
                                        resultsList.Add(score);
                                    }


                                }
                                foreach (var item in resultsList)
                                {
                                    if (item.Error == null)
                                    {
                                        resultsList.Remove(item);
                                    }
                                }
                                if (resultsList.Count > 0)
                                {
                                    ExportError(resultsList);
                                }
                            }
                            else
                            {
                                ViewBag.excel = "Không đúng định dạng excel mẫu";
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.excel = "Thêm mới dữ liệu không thành công";
                return RedirectToAction("ListScore");
            }
            return RedirectToAction("ListScore");
        }



        private Stream CreateExcelFile(Stream stream = null)
        {
            var resultsList = new List<ScoreModel>();
            var student = new ScoreModel()
            {
                MaSV = "155D4802010023",
                FirstName = "Đinh Thị Thu ",
                LastName = "Thủy",
                TopicName="",
                CompanyScore=9,
                ReportScore= 8.5,
                TotalScore=9

            };
            resultsList.Add(student);


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
                //workSheet.Cells[1, 1].LoadFromCollection(resultsList, false);
                BindingFormatForExcel(workSheet, resultsList);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }

        [HttpGet]
        public ActionResult Export()
        {
            // Gọi lại hàm để tạo file excel
            var stream = CreateExcelFile();
            // Tạo buffer memory strean để hứng file excel
            var buffer = stream as MemoryStream;
            // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            // Dòng này rất quan trọng, vì chạy trên firefox hay IE thì dòng này sẽ hiện Save As dialog cho người dùng chọn thư mục để lưu
            // File name của Excel này là ExcelDemo
            Response.AddHeader("Content-Disposition", "attachment; filename=ScoreDemo.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            // Redirect về luôn trang index 
            return RedirectToAction("ListScore");
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<ScoreModel> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 5;
            worksheet.Cells[4, 6].AutoFitColumns(5);
            //gộp hàng
            worksheet.Cells["A1:G1"].Merge = true;
            worksheet.Cells["A2:G2"].Merge = true;
            worksheet.Cells["A3:B3"].Merge = true;
            worksheet.Cells["C3:D3"].Merge = true;
            //căn giữa
            worksheet.Cells["A1:G2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //thiếp lập font và cỡ chữ
            worksheet.Cells["A1:G2"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH ĐIỂM THỰC TẬP";
            worksheet.Cells[2, 1].Value = "Thực tập cơ sở ngành KS CNTT(118)_01_TT";
            worksheet.Cells["A3:G3"].Style.Font.SetFromFont(new Font("Times New Roman", 10));
            worksheet.Cells[3, 1].Value = "Thời gian học :";
            worksheet.Cells[3, 3].Value = "17/12/2018 - 06/01/2019";
            // Tự động xuống hàng khi text quá dài
            //worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[4, 1].Value = "STT";
            worksheet.Cells[4, 2].Value = "Mã SV";
            worksheet.Cells[4, 3].Value = "Họ tên";
            worksheet.Cells[4, 4].Value = "Tên đề tài";
            worksheet.Cells[4, 5].Value = "Điểm công ty";
            worksheet.Cells[4, 6].Value = "Điểm báo cáo";
            worksheet.Cells[4, 7].Value = "Điểm tổng";
            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A3:G4"])
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
            for (int i = 0; i < listItems.Count; i++)
            {
                var student = listItems[i];
                worksheet.Cells[i + 5, 1].Value = (i + 1).ToString();
                worksheet.Cells[i + 5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 5, 2].Value = student.MaSV;
                worksheet.Cells[i + 5, 3].Value = student.FirstName + " " + student.LastName;
                worksheet.Cells[i + 5, 4].Value = student.TopicName;
                worksheet.Cells[i + 5, 5].Value = student.CompanyScore;
                worksheet.Cells[i + 5, 6].Value = student.ReportScore;
                worksheet.Cells[i + 5, 7].Value = student.TotalScore;


            }
            // fix lại width của column 
            worksheet.Cells.AutoFitColumns();
        }


        private Stream CreateExcelFileError(List<ScoreModel> resultsList, Stream stream = null)
        {

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
                //workSheet.Cells[1, 1].LoadFromCollection(resultsList, false);
                BindingFormatForExcelError(workSheet, resultsList);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }

        [HttpGet]
        public ActionResult ExportError(List<ScoreModel> listItems)
        {
            // Gọi lại hàm để tạo file excel
            var stream = CreateExcelFileError(listItems);
            // Tạo buffer memory strean để hứng file excel
            var buffer = stream as MemoryStream;
            // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            // Dòng này rất quan trọng, vì chạy trên firefox hay IE thì dòng này sẽ hiện Save As dialog cho người dùng chọn thư mục để lưu
            // File name của Excel này là ExcelDemo
            Response.AddHeader("Content-Disposition", "attachment; filename=Error.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            // Redirect về luôn trang index 
            return RedirectToAction("ListScore");
        }

        private void BindingFormatForExcelError(ExcelWorksheet worksheet, List<ScoreModel> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 5;
            worksheet.Cells[4, 6].AutoFitColumns(5);
            //gộp hàng
            worksheet.Cells["A1:H1"].Merge = true;
            worksheet.Cells["A2:H2"].Merge = true;
            worksheet.Cells["A3:B3"].Merge = true;
            worksheet.Cells["C3:D3"].Merge = true;
            //căn giữa
            worksheet.Cells["A1:H2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //thiếp lập font và cỡ chữ
            worksheet.Cells["A1:H2"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH ĐIỂM THỰC TẬP";
            worksheet.Cells[2, 1].Value = "Thực tập cơ sở ngành KS CNTT(118)_01_TT";
            worksheet.Cells["A3:H3"].Style.Font.SetFromFont(new Font("Times New Roman", 10));
            worksheet.Cells[3, 1].Value = "Thời gian học :";
            worksheet.Cells[3, 3].Value = "17/12/2018 - 06/01/2019";
            // Tự động xuống hàng khi text quá dài
            //worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[4, 1].Value = "STT";
            worksheet.Cells[4, 2].Value = "Mã SV";
            worksheet.Cells[4, 3].Value = "Họ tên";
            worksheet.Cells[4, 4].Value = "Tên đề tài";
            worksheet.Cells[4, 5].Value = "Điểm công ty";
            worksheet.Cells[4, 6].Value = "Điểm hướng dẫn";
            worksheet.Cells[4, 7].Value = "Điểm báo cáo";
            worksheet.Cells[4, 8].Value = "Điểm tổng";
            worksheet.Cells[4, 8].Value = "Lỗi";
            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A3:H4"])
            {

                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Times New Roman", 10));
                range.Style.Font.Bold = true;
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            }
            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listItems.Count; i++)
            {
                var student = listItems[i];
                worksheet.Cells[i + 5, 1].Value = (i + 1).ToString();
                worksheet.Cells[i + 5, 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells[i + 5, 2].Value = student.MaSV;
                worksheet.Cells[i + 5, 3].Value = student.FirstName + " " + student.LastName;
                worksheet.Cells[i + 5, 4].Value = student.TopicName;
                worksheet.Cells[i + 5, 5].Value = student.CompanyScore;
                worksheet.Cells[i + 5, 6].Value = student.TeacherScore;
                worksheet.Cells[i + 5, 7].Value = student.ReportScore;
                worksheet.Cells[i + 5, 8].Value = student.TotalScore;

                worksheet.Cells[i + 5, 9].Value = student.Error;
            }
            // fix lại width của column 
            worksheet.Cells.AutoFitColumns();
        }

    }
}