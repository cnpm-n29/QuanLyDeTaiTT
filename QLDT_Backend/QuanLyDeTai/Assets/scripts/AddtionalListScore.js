
$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($(".HocKy #HocKy").val());

});




//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT, masv = "", studentname = "", PgNumber = 0, PgSize = $("#maxRows").val()) {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    var IDHK = $(".HocKy #HocKy").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "") {
                html += '<tr>';
                html += '<td colspan="10">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.Masv + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.TopicName + '</td>';

                    if (item.CompanyScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.CompanyScore + '</td>';
                    }

                    html += '<td>' + item.TeacherScore + '</td>';
                    if (item.ReportScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.ReportScore + '</td>';
                    }
                    if (item.TotalScore == null) {
                        html += '<td></td>';
                    }
                    else {
                        html += '<td>' + item.TotalScore + '</td>';
                    }
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
    changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
})


function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


    if ($("#choosen").val() == 0) {
        if (filter == "") {
            changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $(".LoaiTT #LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var studentname = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            $.ajax({
                async: false,
                url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + input.value + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    var html = '';

                    if (result.List == "") {
                        html += '<tr>';
                        html += '<td colspan="10">Không có dữ liệu</td>';

                        html += '</tr>';
                        $('.tbody').html(html);
                    }
                    else {
                        $.each(result.List, function (key, item) {
                            html += '<tr>';
                            html += '<td align="center">' + (i++) + '</td>';
                            html += '<td>' + item.Masv + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td>' + item.CompanyScore + '</td>';
                            html += '<td>' + item.TeacherScore + '</td>';
                            html += '<td>' + item.ReportScore + '</td>';
                            html += '<td>' + item.TotalScore + '</td>';
                            html += '</tr>';
                        });
                        $('.tbody').html(html);
                        $('.pagination').html('')
                        var totalRows = result.TotalRecords;

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
    else {
        if (filter == "") {
            changeDropThucTap($(".LoaiTT #LoaiTT").val(), "", "", 0, $("#maxRows").val());
        }
        else {
            var IDTT = $(".LoaiTT #LoaiTT").val();
            var IDHK = $(".HocKy #HocKy").val();
            var PgNumber = 0;
            var masv = "";
            var PgSize = $("#maxRows").val()
            var i = PgSize;
            i = (i * PgNumber) + 1;
            $.ajax({
                async: false,
                url: "/Score/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + input.value + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    var html = '';

                    if (result.List == "") {
                        html += '<tr>';
                        html += '<td colspan="10">Không có dữ liệu</td>';

                        html += '</tr>';
                        $('.tbody').html(html);
                    }
                    else {
                        $.each(result.List, function (key, item) {
                            html += '<tr>';
                            html += '<td align="center">' + (i++) + '</td>';
                            html += '<td>' + item.Masv + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td>' + item.CompanyScore + '</td>';
                            html += '<td>' + item.TeacherScore + '</td>';
                            html += '<td>' + item.ReportScore + '</td>';
                            html += '<td>' + item.TotalScore + '</td>';
                            html += '</tr>';
                        });
                        $('.tbody').html(html);
                        $('.pagination').html('')
                        var totalRows = result.TotalRecords;

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
}

//function for updating employee's record  
//function ExportExcel() {
//    var IDHK = $(".HocKy #HocKy").val();
//    var IDTT = $(".LoaiTT #LoaiTT").val();
//    $.ajax({
//        async: false,
//        url: "/Score/CreateExcelFileExport?IDHK=" + IDHK + "&IDTT=" + IDTT ,
//        type: "GET",
//        contentType: "application/json;charset=UTF-8",
//        dataType: "json",
//        success: function (result) {


//        },
//        error: function (errormessage) {
//            alert(errormessage.responseText);
//        }
//    });
//}
