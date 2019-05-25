$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($(".HocKy #HocKy").val());
    
});




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

//Add Data Function
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var detai = {
        PracticeID: $('.drpLoaiTT #LoaiTT').val(),
        SemesterID: $('.drpHocKy #HocKy').val(),
        TopicName: $('#TenDeTai').val(),
        Description: $('#MoTa').val(),
        Status: $('#TrangThai').is(":checked")
    };
    $.ajax({
        url: "/Topic/Add",
        data: JSON.stringify(detai),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropHocKy($("#HocKy").val());
            $('#themdetai').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
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
            changeDropHocKy($("#HocKy").val());
            $('#suadetai').modal('hide');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
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
                changeDropHocKy($("#HocKy").val());
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
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
        changeDropHocKy($(".HocKy #HocKy").val());
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
    changeDropThucTap($("#LoaiTT").val(), 0, $("#maxRows").val());
})