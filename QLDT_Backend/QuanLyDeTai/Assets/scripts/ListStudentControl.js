$(window).on('load', function () {
    getListKhoaHoc();
    getListKhoaHoc2();
    changeDropKhoaHoc($("#KhoaHoc").val());
  
});



//Thay doi dropdown cua thuc tap
function changeDropKhoaHoc(facultyId,masv="",studentname="",PgNumber = 0, PgSize = $("#maxRows").val()) {
    var i = 1;
    $.ajax({
        async: false,
        url: "/Student/GetListByFacultyId?facultyId=" + facultyId + "&masv=" + masv + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="10">Danh sách trống</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.Masv + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.Birthday + '</td>';
                    if (item.Sex == true) {
                        html += '<td>Nữ</td>';
                    }
                    else {
                        html += '<td>Nam</td>';
                    }
                    html += '<td>' + item.Email + '</td>';
                    html += '<td>' + item.Phone + '</td>';
                    html += '<td>' + item.Address + '</td>';
                    if (item.Note == null) {
                        item.Note = "";
                    }
                    html += '<td>' + item.Note + '</td>';
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
    changeDropKhoaHoc($("#KhoaHoc").val(),"","", pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-' + pageNum).addClass('active')
    $('.page-number-' + pageNum).addClass('abc')

}

function Previous_all() {
    var pageNum = 1;
    changeDropKhoaHoc($("#KhoaHoc").val(),"","", pageNum - 1, $("#maxRows").val());
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
        changeDropKhoaHoc($("#KhoaHoc").val(),"","", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

function Next_all() {
    var pageNum = num;
    changeDropKhoaHoc($("#KhoaHoc").val(),"","", pageNum - 1, $("#maxRows").val());
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
        changeDropKhoaHoc($("#KhoaHoc").val(),"","", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

$('#maxRows').on('change', function () {
    changeDropKhoaHoc($("#KhoaHoc").val(),"","", 0, $("#maxRows").val());
})


//Function for getting the Data Based upon ID  
function getbyID(ID) {
    $('#SuaMasv').css('border-color', 'lightgrey');
    $('#SuaTen').css('border-color', 'lightgrey');
    $('#SuaHo').css('border-color', 'lightgrey');
    $('#SuaSdt').css('border-color', 'lightgrey');
    $('#SuaEmail').css('border-color', 'lightgrey');
    $('#SuaDc').css('border-color', 'lightgrey');
    $('#SuaNs').css('border-color', 'lightgrey');
    $('#SuaGt').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Student/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#ID').val(result.ID);
            $('#SuaMasv').val(result.Masv);
            $('.ddlKhoaHoc2 #KhoaHoc').val(result.FacultyId);
            $('#SuaHo').val(result.FirstName);
            $('#SuaTen').val(result.LastName);
            $('#SuaSdt').val(result.Phone);
            $('#SuaEmail').val(result.Email);
            $('#SuaDc').val(result.Address);
            $('#SuaNs').val(result.Birthday);
            if (result.Sex == true) {
                $('input:radio[name=SuaGt]').filter('[value=Nu]').attr('checked', true);
            }
            else {
                $('input:radio[name=SuaGt]').filter('[value=Nam]').attr('checked', true);
            }
                
            $('#suasvthuctap').modal('show');
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
        MaSV: $('#SuaMasv').val(),
        facultyId: $('.ddlKhoaHoc2 #KhoaHoc').val(),
        FirstName: $('#SuaHo').val(),
        LastName: $('#SuaTen').val(),
        Phone: $('#SuaSdt').val(),
        Email:$('#SuaEmail').val(),
        Address:$('#SuaDc').val(),
        Birthday:$('#SuaNs').val(),
        Sex: $("#SuaGt").val()
    };
    $.ajax({
        url: "/Student/Update",
        data: JSON.stringify(sv),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropKhoaHoc($("#KhoaHoc").val())
            $('#suasvthuctap').modal('hide');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(ID) {
    $("#modal_delete").modal("show");
    $(".btn_delete").attr("id", ID);
}


function DeleleResult(ID) {
        $.ajax({
            url: "/Student/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $("#modal_delete").modal("hide");
                changeDropKhoaHoc($("#KhoaHoc").val())
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}


function validateUpdate() {
    var isValid = true;
    if ($('#SuaMasv').val().trim() == "") {
        $('#SuaMasv').css('border-color', 'Red');
        $('#errorMasv').text('* Chưa nhập mã sv');
        isValid = false;
    }
    else {
        $('#SuaMasv').css('border-color', 'lightgrey');
        $('#errorMasv').text('');
    }
    if ($('#SuaHo').val().trim() == "") {
        $('#SuaHo').css('border-color', 'Red');
        $('#errorHo').text('* Chưa nhập họ ');
        isValid = false;
    }
    else {
        $('#SuaHo').css('border-color', 'lightgrey');
        $('#errorHo').text('');
    }
    if ($('#SuaTen').val().trim() == "") {
        $('#SuaTen').css('border-color', 'Red');
        $('#errorTen').text('* Chưa nhập tên');
        isValid = false;
    }
    else {
        $('#SuaTen').css('border-color', 'lightgrey');
        $('#errorTen').text('');
    }

    if ($('#SuaEmail').val().trim() == "") {
        $('#SuaEmail').css('border-color', 'Red');
        $('#errorEmail').text('* Chưa nhập email');
        isValid = false;
    }
    else {
        $('#SuaEmail').css('border-color', 'lightgrey');
        $('#errorEmail').text('');
    }

    if ($('#SuaSdt').val().trim() == "") {
        $('#SuaSdt').css('border-color', 'Red');
        $('#errorSdt').text('* Chưa nhập SDT');
        isValid = false;
    }
    else {
        $('#SuaSdt').css('border-color', 'lightgrey');
        $('#errorSdt').text('');
    }
    if ($('#SuaDc').val().trim() == "") {
        $('#SuaDc').css('border-color', 'Red');
        $('#errorDc').text('* Chưa nhập địa chỉ');
        isValid = false;
    }
    else {
        $('#SuaDc').css('border-color', 'lightgrey');
        $('#errorDc').text('');
    }

    return isValid;
}


function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


        if ($("#choosen").val() == 0) {
            if (filter == "") {
                changeDropKhoaHoc($("#KhoaHoc").val(), "", "", PgNumber = 0, PgSize = $("#maxRows").val());
            }
            else {
                changeDropKhoaHoc($("#KhoaHoc").val(), input.value, "", PgNumber = 0, PgSize = $("#maxRows").val());
            }
        }
        else {
            if (filter == "") {
                changeDropKhoaHoc($("#KhoaHoc").val(), "", "", PgNumber = 0, PgSize = $("#maxRows").val());
            }
            else {
                changeDropKhoaHoc($("#KhoaHoc").val(), "", input.value, PgNumber = 0, PgSize = $("#maxRows").val());
            }
        }
}

function clearBag() {
    $("#errorexcel").text("");
}


