

$(window).on('load', function () {
   getListHocKy();
changeDropHocKy($("#HocKy").val());
});

//thay doi dropdown hoc ky
function changeDropHocKy(IDHK) {
    $.ajax({
        url: "/DeTai/GetLoaiTTByHK/" + IDHK,
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select class="LTT form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT" >';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.TenThucTap + '</option>';
                
            });
            html += '</select>'
            
            $(".ddlLoaiTT").html(html);
            changeDropThucTap($("#LoaiTT").val());
        },

        error: function (errormessage) {

        }
    });
    return false;
}


//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT) {
    var IDHK = $("#HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/DeTai/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT,
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
                    if (item.TrangThai == true) {

                        html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                    }
                    else {
                        html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                    }

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


////Lay het gia tri cua loai thuctap
//function getListLoaiTT() {
//    $.ajax({
//        url: "/DeTai/listLoaiTT/",
//        type: "GET",
//        async: false,
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {
//            var html = '<select class="form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT">';
//            html += '<option disabled> -- Chọn loại thực tập -- </option>';
//            $.each(result, function (key, item) {
//                html += '<option value=' + item.ID + '>' + item.TenThucTap + '</option>';


//            });
//            html += '</select>'
//            $(".ddlLoaiTT").html(html);
//        },

//        error: function (errormessage) {

//        }
//    });
//    return false;
//}

function getListHocKy() {
    $.ajax({
        url: "/DeTai/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="HocKy" class="HK form-control" onchange = "changeDropHocKy(this.value)">';
            html += '<option disabled > -- Chọn loại học kỳ -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.TenHocKy + '</option>';
            });
            html += '</select>'
            $(".ddlHocKy").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}



