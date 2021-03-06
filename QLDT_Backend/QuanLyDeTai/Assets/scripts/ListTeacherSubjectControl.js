﻿$(window).on('load', function () {
    getListBoMon();
    changeDropBoMon($("#BoMon").val());
});

//Lay danh sach giang vien trong bo mon
function changeDropBoMon(IDBM,magv = "", teachername = "", PgNumber = 0, PgSize = $("#maxRows").val()) {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    var IDHK = $("#HocKy").val();
    var IDBM = $("#BoMon").val();
    var i = PgSize;
    i = (i * PgNumber) + 1;
    $.ajax({
        async: false,
        url: "/Teacher/GetListBySubjectId?id="+IDBM+"&magv=" + magv + "&teachername=" + teachername + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (result == "") {
                html += '<tr>';
                html += '<td colspan="5">Danh sách trống</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.MaGV + '</td>';
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

function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


    if ($("#choosen").val() == 0) {
        if (filter == "") {
            changeDropBoMon($("#BoMon").val());
        }
        else {
            changeDropBoMon($("#BoMon").val(),input.value, "", PgNumber = 0, PgSize = $("#maxRows").val());
        }
    }
    else {
        if (filter == "") {
            changeDropBoMon($("#BoMon").val());
        }
        else {
            changeDropBoMon($("#BoMon").val(),"",input.value, PgNumber = 0, PgSize = $("#maxRows").val());
        }
    }
}

// function button paganition
function Page(pageNum) {
    changeDropBoMon($("#BoMon").val(),"","", pageNum - 1, $("#maxRows").val());
    $('.pagination li').removeClass('active')
    $('.pagination li').removeClass('abc')
    $('.page-number-' + pageNum).addClass('active')
    $('.page-number-' + pageNum).addClass('abc')

}

function Previous_all() {
    var pageNum = 1;
    changeDropBoMon($("#BoMon").val(),"","", pageNum - 1, $("#maxRows").val());
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
        changeDropBoMon($("#BoMon").val(),"","", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

function Next_all() {
    var pageNum = num;
    changeDropBoMon($("#BoMon").val(), "", "", pageNum - 1, $("#maxRows").val());
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
        changeDropBoMon($("#BoMon").val(), "", "", pageNum - 1, $("#maxRows").val());
        $('.pagination li').removeClass('active')
        $('.pagination li').removeClass('abc')
        $('.page-number-' + pageNum).addClass('active')
        $('.page-number-' + pageNum).addClass('abc')
    }
}

$('#maxRows').on('change', function () {
    changeDropBoMon($("#BoMon").val(),"","", 0, $("#maxRows").val());
})

//function Search() {
//    var input, filter, table, tr, td, i, txtValue;
//    input = document.getElementById("myInput");
//    filter = input.value.toUpperCase();


//    if ($("#choosen").val() == 0) {
//        if (filter == "") {
//            getListTeacher();
//        }
//        else {
//            getListTeacher(input.value, "", PgNumber = 0, PgSize = $("#maxRows").val());
//        }
//    }
//    else {
//        if (filter == "") {
//            getListTeacher();
//        }
//        else {
//            getListTeacher("", input.value, PgNumber = 0, PgSize = $("#maxRows").val());
//        }
//    }
//}