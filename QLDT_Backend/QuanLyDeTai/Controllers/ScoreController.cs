using OfficeOpenXml;
using OfficeOpenXml.Style;
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
                            for (int rowIterator = 5; rowIterator <= noOfRows; rowIterator++)
                            {
                                var score = new ScoreModel();
                                if (workSheet.Cells[rowIterator, 2].Value == null)
                                {
                                    masv = "";
                                }
                                else
                                {
                                    if (workSheet.Cells[rowIterator, 5].Value == null)
                                    {
                                        score.CompanyScore = null;
                                    }
                                    else
                                    {
                                        score.CompanyScore = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value.ToString());
                                    }
                                    if (workSheet.Cells[rowIterator, 6].Value == null)
                                    {
                                        score.TeacherScore = null;
                                    }
                                    else
                                    {
                                        score.TeacherScore = Convert.ToDouble(workSheet.Cells[rowIterator, 6].Value.ToString());
                                    }
                                    if (workSheet.Cells[rowIterator, 7].Value == null)
                                    {
                                        score.ReportScore = null;
                                    }
                                    else
                                    {
                                        score.ReportScore = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value.ToString());
                                    }
                                    if (workSheet.Cells[rowIterator, 8].Value == null)
                                    {
                                        score.TotalScore = null;
                                    }
                                    else
                                    {
                                        score.TotalScore = Convert.ToInt32(workSheet.Cells[rowIterator, 8].Value.ToString());
                                    }
                                    masv = workSheet.Cells[rowIterator, 2].Value.ToString();
                                    var studentpracticeid = studentPracticeService.GetBySinhVienvaKieuTT(studentService.GetByMasv(masv).ID, practiceTypeId);
                                    var topicstudent = topicStudentService.GetByStudentPracticeId(studentpracticeid.ID);
                                    score.PracticeTypeID = practiceTypeId;
                                    score.TopicStudentID = topicstudent.ID;
                                    score.CreateBy = long.Parse(Session["UserId"].ToString());
                                    var sc = score.ToModel();
                                    scoreService.Create(score.ToModel());
                                }
                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Thêm mới dữ liệu không thành công";
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
                TeacherScore=9,
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
            Response.AddHeader("Content-Disposition", "attachment; filename=StudentPracticeDemo.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            // Redirect về luôn trang index <img draggable="false" class="emoji" alt="😀" src="https://s0.wp.com/wp-content/mu-plugins/wpcom-smileys/twemoji/2/svg/1f600.svg">
            return RedirectToAction("ListScore");
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<ScoreModel> listItems)
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


            }
            // fix lại width của column 
            worksheet.Cells.AutoFitColumns();
        }

    }
}