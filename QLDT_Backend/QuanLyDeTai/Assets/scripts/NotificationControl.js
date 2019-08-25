$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($(".HocKy #HocKy").val());
    getListLinhVuc();

});




//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT) {
    var IDHK = $(".HocKy #HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/Notification/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT ,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result == "") {
                html += '<tr>';
                html += '<td colspan="5">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.Title + '</td>';
                    html += '<td>' + item.Content + '</td>';

                    html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a href="#" onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';

                    html += '</tr>';
             });
             $('.tbody').html(html);
                
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
        Title: $('#TenTB').val(),
        Content: $('#MoTa').val()
    };
    $.ajax({
        url: "/Notification/Add",
        data: JSON.stringify(detai),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropThucTap($("#LoaiTT").val());
            $('#themthongbao').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}


//Function for getting the Data Based upon ID  
function getbyID(ID) {
    $('#SuaTenTB').css('border-color', 'lightgrey');
    $('#SuaMoTa').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Notification/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                $('#ID').val(item.ID);
                //$('.SuaHocKy #HocKy').val(item.SemesterID);
                //$('.SuaLoaiTT #LoaiTT').val(item.PracticeID);
                $('#SuaTenTB').val(item.Title);
                $('#SuaMoTa').val(item.Content);
            });
            $('#suathongbao').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for updating employee's record  
function Update() {
    var res = validateUpdate();
    if (res == false) {
        return false;
    }
    var detai = {
        ID: $('#ID').val(),
        //PracticeID: $('.SuaLoaiTT #LoaiTT').val(),
        //SemesterID: $('.SuaHocKy #HocKy').val(),
        Title: $('#SuaTenTB').val(),
        Content: $('#SuaMoTa').val()
    };
    $.ajax({
        url: "/Notification/Update",
        data: JSON.stringify(detai),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            changeDropThucTap($("#LoaiTT").val());
            $('#suathongbao').modal('hide');

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting employee's record  
function Delele(ID) {
    var ans = confirm("Bạn muốn xóa thông báo này?");
    if (ans) {
        $.ajax({
            url: "/Notification/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                changeDropThucTap($("#LoaiTT").val());
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#TenTB').val('');
    $('#MoTa').val('');
    $('#TenTB').css('border-color', 'lightgrey');
    $('#MoTa').css('border-color', 'lightgrey');
    $('#themthongbao').modal('show');
}

//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#TenTB').val().trim() == "") {
        $('#TenTB').css('border-color', 'Red');
        $('#errorTenTB').text('* Chưa nhập tiêu đề thông báo');
        isValid = false;
    }
    else {
        $('#TenTB').css('border-color', 'lightgrey');
        $('#errorTenTB').text('');
    }
    if ($('#MoTa').val().trim() == "") {
        $('#MoTa').css('border-color', 'Red');
        $('#errorMoTa').text('* Chưa nhập nội dung thông báo');
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
    if ($('#SuaTenTB').val().trim() == "") {
        $('#SuaTenTB').css('border-color', 'Red');
        $('#SuaerrorTenTB').text('* Chưa nhập tiêu đề thông báo');
        isValid = false;
    }
    else {
        $('#SuaTenTB').css('border-color', 'lightgrey');
        $('#SuaerrorTenTB').text('');
    }
    if ($('#SuaMoTa').val().trim() == "") {
        $('#SuaMoTa').css('border-color', 'Red');
        $('#SuaerrorMoTa').text('* Chưa nhập nội dung thông báo');
        isValid = false;
    }
    else {
        $('#SuaMoTa').css('border-color', 'lightgrey');
        $('#SuaerrorMoTa').text('');
    }

    return isValid;
}




