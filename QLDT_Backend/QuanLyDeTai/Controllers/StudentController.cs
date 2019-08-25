using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using QuanLyDeTai.Data.Entities;
using QuanLyDeTai.Models;
using QuanLyDeTai.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDeTai.Controllers
{
    public class StudentController : BaseController
    {
        private TeacherService teacherService = new TeacherService();
        private StudentService studentService = new StudentService();
        private FacultyService facultyService = new FacultyService();
        private StudentFieldService studentFieldService = new StudentFieldService();
        private FieldService fieldService = new FieldService();
        // GET: Student
        public ActionResult ListStudentSubject()
        {
            return View();
        }

        public ActionResult ListStudentTeacher()
        {
            return View();
        }

        public ActionResult ListStudent()
        {
            var result = facultyService.GetAllFaculty();
            
            // Tạo SelectList
            SelectList facultyList = new SelectList(result, "ID", "FacultyName");

            // Set vào ViewBag
            ViewBag.CategoryList = facultyList;
            return View();
        }

        public JsonResult GetListBySubjectIdAndFacultyId(long facultyId, string masv, string studentname, int pageNumber = 0, int pageSize = 10)
        {
            var tc = teacherService.GetByMagv(Session["Username"].ToString());
            var total = studentService.getListBySubjectIdAndFacultyIdCount(tc.SubjectID, facultyId,masv,studentname);
            var listtc = studentService.getListBySubjectIdAndFacultyIdSort(tc.SubjectID,facultyId,masv,studentname, pageNumber, pageSize);
            var list = new List<StudentModel>();
            foreach (var i in listtc)
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

        public JsonResult GetListByTeacherIdAndFacultyId(long facultyId, string masv, string studentname, int pageNumber = 0, int pageSize = 10)
        {
            long teacherId= long.Parse(Session["UserId"].ToString());
            var total = studentService.getListByTeacherIdAndFacultyIdCount(teacherId, facultyId,masv,studentname);
            var listtc = studentService.getListByTeacherIdAndFacultyIdSort(teacherId, facultyId, masv, studentname, pageNumber, pageSize);
            var list = new List<StudentModel>();
            foreach (var i in listtc)
            {
                var listField = fieldService.GetByStudentId(i.ID);
                var field = "";
                for (var j=0;j<listField.Count();j++)
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
                var student = new StudentModel
                {
                    Masv = i.MaSV,
                    FieldName=field,
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

        public JsonResult GetListByFacultyId(long facultyId,string masv,string studentname, int pageNumber = 0, int pageSize = 10)
        {
            var tc = teacherService.GetByMagv(Session["Username"].ToString());
            var total = studentService.getListByFacultyIdCount(facultyId,masv,studentname);
            var listtc = studentService.getListByFacultyIdSort(facultyId,masv,studentname,pageNumber,pageSize);
            var list = new List<StudentModel>();
            foreach (var i in listtc)
            {
                var student = new StudentModel
                {
                    ID=i.ID,
                    FacultyId=i.FacultyID,
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

        public JsonResult GetbyID(int ID)
        {
            var i = studentService.GetById(ID);
            var month="";
            var day="";

            if (i.Birthday.Value.Month < 10)
            {
                 month = "0" + i.Birthday.Value.Month;
            }
            else
            {
                day = i.Birthday.Value.Month.ToString();
            }
            if (i.Birthday.Value.Day < 10)
            {
                 day = "0" + i.Birthday.Value.Day;
            }
            else
            {
                day = i.Birthday.Value.Day.ToString();
            }
            var student = new StudentModel
            {
                ID = i.ID,
                FacultyId = i.FacultyID,
                Masv = i.MaSV,
                FirstName = i.FirstName,
                LastName = i.LastName,
                Birthday = i.Birthday.Value.Year + "-" + month + "-" + day,
                Sex = i.Sex,
                Email = i.Email,
                Phone = i.Phone,
                Address = i.Address,
                Note = i.Note
            };
            return Json(student, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Add(StudentModel model)
        {
            model.CreateBy= long.Parse(Session["UserId"].ToString());
            bool status = studentService.Create(model.ToModel());
            
            return Json(status, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Update(StudentModel model)
        {
            model.ModifiedBy= long.Parse(Session["UserId"].ToString());
            var st = new Student
            {
                ID = model.ID,
                MaSV = model.Masv,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Sex = model.Sex,
                Birthday = Convert.ToDateTime(model.Birthday),
                Address = model.Address,
                Email = model.Email,
                Phone = model.Phone,
                FacultyID = model.FacultyId,
                Note = model.Note,
                CreateBy = model.CreateBy,
                ModifiedBy = model.ModifiedBy
            };
            bool status = studentService.Update(st);

            return Json(status, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(long id)
        {
            return Json(studentService.Delete(id, long.Parse(Session["UserId"].ToString())), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Upload(string FacultyId)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                if ((file != null && file.ContentLength > 0 && !string.IsNullOrEmpty(file.FileName)))
                {
                    string fileName = file.FileName;
                    string fileContentType = file.ContentType;
                    byte[] filebytes = new byte[file.ContentLength];
                    var data = file.InputStream.Read(filebytes, 0, Convert.ToInt32(file.ContentLength));

                    var suppleirList = new List<StudentModel>();

                    using (var package = new ExcelPackage(file.InputStream))
                    {
                        var currentSheet = package.Workbook.Worksheets;
                        var workSheet = currentSheet.First();
                        var noOfColumns = workSheet.Dimension.End.Column;
                        var noOfRows = workSheet.Dimension.End.Row;// Here is where my issue is

                        for (int rowIterator = 4; rowIterator <= noOfRows; rowIterator++)
                        {
                            var student = new StudentModel();
                            if (workSheet.Cells[rowIterator, 2].Value == null)
                            {
                                student.Masv = "";
                            }
                            else
                            {
                                student.Masv = workSheet.Cells[rowIterator, 2].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 3].Value == null)
                            {
                                student.FirstName = "";
                            }
                            else
                            {
                                student.FirstName = workSheet.Cells[rowIterator, 3].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 4].Value == null)
                            {
                                student.LastName = "";
                            }
                            else
                            {
                                student.LastName = workSheet.Cells[rowIterator, 4].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 5].Value == null)
                            {
                                student.Birthday = "";
                            }
                            else
                            {
                                student.Birthday = workSheet.Cells[rowIterator, 5].Value.ToString().Trim();
                            }
                            if (workSheet.Cells[rowIterator, 6].Value.ToString() == "Nữ")
                            {
                                student.Sex = true;
                            }
                            else if (workSheet.Cells[rowIterator, 6].Value.ToString() == "Nam")
                            {
                                student.Sex = false;
                            }
                            else
                            {
                                student.Sex = null;
                            }
                            if (workSheet.Cells[rowIterator, 7].Value == null)
                            {
                                student.Phone  = "";
                            }
                            else
                            {
                                student.Phone = workSheet.Cells[rowIterator, 7].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 8].Value == null)
                            {
                                student.Email = "";
                            }
                            else
                            {
                                student.Email = workSheet.Cells[rowIterator, 8].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 9].Value == null)
                            {
                                student.Address = ""; ;
                            }
                            else
                            {
                                student.Address = workSheet.Cells[rowIterator, 9].Value.ToString();
                            }
                            if (workSheet.Cells[rowIterator, 10].Value == null)
                            {
                                student.Note = "";
                            }
                            else
                            {
                                student.Note = workSheet.Cells[rowIterator, 10].Value.ToString();
                            }
                            student.FacultyId = Convert.ToInt32(FacultyId);
                            student.CreateBy= long.Parse(Session["UserId"].ToString());
                            bool state;
                            try
                            {
                                var st = student.ToModel();
                                state = true;
                            }
                            catch
                            {
                                state = false;
                            }
                            if (state)
                            {
                                bool status = studentService.Create(student.ToModel());

                                suppleirList.Add(student);
                            }
                        }



                    }
                }
            }
            return View("ListStudent");
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
                Sex=true,
                Birthday= "21/05/1997",
                Email="dinhthithuthuy2105@gmail.com",
                Phone="1233456789"
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
            worksheet.Cells["A1:J1"].Merge = true;
            worksheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A1:J1"].Style.Font.SetFromFont(new Font("Times New Roman", 14));
            worksheet.Cells[1, 1].Value = "DANH SÁCH SINH VIÊN";
            // Tạo header
            worksheet.Cells[3, 1].Value = "STT";
            worksheet.Cells[3, 2].Value = "Mã SV";
            worksheet.Cells[3, 3].Value = "Họ";
            worksheet.Cells[3, 4].Value = "Tên";
            worksheet.Cells[3, 5].Value = "Ngày sinh";
            worksheet.Cells[3, 6].Value = "Giới tính";
            worksheet.Cells[3, 7].Value = "Số điện thoại";
            worksheet.Cells[3, 8].Value = "Email";
            worksheet.Cells[3, 9].Value = "Địa chỉ";
            worksheet.Cells[3, 10].Value = "Ghi chú";

            // Lấy range vào tạo format cho range đó ở đây là từ A1 tới J1
           
            using (var range = worksheet.Cells["A2:J3"])
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
                worksheet.Cells[i + 4, 1].Value = (i + 1).ToString();
                worksheet.Cells[i + 4, 2].Value = student.Masv;
                worksheet.Cells[i + 4, 3].Value = student.FirstName;
                worksheet.Cells[i + 4, 4].Value = student.LastName;
                worksheet.Cells[i + 4, 5].Value = student.Birthday;
                if (student.Sex == true)
                {
                    worksheet.Cells[i + 4, 6].Value = "Nữ";
                }
                else
                {
                    worksheet.Cells[i + 4, 6].Value = "Nam";
                }
                worksheet.Cells[i + 4, 7].Value = student.Phone;
                worksheet.Cells[i + 4, 8].Value = student.Email;
                worksheet.Cells[i + 4, 9].Value = student.Address;
                worksheet.Cells[i + 4, 10].Value = student.Note;
            

            }
            // fix lại width của column với minimum width là 15
            worksheet.Cells[1, 1, listItems.Count + 5, 4].AutoFitColumns(15);
        }
    }
}
