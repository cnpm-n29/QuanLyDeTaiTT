
$(window).on('load', function () {
    getListHocKy();
    getListHocKy1();
    changeDropHocKy1($(".drpHocKy #HocKy").val());
    changeDropHocKy($(".HocKy #HocKy").val());
   
});

//combobox loai hoc ky 

function getListHocKy1() {
    $.ajax({
        url: "/List/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select name="SemesterID" id="HocKy" class="HK form-control" onchange=changeDropHocKy1(this.value)>';
            html += '<option disabled > -- Chọn loại học kỳ -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SemesterName + '</option>';
            });
            html += '</select>'
            $(".ddlHocKy1").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//thay doi dropdown hoc ky
function changeDropHocKy1(IDHK) {
    $.ajax({
        url: "/Topic/GetLoaiTTByHK/" + IDHK,
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select name="PracticeID" class="LTT form-control" id="LoaiTT" >';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';

            });
            html += '</select>'

            $(".ddlLoaiTT1").html(html);
        },


        error: function (errormessage) {

        }
    });
    return false;
}


//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT, masv = "", studentname = "", PgNumber = 0, PgSize = $("#maxRows").val()) {
    var IDHK = $(".HocKy #HocKy").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="10">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.Masv + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.TopicName + '</td>';

                    if (item.CompanyScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.CompanyScore + '</td>';
                    }
                    
                    html += '<td>' + item.TeacherScore + '</td>';
                    if (item.ReportScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.ReportScore + '</td>';
                    }
                    if (item.TotalScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.TotalScore + '</td>';
                    }
                    html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a href="#" onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
                $('.pagination').html('')
                var totalRows = result.TotalRecords

                if (totalRows > PgSize) {
                    var pagenum = Math.ceil(totalRows / PgSize)

                    $('.pagination').append('<li class="page-item"><a onclick="Previous_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a onclick="Previous()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
                    for (var j = 1; j <= pagenum;) {
                        $('.pagination').append('<li onclick="Page(' + j + ')" class="page-item page page-number-' + j + '" data-page="' + j + '">\<span>' + j++ + '<span class="sr-only">(current)</span></span>\</li>').show()

                    }
                    num = pagenum;
                    $('.pagination').append('<li class="page-item next"><a onclick="Next()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a onclick="Next_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
                }
                $('.page-number-1').addClass('active')
                $('.page-number-1').addClass('abc')
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// function button paganition
function Page(pageNum) {
    changeDropThucTap($("#LoaiTT").val(), pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-' + pageNum).addClass('active')
    $('.page-number-' + pageNum).addClass('abc')

}

function Previous_all() {
    var pageNum = 1;
    changeDropThucTap($("#LoaiTT").val(), pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-1').addClass('active')
    $('.page-number-1').addClass('abc')
}

function Previous() {
    var pageNum = $('.abc').attr('data-page')

    if (pageNum == 1) {
    }
    else {
        pageNum = Number(pageNum)
        pageNum = pageNum - 1;
        changeDropThucTap($("#LoaiTT").val(), pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

function Next_all() {
    var pageNum = num;
    changeDropThucTap($("#LoaiTT").val(), pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-' + num).addClass('active')
    $('.page-number-' + num).addClass('abc')
}

function Next() {
    var pageNum = $('.abc').attr('data-page')

    if (pageNum == num) {
    }
    else {
        pageNum = Number(pageNum)
        pageNum = pageNum + 1;
        changeDropThucTap($("#LoaiTT").val(), pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

$('#maxRows').on('change', function () {
    changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
})


//Function for getting the Data Based upon ID  
function getbyID(ID) {
    $('#diemCongty').css('border-color', 'lightgrey');
    $('#diemGVHD').css('border-color', 'lightgrey');
    $('#diemBaoCao').css('border-color', 'lightgrey');
    $('#diemTong').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Score/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#masv').val(result.Masv);
            $('#name').val(result.FirstName + " " + result.LastName);
            $('#topicname').val(result.TopicName);
            $('#diemCongty').val(result.CompanyScore);
            $('#diemGVHD').val(result.TeacherScore);
            $('#diemBaoCao').val(result.ReportScore);
            $('#diemTong').val(result.TotalScore);
            $('#suadiem').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating employee's record  
function Update() {
    var res = validateUpdate();
    if (res == false) {
        return false;
    }

    var sv = {
        ID: $('#ID').val(),
        CompanyScore: $('#diemCongty').val(),
        TeacherScore: $('#diemGVHD').val(),
        ReportScore: $('#diemBaoCao').val(),
        TotalScore: $('#diemTong').val()
    };
    $.ajax({
        url: "/Score/Update",
        data: JSON.stringify(sv),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
            $('#suadiem').modal('hide');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    $("#modal_delete").modal("show");
    $(".btn_delete").attr("id", ID);
}


function DeleleResult(ID) {
        $.ajax({
            url: "/Score/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $("#modal_delete").modal("hide");
                changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}


function validateUpdate() {
    var isValid = true;
    if ($('#diemCongty').val().trim() == "") {
        $('#diemCongty').css('border-color', 'Red');
        $('#errorDiemCT').text('* Chưa nhập điểm công ty');
        isValid = false;
    }
    else {
        $('#diemCongty').css('border-color', 'lightgrey');
        $('#errorDiemCT').text('');
    }
    if ($('#diemGVHD').val().trim() == "") {
        $('#diemGVHD').css('border-color', 'Red');
        $('#errorDiemGV').text('* Chưa nhập điểm giáo viên ');
        isValid = false;
    }
    else {
        $('#diemGVHD').css('border-color', 'lightgrey');
        $('#errorDiemGV').text('');
    }
    if ($('#diemBaoCao').val().trim() == "") {
        $('#diemBaoCao').css('border-color', 'Red');
        $('#errorDiemBC').text('* Chưa nhập điểm báo cáo');
        isValid = false;
    }
    else {
        $('#diemBaoCao').css('border-color', 'lightgrey');
        $('#errorDiemBC').text('');
    }

    if ($('#diemTong').val().trim() == "") {
        $('#diemTong').css('border-color', 'Red');
        $('#errorDiemT').text('* Chưa nhập tổng');
        isValid = false;
    }
    else {
        $('#diemTong').css('border-color', 'lightgrey');
        $('#errorDiemT').text('');
    }

    return isValid;
}


function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


    if ($("#choosen").val() == 0) {
        if (filter == "") {
            changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $(".LoaiTT #LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var studentname = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            $.ajax({
                async: false,
                url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + input.value + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    var html = '';

                    if (result.List == "") {
                        html += '<tr>';
                        html += '<td colspan="10">Không có dữ liệu</td>';

                        html += '</tr>';
                        $('.tbody').html(html);
                    }
                    else {
                        $.each(result.List, function (key, item) {
                            html += '<tr>';
                            html += '<td align="center">' + (i++) + '</td>';
                            html += '<td>' + item.Masv + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td>' + item.CompanyScore + '</td>';
                            html += '<td>' + item.TeacherScore + '</td>';
                            html += '<td>' + item.ReportScore + '</td>';
                            html += '<td>' + item.TotalScore + '</td>';
                            html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a href="#" onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                            html += '</tr>';
                        });
                        $('.tbody').html(html);
                        $('.pagination').html('')
                        var totalRows = result.TotalRecords;

                        if (totalRows > PgSize) {
                            var pagenum = Math.ceil(totalRows / PgSize)

                            $('.pagination').append('<li class="page-item"><a onclick="Previous_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a onclick="Previous()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
                            for (var j = 1; j <= pagenum;) {
                                $('.pagination').append('<li onclick="Page(' + j + ')" class="page-item page page-number-' + j + '" data-page="' + j + '">\<span>' + j++ + '<span class="sr-only">(current)</span></span>\</li>').show()

                            }
                            num = pagenum;
                            $('.pagination').append('<li class="page-item next"><a onclick="Next()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a onclick="Next_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
                        }
                        $('.page-number-1').addClass('active')
                        $('.page-number-1').addClass('abc')
                    }
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    }
    else {
        if (filter == "") {
            changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $(".LoaiTT #LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var masv = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            $.ajax({
                async: false,
                url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + input.value + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    var html = '';

                    if (result.List == "") {
                        html += '<tr>';
                        html += '<td colspan="10">Không có dữ liệu</td>';

                        html += '</tr>';
                        $('.tbody').html(html);
                    }
                    else {
                        $.each(result.List, function (key, item) {
                            html += '<tr>';
                            html += '<td align="center">' + (i++) + '</td>';
                            html += '<td>' + item.Masv + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td>' + item.CompanyScore + '</td>';
                            html += '<td>' + item.TeacherScore + '</td>';
                            html += '<td>' + item.ReportScore + '</td>';
                            html += '<td>' + item.TotalScore + '</td>';
                            html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a href="#" onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                            html += '</tr>';
                        });
                        $('.tbody').html(html);
                        $('.pagination').html('')
                        var totalRows = result.TotalRecords;

                        if (totalRows > PgSize) {
                            var pagenum = Math.ceil(totalRows / PgSize)

                            $('.pagination').append('<li class="page-item"><a onclick="Previous_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a onclick="Previous()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
                            for (var j = 1; j <= pagenum;) {
                                $('.pagination').append('<li onclick="Page(' + j + ')" class="page-item page page-number-' + j + '" data-page="' + j + '">\<span>' + j++ + '<span class="sr-only">(current)</span></span>\</li>').show()

                            }
                            num = pagenum;
                            $('.pagination').append('<li class="page-item next"><a onclick="Next()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a onclick="Next_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
                        }
                        $('.page-number-1').addClass('active')
                        $('.page-number-1').addClass('abc')
                    }
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
    }
}

//function for updating employee's record  
//function ExportExcel() {
//    var IDHK = $(".HocKy #HocKy").val();
//    var IDTT = $(".LoaiTT #LoaiTT").val();
//    $.ajax({
//        async: false,
//        url: "/Score/CreateExcelFileExport?IDHK=" + IDHK + "&IDTT=" + IDTT ,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
            

//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}

function QuestionDelete() {
    $("#thongbao").modal("show");
}

$("#deleteall").click(function () {
    var PracticeID = $('#LoaiTT').val();
    var SemesterID = $("#HocKy").val();
    $.ajax({
        url: "/Score/DeleteAll?SemesterID=" + SemesterID + "&PracticeID=" + PracticeID,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                $("#thongbao").modal("hide");
                changeDropHocKy($("#HocKy").val());
                $('#notification').addClass('alert-success');
                $('#notification').text('Xóa thành công');
                myFunction();
            }
            else if (result == false) {
                $("#thongbao").modal("hide");
                changeDropHocKy($("#HocKy").val());
                $('#notification').addClass('alert-danger');
                $('#notification').text('Xóa thất bại');
                myFunction();
            }
            else {
                $("#thongbao").modal("hide");
                $("#alerterror").text(result);
                $("#error").modal("show");
            }


        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});