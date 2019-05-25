using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using QuanLyDeTai.Models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using QuanLyDeTai.Service;
using QuanLyDeTai.Data.Entities;

namespace QuanLyDeTai.Controllers
{
    public class StudentPracticeController : BaseController
    {
        private PracticeService practiceService = new PracticeService();
        private StudentService studentService = new StudentService();
        private StudentPracticeService studentPracticeService = new StudentPracticeService();
        // GET: StudentPractice
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT,string masv,string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = studentPracticeService.getListByPracticeTypeIdCount(thuctap.ID,masv,studentname);
            var listst = studentPracticeService.getListByPracticeTypeIdSort(thuctap.ID, masv, studentname, pageNumber, pageSize);
            var list = new List<StudentModel>();
            foreach (var i in listst)
            {
                var student = new StudentModel
                {
                    Masv = i.MaSV,
                    FirstName = i.FirstName,
                    LastName = i.LastName,
                    Birthday = i.Birthday.Value.Day + "/" + i.Birthday.Value.Month + "/" + i.Birthday.Value.Year,
                    Sex = i.Sex,
                    Email = i.Email,
                    Phone = i.Phone,
                    Address = i.Address,
                    Note = i.Note
                };
                list.Add(student);
            }
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPractice(long PracticeID, long SemesterID)
        {
            var practice = new PracticeType
            {
                PracticeID = PracticeID,
                SemesterID = SemesterID
            };
            bool status = practiceService.Create(practice);
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(status, JsonRequestBehavior.AllowGet);
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

                        var suppleirList = new List<StudentPracticeRelationship>();

                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.Single();
                            var noOfColumns = workSheet.Dimension.End.Column;
                            var noOfRows = workSheet.Dimension.End.Row;// Here is where my issue is
                            var masv = "";
                            for (int rowIterator = 5; rowIterator <= noOfRows; rowIterator++)
                            {
                                var student = new StudentPracticeRelationship();
                                if (workSheet.Cells[rowIterator, 5].Value == null)
                                {
                                    masv = "";
                                }
                                else
                                {
                                    masv = workSheet.Cells[rowIterator, 5].Value.ToString();
                                    student.StudentID = studentService.GetByMasv(masv).ID;
                                    student.PracticeTypeID = practiceTypeId;
                                    studentPracticeService.Create(student);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Thêm mới dữ liệu không thành công";
            }
            return View("Index");
        }



        private Stream CreateExcelFile(Stream stream = null)
        {
            var resultsList = new List<StudentModel>();
            var student = new StudentModel()
            {
                Masv = "155D4802010023",
                Address = "Nghệ An",
                FirstName = "Đinh Thị Thu ",
                LastName = "Thủy",
                Sex = true,
                Birthday = "21/05/1997",
                Email = "dinhthithuthuy2105@gmail.com",
                Phone = "1233456789"
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
                workSheet.Cells[1, 1].LoadFromCollection(resultsList, false);
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
            Response.AddHeader("Content-Disposition", "attachment; filename=ExcelDemo.xlsx");
            // Lưu file excel của chúng ta như 1 mảng byte để trả về response
            Response.BinaryWrite(buffer.ToArray());
            // Send tất cả ouput bytes về phía clients
            Response.Flush();
            Response.End();
            // Redirect về luôn trang index <img draggable="false" class="emoji" alt="😀" src="https://s0.wp.com/wp-content/mu-plugins/wpcom-smileys/twemoji/2/svg/1f600.svg">
            return RedirectToAction("ListStudent");
        }

        private void BindingFormatForExcel(ExcelWorksheet worksheet, List<StudentModel> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 10;
            // Tự động xuống hàng khi text quá dài
            worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[1, 1].Value = "STT";
            worksheet.Cells[1, 2].Value = "Mã SV";
            worksheet.Cells[1, 3].Value = "Họ";
            worksheet.Cells[1, 4].Value = "Tên";
            worksheet.Cells[1, 5].Value = "Ngày sinh";
            worksheet.Cells[1, 6].Value = "Giới tính";
            worksheet.Cells[1, 7].Value = "Số điện thoại";
            worksheet.Cells[1, 8].Value = "Email";
            worksheet.Cells[1, 9].Value = "Địa chỉ";
            worksheet.Cells[1, 10].Value = "Ghi chú";

            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A1:J1"])
            {

                // Canh giữa cho các text
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // Set Font cho text  trong Range hiện tại
                range.Style.Font.SetFromFont(new Font("Arial", 10));
                range.Style.Font.Bold = true;
                // Set Border
                range.Style.Border.Bottom.Style = ExcelBorderStyle.Thick;
            }

            // Đỗ dữ liệu từ list vào 
            for (int i = 0; i < listItems.Count; i++)
            {
                var student = listItems[i];
                worksheet.Cells[i + 2, 1].Value = (i + 1).ToString();
                worksheet.Cells[i + 2, 2].Value = student.Masv;
                worksheet.Cells[i + 2, 3].Value = student.FirstName;
                worksheet.Cells[i + 2, 4].Value = student.LastName;
                worksheet.Cells[i + 2, 5].Value = student.Birthday;
                if (student.Sex == true)
                {
                    worksheet.Cells[i + 2, 6].Value = "Nữ";
                }
                else
                {
                    worksheet.Cells[i + 2, 6].Value = "Nam";
                }
                worksheet.Cells[i + 2, 7].Value = student.Phone;
                worksheet.Cells[i + 2, 8].Value = student.Email;
                worksheet.Cells[i + 2, 9].Value = student.Address;
                worksheet.Cells[i + 2, 10].Value = student.Note;


            }
            // fix lại width của column với minimum width là 15
            worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);
        }
    }
}