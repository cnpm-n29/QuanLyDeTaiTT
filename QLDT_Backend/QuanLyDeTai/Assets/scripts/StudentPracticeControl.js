
    $(window).on('load', function () {
        getListHocKy();
        getListHocKy1();
        changeDropHocKy1($(".drpHocKy #HocKy").val());
        getListHocKy2();
        getListLoaiTT2();
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

}


function getListLoaiTT2() {
    $.ajax({
        url: "/List/listLoaiTT/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select class="LTT form-control" id="LoaiTT">';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';
            });
            html += '</select>';
            $(".CreateLoaiTT").html(html);
        },

        error: function (errormessage) {

        }
    });
    return false;
}

//combobox loai hoc ky 

function getListHocKy2() {
    $.ajax({
        url: "/List/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="HocKy" class="HK form-control">';
            html += '<option disabled > -- Chọn loại học kỳ -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SemesterName + '</option>';
            });
            html += '</select>';
            $(".CreateHocKy").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT, masv = "", studentname = "", PgNumber = 0, PgSize = $("#maxRows").val()) {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    var IDHK = $(".HocKy #HocKy").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/StudentPractice/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="11">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
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
                    html += '<td style="text-align:center"><input id=' + item.ID + ' onclick="check(' + item.ID + ',' + key + ')" style="margin:auto" name="ids[]" class="checkbox" type="checkbox"></td>';
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
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
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
    changeDropThucTap($("#LoaiTT").val(),"","", 0, $("#maxRows").val());
})


function AddPracticeType() {
    var practice = {
        PracticeID: $('.CreateLoaiTT #LoaiTT').val(),
        SemesterID: $('.CreateHocKy #HocKy').val()
    }
    $("#err").text("");
    $.ajax({
        url: "/StudentPractice/AddPractice",
        data: JSON.stringify(practice),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (typeof (result) == "boolean") {
                if (result == false) {
                    $("#err").html("<span style='color:red'>* Lỗi thêm mới </span>");
                    return;
                }
                $("#err").html("<span style='color:green'>* Thêm thành công!</span>");
                getListHocKy();
                getListLoaiTT();
                changeDropHocKy($(".drpHocKy #HocKy").val());
            }
            else {
                $("#err").html("<span style='color:red'>"+result+"<span>");
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


    if ($("#choosen").val() == 0) {
        if (filter == "") {
            changeDropThucTap($("#LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $("#LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var studentname = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            changeDropThucTap($("#LoaiTT").val(), input.value, "", 0, $("#maxRows").val());
        }
    }
    else {
        if (filter == "") {
            changeDropThucTap($("#LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $("#LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var masv = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            changeDropThucTap($("#LoaiTT").val(), "", input.value, 0, $("#maxRows").val());
        }
    }
}

function getbyID(ID) {
    $.ajax({
        url: "/StudentPractice/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
                $('#ID').val(result.ID);
                $('.SuaHocKy #HocKy').val(result.SemesterID);
            $('.SuaLoaiTT #LoaiTT').val(result.PracticeID);
            $('#suahoten').val(result.FirstName + " " + result.LastName);
            $('#suamasv').val(result.MaSV);

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
    var Masv = $('#suamasv').val();
    var PracticeID = $('.SuaLoaiTT #LoaiTT').val();
    var SemesterID = $('.SuaHocKy #HocKy').val();
    var ID = $('#ID').val();
    $.ajax({
        url: "/StudentPractice/Update?SemesterID=" + SemesterID + "&PracticeID=" + PracticeID + "&ID=" + ID + "&Masv=" + Masv,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                changeDropHocKy($("#HocKy").val());
                $('#suasvthuctap').modal('hide');
                toastr.success('Cập nhật thành công !');

            },
            error: function (errormessage) {
                toastr.error('Cập nhật thất bại !');
            }
        });
}

function Delele(ID) {
    $("#modal_delete").modal("show");
    $(".btn_delete").attr("id", ID);
}


function DeleleResult(ID) {
        $.ajax({
            url: "/StudentPractice/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $("#modal_delete").modal("hide");
                if (result == true) {
                    $("#thongbao").modal("hide");
                    changeDropHocKy($("#HocKy").val());
                    toastr.success('Xóa thành công !');
                }
                else if (result == false) {
                    $("#thongbao").modal("hide");
                    changeDropHocKy($("#HocKy").val());
                    toastr.error('Xóa thất bại !');
                }
                else {
                    $("#thongbao").modal("hide");
                    $("#alerterror").text(result);
                    $("#error").modal("show");
                }
                changeDropHocKy($("#HocKy").val());
            },
            error: function (errormessage) {
                toastr.error('Xóa thất bại !');
            }
        });
}

function QuestionDelete() {
    $("#thongbao").modal("show");
}


$("#deleteall").click(function () {
    var PracticeID = $('#LoaiTT').val();
    var SemesterID = $("#HocKy").val();
    $.ajax({
        url: "/StudentPractice/DeleteAll?SemesterID=" + SemesterID + "&PracticeID=" + PracticeID,
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                $("#thongbao").modal("hide");
                changeDropHocKy($("#HocKy").val());
                toastr.success('Xóa thành công !');
            }
            else if (result == false) {
                $("#thongbao").modal("hide");
                changeDropHocKy($("#HocKy").val());
                toastr.error('Xóa thất bại !');
            }
            else {
                $("#thongbao").modal("hide");
                $("#alerterror").text(result);
                $("#error").modal("show");
            }


        },
        error: function (errormessage) {
            toastr.error('Xóa thất bại !');
        }
    });
});

var lastChecked = null;
function check(ID,key) {
        var numberOfChecked = $('input:checkbox:checked').length;
        if (numberOfChecked > 0) {
            $('.btn-warning').addClass("show");
        }
        else {
            $('.btn-warning').removeClass("show");
        }
        if (lastChecked == null) {
            lastChecked = key;
            return;
        }

        if (window.event.shiftKey) {
            var start = key;
            var end = lastChecked;

            for (var i = end; i <= start; i++) {
                $("#" + i).prop('checked', true);
            }

        }

        lastChecked = key;
}

function QuestionDeleteChoose() {
    $("#thongbao2").modal("show");
}

$("#deletechoosen").click(function () {
    var list = new Array();
    var checkbox = $(".checkbox");
    for (var i = 0; i < checkbox.length; i++) {
        if (checkbox[i].checked === true) {
            list.push(checkbox[i].id);
        }
    }
    $.ajax({
        url: "/StudentPractice/DeleteChoose",
        data: JSON.stringify({ 'list': list }),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        async: false,
        success: function (result) {
            $("#thongbao2").modal("hide");
            
            changeDropThucTap($("#LoaiTT").val(), "", "", 0, $("#maxRows").val());
            toastr.success('Xóa thành công !');
        },
        error: function (errormessage) {
            toastr.error('Xóa thất bại !');
        }
    });
    //$.ajax({
    //    url: "/StudentPractice/DeleteAll?SemesterID=" + SemesterID + "&PracticeID=" + PracticeID,
    //    type: "POST",
    //    contentType: "application/json;charset=UTF-8",
    //    dataType: "json",
    //    success: function (result) {
    //        if (result == true) {
    //            $("#thongbao").modal("hide");
    //            changeDropHocKy($("#HocKy").val());
    //            $('#notification').addClass('alert-success');
    //            $('#notification').text('Xóa thành công');
    //            myFunction();
    //        }
    //        else if (result == false) {
    //            $("#thongbao").modal("hide");
    //            changeDropHocKy($("#HocKy").val());
    //            $('#notification').addClass('alert-danger');
    //            $('#notification').text('Xóa thất bại');
    //            myFunction();
    //        }
    //        else {
    //            $("#thongbao").modal("hide");
    //            $("#alerterror").text(result);
    //            $("#error").modal("show");
    //        }


    //    },
    //    error: function (errormessage) {
    //        alert(errormessage.responseText);
    //    }
    //});
});
