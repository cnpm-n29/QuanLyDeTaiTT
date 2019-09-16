$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($(".HocKy #HocKy").val());


});

//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT, masv = "", studentname = "", PgNumber = 0, PgSize = $("#maxRows").val()) {
    var IDHK = $(".HocKy #HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/TopicStudent/GetByKHvaLoaiTT2?IDHK=" + IDHK + "&IDTT=" + IDTT + "&masv=" + masv + "&studentname=" + studentname + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result == ""||result==null) {
                html += '<tr>';
                html += '<td colspan="8">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.TopicName + '</td>';
                    if (item.Progress == 0) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Nhận đề tài</label ></td >';

                    }
                    else if (item.Progress == 1) {
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 1</label ></td >';
                    }
                    else if (item.Progress == 2) {
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 2</label ></td >';
                    }
                    if (item.Result == null) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Chưa đánh giá</label ></td >';

                    }
                    else if (item.Result == true) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Đạt</label ></td >';

                    }
                    else {
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Không đạt</label ></td >';
                    }
                    html += '<td>' + item.TeacherScore + '</td>';
                    
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

function Search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();


    if ($("#choosen").val() == 0) {
        if (filter == "") {
            changeDropThucTap($("#LoaiTT").val(), "", "", PgNumber = 0, PgSize = $("#maxRows").val());
        }
        else {
            changeDropThucTap($("#LoaiTT").val(), input.value, "", PgNumber = 0, PgSize = $("#maxRows").val());
        }
    }
    else {
        if (filter == "") {
            changeDropThucTap($("#LoaiTT").val(), "", "", PgNumber = 0, PgSize = $("#maxRows").val());
        }
        else {
            changeDropThucTap($("#LoaiTT").val(), "", input.value, PgNumber = 0, PgSize = $("#maxRows").val());
        }
    }
}