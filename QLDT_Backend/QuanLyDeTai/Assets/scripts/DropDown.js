//Common
//Combobox loai thuctap
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
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';
            });
            html += '</select>'
            $(".ddlLoaiTT").html(html);
        },

        error: function (errormessage) {

        }
    });
    return false;
}


//combobox loai hoc ky 

function getListHocKy() {
    $.ajax({
        url: "/Topic/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="HocKy" class="HK form-control" onchange = "changeDropHocKy(this.value)">';
            html += '<option disabled > -- Chọn loại học kỳ -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SemesterName + '</option>';
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
//=================Topic-Index===========================

//thay doi dropdown hoc ky
function changeDropHocKy(IDHK) {
    $.ajax({
        url: "/Topic/GetLoaiTTByHK/" + IDHK,
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select class="LTT form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT" >';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';
                
            });
            html += '</select>'
            
            $(".ddlLoaiTT").html(html);
            changeDropThucTap($("#LoaiTT").val());
            phantrang();
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
        url: "/Topic/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT,
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
                phantrang();
            }
            },
                error: function (errormessage) {
                    alert(errormessage.responseText);
            }  
    });
}  

//======================TopicStudent-ChoosenTopic=======================


//Thay doi dropdown cua thuc tap
function changeDropThucTap1(Id) {
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
                    html += '<td>' + item.TopicName + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td align="center"><input id="' + item.ID +'" onclick="check(' + item.ID + ')" type="checkbox" ></td >';
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


//==========================TopicStudent-SaveTopic========================


    function changeDropThucTap2(IDTT) {
        var IDHK = $("#HocKy").val();
        var i = 1;
        $.ajax({
            async: false,
            url: "/Topic/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT,
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
                    phantrang();
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }  