

$(window).on('load', function () {
   getListHocKy();
changeDropHocKy($("#HocKy").val());
});

function phantrang() {

    var table = '.mytable'
    $('.pagination').html('')
    var trnum = 0
    var maxRows = 5
    var totalRows = $(table + ' tbody tr').length
    $(table + ' tr:gt(0)').each(function () {
        trnum++
        if (trnum > maxRows) {
            $(this).hide()
        }
        if (trnum <= maxRows) {
            $(this).show()
        }
    })
    if (totalRows > maxRows) {
        var pagenum = Math.ceil(totalRows / maxRows)

        $('.pagination').append('<li class="page-item previous-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-left"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item previous"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-left"></i></span><span class="sr-only">Previous</span></a></li>').show();
        for (var i = 1; i <= pagenum;) {

            $('.pagination').append('<li class="page-item page  page-number-' + i + '" data-page="' + i + '">\<span>' + i++ + '<span class="sr-only">(current)</span></span>\</li>').show()

        }
        var num = --i;
        $('.pagination').append('<li class="page-item next"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-right"></i></span><span class="sr-only">Previous</span></a></li><li class="page-item next-all"><a class="page-link" href="#" aria-label="Previous"><span aria-hidden="true"<i class="fa fa-angle-double-right"></i></span><span class="sr-only">Previous</span></a></li>').show();
    }
    $('.page-number-1').addClass('active')
    $('.page-number-1').addClass('abc')
    $('.previous-all').on('click', function () {
        var pageNum = 1;
        var trIndex = 0;
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-1').addClass('active')
        $('.page-number-1').addClass('abc')
        $(table + ' tr:gt(0)').each(function () {
            trIndex++
            if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                $(this).hide()
            } else {
                $(this).show()
            }
        })
    })
    $('.previous').on('click', function () {
        var pageNum = $('.abc').attr('data-page')

        if (pageNum == 1) {
        }
        else {
            pageNum = Number(pageNum)
            pageNum = pageNum - 1;

            var trIndex = 0;
            $('.pagination li').removeClass('active')
            $('.pagination li').removeClass('abc')
            $('.page-number-' + pageNum).addClass('active')
            $('.page-number-' + pageNum).addClass('abc')
            $(table + ' tr:gt(0)').each(function () {
                trIndex++
                if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                    $(this).hide()
                } else {
                    $(this).show()
                }
            })
        }
    })
    $('.next').on('click', function () {
        pageNum = $('.abc').attr('data-page')

        if (pageNum == num) {
        }
        else {
            pageNum = Number(pageNum)
            pageNum = pageNum + 1;

            var trIndex = 0;
            $('.pagination li').removeClass('active')
            $('.pagination li').removeClass('abc')
            $('.page-number-' + pageNum).addClass('active')
            $('.page-number-' + pageNum).addClass('abc')
            $(table + ' tr:gt(0)').each(function () {
                trIndex++
                if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                    $(this).hide()
                } else {
                    $(this).show()
                }
            })
        }
    })
    $('.next-all').on('click', function () {
        var pageNum = num;
        var trIndex = 0;
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
        $(table + ' tr:gt(0)').each(function () {
            trIndex++
            if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                $(this).hide()
            } else {
                $(this).show()
            }
        })
    })
    $('.page').on('click', function () {
        var pageNum = $(this).attr('data-page')
        var trIndex = 0;
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
        $(table + ' tr:gt(0)').each(function () {
            trIndex++
            if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                $(this).hide()
            } else {
                $(this).show()
            }
        })
    })
}

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
                html += '<option value=' + item.ID + '>' + item.TenThucTap + '</option>';
                
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
                phantrang();
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
        url: "/Topic/listHocKy/",
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



