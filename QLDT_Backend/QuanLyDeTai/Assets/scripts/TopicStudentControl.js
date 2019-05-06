
$(window).on('load', function () {
    getListLoaiTT();
    changeDropThucTap($("#LoaiTT").val());
});


//Lay het gia tri cua loai thuctap
function getListLoaiTT() {
    $.ajax({
        url: "/TopicStudent/listLoaiTT/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select class="form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT">';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.TenThucTap + '</option>';
            });
            html += '</select>'
            $(".ddlLoaiTT").html(html);
        },

        error: function (errormessage) {

        }
    });
    return false;
}

//Thay doi dropdown cua thuc tap
function changeDropThucTap(Id) {
    var i = 1;
    $.ajax({
        async: false,
        url: "/TopicStudent/GetByThucTap?IDTT=" + Id,
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
                    html += '<td>' + item.TenDeTai + '</td>';
                    html += '<td>' + item.MoTa + '</td>';
                    html += '<td align="center"><input onclick="check(' + item.ID +')" type="checkbox" id="chondetai(' + item.ID+')"></td >';
                    html += ' <td align="center"><a data-toggle="modal" data-target="#chitietdt"><i style="color:#009933" class="fa fa-address-card"></i></a> </td>';

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

function check(ID)
{
    var i = 1;
    $.ajax({
        url: "/Topic/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<table class="table table-bordered" cellspacing="0" cellpadding="5"><th class="center-header" scope="col" style="width:60%;">Tên đề tài</th><th class="center-header" scope="col">Độ ưu tiên</th><th class="center-header" scope="col">Chi tiết</th>';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.TenDeTai + '</td>';
                html += '<td>' + (i++) + '</td>';
                html += '<td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> | <a href="#" onclick="Delele(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                html += '<tr>';
            });
            html += '</table><button onclick=""  style = "float: right;border-radius: 2%;" class="btn btn-outline-info btn-primary" ><i class="fa fa-save"></i> Lưu lại</button >'
            $('.editsave').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    var html = '<table class="table table-bordered" cellspacing="0" cellpadding="5"><th class="center-header" scope="col" style="width:60%;">Tên đề tài</th><th class="center-header" scope="col">Độ ưu tiên</th><th class="center-header" scope="col">Chi tiết</th>';
    
    $('.editsave').html(html);
    //var totalSeen = $("#chondetai:input[checked='checked']").length;
    //var isStatus = $('#gender_male_checkbox').prop('checked');
    //if (isStatus == true)
    //{
    //    var detaitt = {
    //        ID_DeTai: $('.SuaHocKy .HK').val(),
    //        DoUuTien: totalSeen+1
    //    };
    //}

}

//Add Data Function   
function Add() {
    var detaitt = {
        ID_DeTai: $('.SuaHocKy .HK').val(),
        DoUuTien: totalSeen + 1
    };
    $.ajax({
        url: "/TopicStudent/Add",
        data: JSON.stringify(detaitt),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}

