//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var detai = {
        ID_LoaiTT: $('.drpLoaiTT .LTT').val(),
        ID_HocKy: $('.drpHocKy .HK').val(),
        TenDeTai: $('#TenDeTai').val(),
        MoTa: $('#MoTa').val(),
        TrangThai: $('#TrangThai').is(":checked")
    };
    $.ajax({
        url: "/DeTai/Add",
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


//Function for getting the Data Based upon Employee ID  
function getbyID(ID) {
    $('#SuaTenDeTai').css('border-color', 'lightgrey');
    $('#SuaMoTa').css('border-color', 'lightgrey');
    $.ajax({
        url: "/DeTai/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                $('#ID').val(item.ID);
                $('.SuaHocKy .HK').val(item.ID_HocKy);
                $('.SuaLoaiTT .LTT').val(item.ID_LoaiTT);
                $('#SuaTenDeTai').val(item.TenDeTai);
                $('#SuaMoTa').val(item.MoTa);
                $("#SuaTrangThai").attr("checked", item.TrangThai);
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
        ID_LoaiTT: $('.SuaLoaiTT .LTT').val(),
        ID_HocKy: $('.SuaHocKy .HK').val(),
        TenDeTai: $('#SuaTenDeTai').val(),
        MoTa: $('#SuaMoTa').val(),
        TrangThai: $('#SuaTrangThai').is(":checked")
    };
    $.ajax({
        url: "/DeTai/Update",
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
            url: "/DeTai/Delete/" + ID,
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
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[1];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

//function for change status
function changeStatus(id)
{
    $.ajax({
        url: "/DeTai/ChangeStatus/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("this").attr("checked", result.TrangThai);
        },

        error: function (errormessage) {

        }
    });
    return false;
}
