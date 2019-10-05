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
        private FacultyService facultyService = new FacultyService();
        private FieldService fieldService = new FieldService();
        private TeacherService teacherService = new TeacherService();
        private PracticeService practiceService = new PracticeService();
        private StudentService studentService = new StudentService();
        private StudentPracticeService studentPracticeService = new StudentPracticeService();
        private TopicStudentService topicStudentService = new TopicStudentService();
        // GET: StudentPractice
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetByKHvaLoaiTT(long IDHK, long IDTT,string masv,string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = studentPracticeService.getListByPracticeTypeIdCount(thuctap.ID, masv, studentname);
            var listst = studentPracticeService.getListByPracticeTypeIdSort(thuctap.ID, masv, studentname, pageNumber, pageSize);
            
            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return Json(new { TotalRecords = total, List = listst }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByKHvaLoaiTTByTeacher(long IDHK, long IDTT, string masv, string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var thuctap = practiceService.GetByLoaiTTvaHocKy(IDTT, IDHK);
            var total = studentPracticeService.getListByPracticeTypeIdAndTeacherIdCount(thuctap.ID, id_gv, masv, studentname);
            var listst = studentPracticeService.getListByPracticeTypeIdAndTeacherIdSort(thuctap.ID, id_gv, masv, studentname, pageNumber, pageSize);
            var list = new List<StudentModel>();
            foreach (var i in listst)
            {
                var listField = fieldService.GetByStudentId(i.ID);
                var field = "";
                for (var j = 0; j < listField.Count(); j++)
                {
                    if (j == listField.Count() - 1)
                    {
                        field += listField[j];
                    }
                    else
                    {
                        field += listField[j] + ",";
                    }
                }
                var faculty = facultyService.GetById(i.FacultyID).FacultyName;
                var student = new StudentModel
                {
                    Faculty=faculty,
                    Masv = i.MaSV,
                    FieldName = field,
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
            var check = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            if (check == null)
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
            return Json("Loại thực tập này đã có trong kì học", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetbyID(int ID)
        {
            return Json(studentPracticeService.GetById(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(long PracticeID, long SemesterID, long ID,string Masv)
        {
            StudentPracticeRelationship studentPractice = new StudentPracticeRelationship();
            studentPractice.StudentID = studentService.GetByMasv(Masv).ID;
            long id_gv = long.Parse(Session["UserId"].ToString());
            studentPractice.ModifyBy = id_gv;
            studentPractice.ID = ID;
            var tt = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            studentPractice.PracticeTypeID = tt.ID;
            return Json(studentPracticeService.Update(studentPractice), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            var checkChooseTopic = topicStudentService.GetByStudentPracticeIdNoCheckStatus(id);
            if (checkChooseTopic != null)
            {
                return Json("Sinh viên này đã có đề tài. Không thể xóa !", JsonRequestBehavior.AllowGet);
            }
            return Json(studentPracticeService.Delete(id,id_gv), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteChoose(List<int> list)
        {
            long id_gv = long.Parse(Session["UserId"].ToString());
            int dem = 0;
            foreach(var i in list)
            {
                var checkChooseTopic = topicStudentService.GetByStudentPracticeIdNoCheckStatus(i);
                if (checkChooseTopic != null)
                {
                    dem++;
                }
                else
                {
                    studentPracticeService.Delete(i, id_gv);
                }
            }
            return Json(dem, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAll(long PracticeID, long SemesterID)
        {
            var thuctap = practiceService.GetByLoaiTTvaHocKy(PracticeID, SemesterID);
            var practiceTypeId = thuctap.ID;
            long id_gv = long.Parse(Session["UserId"].ToString());
            var studentpractice = studentPracticeService.getListByPracticeTypeId(practiceTypeId);
            if (studentpractice.Count() == 0)
            {
                return Json("Không có sinh viên nào trong kì thực tập này !", JsonRequestBehavior.AllowGet);
            }
            else
            {
                foreach (var s in studentpractice)
                {
                    var checkChooseTopic = topicStudentService.GetByStudentPracticeIdNoCheckStatus(s.ID);
                    if (checkChooseTopic != null)
                    {
                        return Json("Các sinh viên này đã có đề tài. Không thể xóa !", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return Json(studentPracticeService.DeleteAll(practiceTypeId, id_gv), JsonRequestBehavior.AllowGet);
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
                            var dem = "";
                            var error = new List<StudentModel>();
                            for (int rowIterator = 5; rowIterator <= noOfRows; rowIterator++)
                            {

                                var student = new StudentPracticeRelationship();
                                if (workSheet.Cells[rowIterator, 4].Value == null)
                                {

                                    var s = new StudentModel()
                                    {
                                        Masv = "",
                                        FullName = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                        Birthday = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                        ClassBC = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                        Error = "Mã sv trống"
                                    };
                                    error.Add(s);
                                }
                                else
                                {
                                    masv = workSheet.Cells[rowIterator, 4].Value.ToString();
                                    var studentGetDatabase = studentService.GetByMasv(masv);
                                    var studentPractice = studentPracticeService.GetBySinhVienvaKieuTT(studentGetDatabase.ID, practiceTypeId);
                                    if (studentGetDatabase == null)
                                    {
                                        var s = new StudentModel()
                                        {
                                            Masv = masv,
                                            FullName = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                            Birthday = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                            ClassBC = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                            Error = "Không tìm thấy sinh viên này"
                                        };
                                        error.Add(s);
                                    }
                                    else if (studentPractice != null)
                                    {
                                        var s = new StudentModel()
                                        {
                                            Masv = masv,
                                            FullName = workSheet.Cells[rowIterator, 2].Value.ToString(),
                                            Birthday = workSheet.Cells[rowIterator, 3].Value.ToString(),
                                            ClassBC = workSheet.Cells[rowIterator, 5].Value.ToString(),
                                            Error = "Sinh viên này đã thực tập trong kì này"
                                        };
                                        error.Add(s);
                                    }
                                    else
                                    {
                                        student.StudentID = studentGetDatabase.ID;

                                        student.PracticeTypeID = practiceTypeId;

                                        student.CreateBy = long.Parse(Session["UserId"].ToString());

                                        studentPracticeService.Create(student);
                                    }

                                }
                            }
                            foreach (var item in error)
                            {
                                if (item.Error == null)
                                {
                                    error.Remove(item);
                                }
                            }
                            if (error.Count > 0)
                            {
                                ExportError(error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.error = "Thêm mới dữ liệu không thành công";
                return View("Index");
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
                FullName = "Đinh Thị Thu Thủy",
                ClassBC = "K56K4D480201",
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
            Response.AddHeader("Content-Disposition", "attachment; filename=StudentPracticeDemo.xlsx");
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
            worksheet.DefaultColWidth = 5;
            worksheet.Cells[4, 6].AutoFitColumns(5);
            //gộp hàng
            worksheet.Cells["A1:T1"].Merge = true;
            worksheet.Cells["A2:T2"].Merge = true;
            worksheet.Cells["A3:B3"].Merge = true;
            worksheet.Cells["C3:D3"].Merge = true;
            //căn giữa
            worksheet.Cells["A1:T2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //thiếp lập font và cỡ chữ
            worksheet.Cells["A1:T2"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH SINH VIÊN THỰC TẬP";
            worksheet.Cells[2, 1].Value = "Thực tập cơ sở ngành KS CNTT(118)_01_TT";
            worksheet.Cells["A3:T3"].Style.Font.SetFromFont(new Font("Times New Roman", 10));
            worksheet.Cells[3, 1].Value = "Thời gian học :";
            worksheet.Cells[3, 2].Value = "17/12/2018 - 06/01/2019";
            // Tự động xuống hàng khi text quá dài
            //worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[4, 1].Value = "STT";
            worksheet.Cells[4, 2].Value = "Họ tên";
            worksheet.Cells[4, 3].Value = "Ngày sinh";
            worksheet.Cells[4, 4].Value = "Mã SV";
            worksheet.Cells[4, 5].Value = "Lớp BC";
            worksheet.Cells[4, 6].Value = "T1";
            worksheet.Cells[4, 7].Value = "T2";
            worksheet.Cells[4, 8].Value = "T3";
            worksheet.Cells[4, 9].Value = "T4";
            worksheet.Cells[4, 10].Value = "T5";
            worksheet.Cells[4, 11].Value = "T6";
            worksheet.Cells[4, 12].Value = "T7";
            worksheet.Cells[4, 13].Value = "T8";
            worksheet.Cells[4, 14].Value = "T9";
            worksheet.Cells[4, 15].Value = "T10";
            worksheet.Cells[4, 16].Value = "T11";
            worksheet.Cells[4, 17].Value = "T12";
            worksheet.Cells[4, 18].Value = "T13";
            worksheet.Cells[4, 19].Value = "T14";
            worksheet.Cells[4, 20].Value = "T15";
            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
            using (var range = worksheet.Cells["A3:T4"])
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
                worksheet.Cells[i + 5, 2].Value = student.FullName;
                worksheet.Cells[i + 5, 3].Value = student.Birthday;
                worksheet.Cells[i + 5, 4].Value = student.Masv;
                worksheet.Cells[i + 5, 5].Value = student.ClassBC;
                worksheet.Cells[i + 5, 6].Value = "";
                worksheet.Cells[i + 5, 7].Value = "";
                worksheet.Cells[i + 5, 8].Value = "";
                worksheet.Cells[i + 5, 9].Value = "";
                worksheet.Cells[i + 5, 10].Value = "";
                worksheet.Cells[i + 5, 11].Value = "";
                worksheet.Cells[i + 5, 12].Value = "";
                worksheet.Cells[i + 5, 13].Value = "";
                worksheet.Cells[i + 5, 14].Value = "";
                worksheet.Cells[i + 5, 15].Value = "";
                worksheet.Cells[i + 5, 16].Value = "";
                worksheet.Cells[i + 5, 17].Value = "";
                worksheet.Cells[i + 5, 18].Value = "";
                worksheet.Cells[i + 5, 19].Value = "";
                worksheet.Cells[i + 5, 20].Value = "";


            }
            // fix lại width của column 
            worksheet.Cells.AutoFitColumns();
        }



        private Stream CreateExcelFileError(List<StudentModel> studentModels,Stream stream = null)
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
                workSheet.Cells[1, 1].LoadFromCollection(studentModels, false);
                BindingFormatForExcelError(workSheet, studentModels);
                excelPackage.Save();
                return excelPackage.Stream;
            }
        }
        
        public ActionResult ExportError(List<StudentModel> studentModels)
        {
            // Gọi lại hàm để tạo file excel
            var stream = CreateExcelFileError(studentModels);
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
            // Redirect về luôn trang index <img draggable="false" class="emoji" alt="😀" src="https://s0.wp.com/wp-content/mu-plugins/wpcom-smileys/twemoji/2/svg/1f600.svg">
            return RedirectToAction("ListStudent");
        }

        private void BindingFormatForExcelError(ExcelWorksheet worksheet, List<StudentModel> listItems)
        {
            // Set default width cho tất cả column
            worksheet.DefaultColWidth = 5;
            worksheet.Cells[4, 6].AutoFitColumns(5);
            //gộp hàng
            worksheet.Cells["A1:T1"].Merge = true;
            worksheet.Cells["A2:T2"].Merge = true;
            worksheet.Cells["A3:B3"].Merge = true;
            worksheet.Cells["C3:D3"].Merge = true;
            //căn giữa
            worksheet.Cells["A1:T2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            //thiếp lập font và cỡ chữ
            worksheet.Cells["A1:T2"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH SINH VIÊN THỰC TẬP";
            worksheet.Cells[2, 1].Value = "Thực tập cơ sở ngành KS CNTT(118)_01_TT";
            worksheet.Cells["A3:T3"].Style.Font.SetFromFont(new Font("Times New Roman", 10));
            worksheet.Cells[3, 1].Value = "Thời gian học :";
            worksheet.Cells[3, 2].Value = "17/12/2018 - 06/01/2019";
            // Tự động xuống hàng khi text quá dài
            //worksheet.Cells.Style.WrapText = true;
            // Tạo header
            worksheet.Cells[4, 1].Value = "STT";
            worksheet.Cells[4, 2].Value = "Họ tên";
            worksheet.Cells[4, 3].Value = "Ngày sinh";
            worksheet.Cells[4, 4].Value = "Mã SV";
            worksheet.Cells[4, 5].Value = "Lớp BC";
            worksheet.Cells[4, 6].Value = "T1";
            worksheet.Cells[4, 7].Value = "T2";
            worksheet.Cells[4, 8].Value = "T3";
            worksheet.Cells[4, 9].Value = "T4";
            worksheet.Cells[4, 10].Value = "T5";
            worksheet.Cells[4, 11].Value = "T6";
            worksheet.Cells[4, 12].Value = "T7";
            worksheet.Cells[4, 13].Value = "T8";
            worksheet.Cells[4, 14].Value = "T9";
            worksheet.Cells[4, 15].Value = "T10";
            worksheet.Cells[4, 16].Value = "T11";
            worksheet.Cells[4, 17].Value = "T12";
            worksheet.Cells[4, 18].Value = "T13";
            worksheet.Cells[4, 19].Value = "T14";
            worksheet.Cells[4, 20].Value = "T15";
            worksheet.Cells[4, 21].Value = "Lỗi";
            using (var range = worksheet.Cells["E3:L4"])
            {
                range.Value = "";
            }
            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới D1
                using (var range = worksheet.Cells["A3:T4"])
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
                worksheet.Cells[i + 5, 2].Value = student.FullName;
                worksheet.Cells[i + 5, 3].Value = student.Birthday;
                worksheet.Cells[i + 5, 4].Value = student.Masv;
                worksheet.Cells[i + 5, 5].Value = student.ClassBC;
                worksheet.Cells[i + 5, 6].Value = "";
                worksheet.Cells[i + 5, 7].Value = "";
                worksheet.Cells[i + 5, 8].Value = "";
                worksheet.Cells[i + 5, 9].Value = "";
                worksheet.Cells[i + 5, 10].Value = "";
                worksheet.Cells[i + 5, 11].Value = "";
                worksheet.Cells[i + 5, 12].Value = "";
                worksheet.Cells[i + 5, 13].Value = "";
                worksheet.Cells[i + 5, 14].Value = "";
                worksheet.Cells[i + 5, 15].Value = "";
                worksheet.Cells[i + 5, 16].Value = "";
                worksheet.Cells[i + 5, 17].Value = "";
                worksheet.Cells[i + 5, 18].Value = "";
                worksheet.Cells[i + 5, 19].Value = "";
                worksheet.Cells[i + 5, 20].Value = "";
                worksheet.Cells[i + 5, 20].Value = "";
                worksheet.Cells[i + 5, 21].Value = student.Error;

            }
            // fix lại width của column 
            worksheet.Cells.AutoFitColumns();
        }
    }
}
