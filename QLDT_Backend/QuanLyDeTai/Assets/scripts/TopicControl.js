$(window).on('load', function () {
    getListHocKy();

    changeDropHocKy($(".HocKy #HocKy").val());
    getListLinhVuc();
    getListHocKy1();

    changeDropHocKy1($(".HocKy1 #HocKy1").val());

   

});




var num, num1;

//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT,search="", PgNumber = 0, PgSize = $("#maxRows").val()) {
    var IDHK = $(".HocKy #HocKy").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/Topic/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&search=" + search + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="6">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.TopicName + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td>' + item.FieldName + '</td>';
                    if (item.Status == true) {

                        html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                    }
                    else {
                        html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                    }

                    html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';

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
                    $('.pagination').append('<li class="page-item next"><a onclick="Next()" class="page-link" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a onclick="Next_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
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

//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var detai = {
        PracticeID: $('.drpLoaiTT #LoaiTT').val(),
        SemesterID: $('.drpHocKy #HocKy').val(),
        FieldID: $('.ddlLinhvuc #LinhVuc').val(),
        TopicName: $('#TenDeTai').val(),
        Description: $('#MoTa').val(),
        Status: $('#TrangThai').is(":checked")
    };
    console.log(detai);
    $.ajax({
        url: "/Topic/Add",
        data: JSON.stringify(detai),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropThucTap($("#LoaiTT").val());
            $('#themdetai').modal('hide');
            if (result == true) {
                $('#notification').addClass('alert-success');
                $('#notification').text('Thêm đề tài thành công');
                myFunction();
            }
            else {
                $('#notification').addClass('alert-danger');
                $('#notification').text('Thêm đề tài thất bại');
                myFunction();
            }
        },
        error: function (errormessage) {
            $('#notification').addClass('alert-danger');
            $('#notification').text('Thêm đề tài thất bại');
            myFunction();
        }
    });

}


//Function for getting the Data Based upon ID  
function getbyID(ID) {
    $('#SuaTenDeTai').css('border-color', 'lightgrey');
    $('#SuaMoTa').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Topic/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                $('#ID').val(item.ID);
                $('.SuaHocKy #HocKy').val(item.SemesterID);
                $('.SuaLoaiTT #LoaiTT').val(item.PracticeID);
                $('.SuaLinhvuc #LinhVuc').val(item.FieldID);
                $('#SuaTenDeTai').val(item.TopicName);
                $('#SuaMoTa').val(item.Description);
                $("#SuaTrangThai").attr("checked", item.Status);
                if (item.Status == true) {
                    $('#suatrangthai').text("Kích hoạt");
                }
            });
            $('#suadetai').modal('show');

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
    var detai = {
        ID: $('#ID').val(),
        PracticeID: $('.SuaLoaiTT #LoaiTT').val(),
        SemesterID: $('.SuaHocKy #HocKy').val(),
        FieldID: $('.ddlLinhvuc #LinhVuc').val(),
        TopicName: $('#SuaTenDeTai').val(),
        Description: $('#SuaMoTa').val(),
        Status: $('#SuaTrangThai').is(":checked")
    };
    $.ajax({
        url: "/Topic/Update",
        data: JSON.stringify(detai),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropThucTap($("#LoaiTT").val())
            $('#suadetai').modal('hide');
            if (result == true) {
                $('#notification').addClass('alert-success');
                $('#notification').text('Sửa đề tài thành công');
                myFunction();
            } else {
                $('#notification').addClass('alert-danger');
                $('#notification').text('Sửa đề tài thất bại');
                myFunction();
            }
        },
        error: function (errormessage) {
            $('#notification').addClass('alert-danger');
            $('#notification').text('Sửa đề tài thất bại');
            myFunction();
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Bạn muốn xóa đề tài này?");
    if (ans) {
        $.ajax({
            url: "/Topic/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                if (result == "ErrorCheck") {
                    $('#thongbao').modal('show');
                }
                else if (result == true) {
                    $('#notification').addClass('alert-success');
                    $('#notification').text('Xóa đề tài thành công');
                    myFunction();
                }
                else {
                    $('#notification').addClass('alert-danger');
                    $('#notification').text('Xóa đề tài thất bại');
                    myFunction();
                }
                changeDropThucTap($("#LoaiTT").val());
            },
            error: function (errormessage) {
                $('#notification').addClass('alert-danger');
                $('#notification').text('Xóa đề tài thất bại');
                myFunction();
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#TenDeTai').val('');
    $('#MoTa').val('');
    $("#TrangThai").attr("checked", false);
    $('#TenDeTai').css('border-color', 'lightgrey');
    $('#MoTa').css('border-color', 'lightgrey');

        $('#trangthai').text("Chưa kích hoạt");

}

//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TenDeTai').val().trim() == "") {
        $('#TenDeTai').css('border-color', 'Red');
        $('#errorTenDT').text('* Chưa nhập tên đề tài');
        isValid = false;
    }
    else {
        $('#TenDeTai').css('border-color', 'lightgrey');
        $('#errorTenDT').text('');
    }
    if ($('#MoTa').val().trim() == "") {
        $('#MoTa').css('border-color', 'Red');
        $('#errorMoTa').text('* Chưa nhập mô tả');
        isValid = false;
    }
    else {
        $('#MoTa').css('border-color', 'lightgrey');
        $('#errorMoTa').text('');
    }

    return isValid;
}

function validateUpdate() {
    var isValid = true;
    if ($('#SuaTenDeTai').val().trim() == "") {
        $('#SuaTenDeTai').css('border-color', 'Red');
        $('#SuaerrorTenDT').text('* Chưa nhập tên đề tài');
        isValid = false;
    }
    else {
        $('#SuaTenDeTai').css('border-color', 'lightgrey');
        $('#SuaerrorTenDT').text('');
    }
    if ($('#SuaMoTa').val().trim() == "") {
        $('#SuaMoTa').css('border-color', 'Red');
        $('#SuaerrorMoTa').text('* Chưa nhập mô tả');
        isValid = false;
    }
    else {
        $('#SuaMoTa').css('border-color', 'lightgrey');
        $('#SuaerrorMoTa').text('');
    }

    return isValid;
}


//function for search ten de tai

function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    if (filter == "") {
        changeDropThucTap($(".LoaiTT #LoaiTT").val());
    }
    else {
        var IDTT = $(".LoaiTT #LoaiTT").val();
        var IDHK = $(".HocKy #HocKy").val();
        var PgNumber = 0;
        var PgSize = $("#maxRows").val()
        var i = PgSize;
        i = (i * PgNumber) + 1;
        $.ajax({
            async: false,
            url: "/Topic/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&search=" + input.value + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                var html = '';

                if (result.List == "") {
                    html += '<tr>';
                    html += '<td colspan="5">Không có dữ liệu</td>';

                    html += '</tr>';
                    $('.tbody').html(html);
                }
                else {
                    $.each(result.List, function (key, item) {
                        html += '<tr>';
                        html += '<td align="center">' + (i++) + '</td>';
                        html += '<td>' + item.TopicName + '</td>';
                        html += '<td>' + item.Description + '</td>';
                        if (item.Status == true) {

                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                        }
                        else {
                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
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
}

//function for change status
function changeStatus(id)
{
    $.ajax({
        url: "/Topic/ChangeStatus/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("this").attr("checked", result.Status);
        },

        error: function (errormessage) {

        }
    });
    return false;
}


// function button paganition
function Page(pageNum) {
    changeDropThucTap($("#LoaiTT").val(),"", pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-' + pageNum).addClass('active')
    $('.page-number-' + pageNum).addClass('abc')

}

function Previous_all() {
    var pageNum = 1;
    changeDropThucTap($("#LoaiTT").val(),"", pageNum - 1, $("#maxRows").val());
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
        changeDropThucTap($("#LoaiTT").val(),"", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

function Next_all() {
    var pageNum = num;
    changeDropThucTap($("#LoaiTT").val(),"", pageNum - 1, $("#maxRows").val());
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
        changeDropThucTap($("#LoaiTT").val(),"", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

$('#maxRows').on('change', function () {
    changeDropThucTap($("#LoaiTT").val(),"", 0, $("#maxRows").val());
})

//tab2
function getListHocKy1() {
    $.ajax({
        url: "/List/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="HocKy1" class="HK1 form-control" onchange = "changeDropHocKy1(this.value)">';
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
            var html = '<select class="LTT1 form-control" onchange = "changeDropThucTap1(this.value)" id="LoaiTT1" >';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';

            });
            html += '</select>'

            $(".ddlLoaiTT1").html(html);
            changeDropThucTap1($("#LoaiTT1").val());
        },

        error: function (errormessage) {

        }
    });
    return false;
}

function changeDropThucTap1(IDTT, search = "", PgNumber = 0, PgSize = $("#maxRows1").val()) {
    var IDHK = $(".HocKy1 #HocKy1").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/Topic/GetList?IDHK=" + IDHK + "&IDTT=" + IDTT + "&search=" + search + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="5">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody1').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.TopicName + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td>' + item.FieldName + '</td>';
                    html += '<td>' + item.FirstName+" "+item.LastName + '</td>';
                    html += '</tr>';
                });
                $('.tbody1').html(html);
                $('.pagination1').html('')
                var totalRows = result.TotalRecords

                if (totalRows > PgSize) {
                    var pagenum = Math.ceil(totalRows / PgSize)

                    $('.pagination1').append('<li class="page-item"><a onclick="Previous_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a onclick="Previous()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
                    for (var j = 1; j <= pagenum;) {
                        $('.pagination1').append('<li onclick="Page(' + j + ')" class="page-item page pages-number-' + j + '" data-page="' + j + '">\<span>' + j++ + '<span class="sr-only">(current)</span></span>\</li>').show()

                    }
                    num1 = pagenum;
                    $('.pagination1').append('<li class="page-item next"><a onclick="Next()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a onclick="Next_all()" class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
                }
                $('.pages-number-1').addClass('active')
                $('.pages-number-1').addClass('abcd')
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
} 

// function button paganition
function Page1(pageNum) {
    changeDropThucTap1($("#LoaiTT1").val(), pageNum - 1, $("#maxRows1").val());
    $('.pagination1 li').removeClass('active')
    $('.pagination1 li').removeClass('abcd')
    $('.pages-number-' + pageNum).addClass('active')
    $('.pages-number-' + pageNum).addClass('abcd')

}

function Previous_all1() {
    var pageNum = 1;
    changeDropThucTap1($("#LoaiTT1").val(), pageNum - 1, $("#maxRows1").val());
    $('.pagination1 li').removeClass('active')
    $('.pagination1 li').removeClass('abcd')
    $('.page-number-1').addClass('active')
    $('.page-number-1').addClass('abcd')
}

function Previous() {
    var pageNum = $('.abcd').attr('data-page')

    if (pageNum == 1) {
    }
    else {
        pageNum = Number(pageNum)
        pageNum = pageNum - 1;
        changeDropThucTap1($("#LoaiTT1").val(), pageNum - 1, $("#maxRows1").val());
        $('.pagination1 li').removeClass('active')
        $('.pagination1 li').removeClass('abcd')
        $('.pages-number-' + pageNum).addClass('active')
        $('.pages-number-' + pageNum).addClass('abcd')
    }
}

function Next_all() {
    var pageNum = num1;
    changeDropThucTap1($("#LoaiTT1").val(), pageNum - 1, $("#maxRows1").val());
    $('.pagination1 li').removeClass('active')
    $('.pagination1 li').removeClass('abcd')
    $('.pages-number-' + num).addClass('active')
    $('.pages-number-' + num).addClass('abcd')
}

function Next() {
    var pageNum = $('.abcd').attr('data-page')

    if (pageNum == num1) {
    }
    else {
        pageNum = Number(pageNum)
        pageNum = pageNum + 1;
        changeDropThucTap1($("#LoaiTT1").val(), pageNum - 1, $("#maxRows1").val());
        $('.pagination1 li').removeClass('active')
        $('.pagination1 li').removeClass('abc')
        $('.pages-number-' + pageNum).addClass('active')
        $('.pages-number-' + pageNum).addClass('abc')
    }
}