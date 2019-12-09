
$(window).on('load', function () {
    getListLoaiTT();
    changeDropThucTap($("#LoaiTT").val());

    
});

//Thay doi dropdown cua thuc tap
function changeDropThucTap(Id, search = "", PgNumber = 0, PgSize = 100) {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    i = 1;
    $.ajax({
        async: false,
        url: "/TopicStudent/GetByThucTap?IDTT=" + Id + "&search=" + search + "&PageNumber=" + PgNumber + "&PageSize=" + PgSize,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            
            if (result.List == "") {
                $('.mytable').show();
                html += '<tr>';
                html += '<td colspan="6">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
                $('.tableTopic').html("");
            }
            else if (result.Detai != null) {
                $('.mytable').hide();
                html = '<tr>';
                html += '<th class="center-header" scope = "col"> STT</th>';
                html += '<th class="center-header" scope="col">Tên đề tài</th>';
                html += '<th class="center-header" scope="col">Mô tả</th>';
                html += '<th class="center-header" scope="col">Tiến độ</th>';
                html += '<th class="center-header" scope="col">Kết quả</th>';
                html += '</tr>';

                html += '<tr>';
                html += '<td align="center">' + (i++) + '</td>';
                html += '<td>' + result.Detai.TopicName + '</td>';
                html += '<td>' + result.Detai.Description + '</td>';
                if (result.Detai.Progress == 0) {

                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Nhận đề tài</label ></td >';

                }
                else if (result.Detai.Progress == 1) {
                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 1</label ></td >';
                }
                else if (result.Detai.Progress == 2) {
                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 2</label ></td >';
                }
                if (result.Detai.Result == null) {

                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Chưa đánh giá</label ></td >';

                }
                else if (result.Detai.Result == true) {

                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Đạt</label ></td >';

                }
                else {
                    html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Không đạt</label ></td >';
                }
                html += '</tr>';
                $('.tableTopic').html(html);
                $('.tbody').html("");
            } 
            else if (result.ChooseTopic != null) {
                $('.mytable').hide();
                html = '<tr>';
                html += '<th class="center-header" scope = "col"> STT</th>';
                html += '<th class="center-header" scope="col">Tên đề tài</th>';
                html += '<th class="center-header" scope="col">Mô tả</th>';
                html += '<th class="center-header" scope="col">Thứ tự</th>';
                html += '</tr>';
                $.each(result.ChooseTopic, function (key, item) {
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.TopicName + '</td>';
                    html += '<td>' + item.Description + '</td>';
                    html += '<td style="text-align:center">' + item.Order + '</td>';

                    html += '</tr>';
                })
                $('.tableTopic').html(html);
                $('.tbody').html("");
            }
            else if (result.Error == "Chưa được phân giảng viên") {
                $('.mytable').show();
                $('.tableTopic').html("");
                html += '<tr>';
                html += '<td colspan="6">Chưa được phân giảng viên</td>';
                html += '</tr>';
                $('.tbody').html(html);
                $('.tableTopic').html("");
            }
            else if (result.Error == "Chưa được phân thực tập") {
                $('.mytable').show();
                $('.tableTopic').html("");
                html += '<tr>';
                html += '<td colspan="6">Chưa được phân thực tập</td>';
                html += '</tr>';
                $('.tbody').html(html);
                $('.tableTopic').html("");
            }
            else if (result.List == null) {
                $('.mytable').show();
                html += '<tr>';
                html += '<td colspan="6">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
                $('.tableTopic').html("");
            }

            else {
                var j = 0;
                $.each(result.List[0], function (key, item) {
                    $('.mytable').show();
                    $('.tableTopic').html;
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item["TopicName"] + '</td>';
                    html += '<td>' + item["Description"] + '</td>'; 
                    html += '<td>' + item["FieldName"] + '</td>';
                    html += '<td align="center"><input id="' + item["ID"] + '" onclick="check(' + item["ID"] + ')" type="checkbox" ></td >';
                    html += '<td align="center"><a onclick="checkUserChoose(' +item["ID"] + ')"><i style="color:#009933" class="fa fa-address-card"></i></a> </td>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
                $('.tableTopic').html("");
                
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
} 

function checkUserChoose(id) {
    $.ajax({
        url: "/TopicStudent/CheckUserChoose?TopicId="+id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = "";
            if (result == null || result == "") {
                html += '<tr>';
                html += '<td colspan="2">Không có dữ liệu</td>';

                html += '</tr>';
            }
            else {
                $.each(result, function (key, item) {
                    html += '<tr>';
                    html += '<td>' + item.StudentID + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';

                    html += '</tr>';
                   
                });
            }
            $('.tablecheck').html(html);
            },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#chitietdt").modal('show');
}


function check(ID)
{
    if ($("#"+ID).is(":checked")) {
        var numberOfChecked = $('input:checkbox:checked').length;
        if (numberOfChecked < 4) {
            $.ajax({
                url: "/Topic/GetbyID/" + ID,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    if (numberOfChecked == 1) {
                        var html = '<h3 class="text-center" id="editsave">Danh sách chọn đề tài</h3><table id="edittable" class="table table-bordered" cellspacing="0" cellpadding="5"><thread><th style="display:none">ID</th><th class="center-header" scope="col" style="width:60%;">Tên đề tài</th><th class="center-header" scope="col">Độ ưu tiên</th><th class="center-header" scope="col">Thao tác</th></thread>';
                        $.each(result, function (key, item) {
                            html += '<tr class="' + item.ID + ' ' + numberOfChecked + '">';
                            html += '<td style="display:none">' + item.ID + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td class="number' + item.ID + ' nck' + numberOfChecked + '">' + numberOfChecked + '</td>';
                            html += '<td class="icon' + numberOfChecked + '" align="center"><a onclick="up(' + item.ID + ')"><i style="color:#009933" class="fa fa-arrow-up"></i></a> |<a onclick="down(' + item.ID + ')"><i style="color:#009933" class="fa fa-arrow-down"></i></a> | <a onclick="Delete(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                            html += '</tr>';
                        });
                        html += '</table><button id="edit" onclick="Save()"  style = "float: right;border-radius: 2%;" class="btn btn-outline-info btn-primary" ><i class="fa fa-save"></i> Lưu lại</button >'
                        $('.editsave').html(html);
                    }
                    else {
                        var html = "";
                        $.each(result, function (key, item) {
                            html += '<tr class="' + item.ID + ' ' + numberOfChecked + '">';
                            html += '<td style="display:none">' + item.ID + '</td>';
                            html += '<td>' + item.TopicName + '</td>';
                            html += '<td class="number' + item.ID + ' nck' + numberOfChecked+'">' + numberOfChecked + '</td>';
                            html += '<td class="icon' + numberOfChecked + '" align="center"><a onclick="up(' + item.ID + ')"><i style="color:#009933" class="fa fa-arrow-up"></i></a> |<a onclick="down(' + item.ID + ')"><i style="color:#009933" class="fa fa-arrow-down"></i></a> | <a onclick="Delete(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                            html += '</tr>';
                        });
                        $("#edittable").append(html);

                    }

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
        else {
            $("#"+ID).attr("checked", false);
            var error = '<div class="alert alert-danger"> Bạn chỉ đc chọn tối đa 3 đề tài!</div >';
            $('#edittable').before(error);

        }
    }
    else {
        var numberOfChecked = $('input:checkbox:checked').length+1;
        if (numberOfChecked == 1) {
            $('#edit').remove("button");
            $('#edittable').remove("table");
            $('#editsave').remove("h3");
            $("#" + ID).attr("checked", false);
        }
        else {
            $number = $(".number" + ID).text();
            $number = parseInt($number);
            if ($number == 1) {
                $("." + ID).remove("#".ID);
                $n1 = parseInt($(".nck" + ($number + 1)).text()) - 1;
                $n2 = parseInt($(".nck" + ($number + 2)).text()) - 1;
                $(".nck" + ($number + 1)).text($n1);
                $(".nck" + ($number + 2)).text($n2);
            }
            else if ($number == 2) {
                $("." + ID).remove("#".ID);
                $n = parseInt($(".nck" + ($number + 1)).text()) - 1;

                $(".nck" + ($number + 1)).text($n);
                $(".nck" + ($number + 1)).text($n);
            }
            else {
                $n1 = parseInt($(".nck" + ($number - 1)).text());
                $("." + ID).remove("#".ID);
               
            }
        }
    }

}

function Delete(ID) {
    var numberOfChecked = $('input:checkbox:checked').length;
    if (numberOfChecked == 1) {
        $('#edit').remove("button");
        $('#edittable').remove("table");
        $('#editsave').remove("h3");
        $("#" + ID).attr("checked", false);
    }
    else { 
        $number = $(".number" + ID).text();
        $number = parseInt($number);
        if ($number == 1) {
            $("." + ID).remove("#".ID);
            $n1 = parseInt($(".nck" + ($number + 1)).text()) - 1;
            $n2 = parseInt($(".nck" + ($number + 2)).text()) - 1;
            $(".nck" + ($number + 1)).text($n1);
            $(".nck" + ($number + 2)).text($n2);
        }
        else if ($number == 2) {
            $("." + ID).remove("#".ID);
            $n = parseInt($(".nck" + ($number + 1)).text()) - 1;

            $(".nck" + ($number + 1)).text($n);
            $(".nck" + ($number + 1)).text($n);
        }
        else {
            $n1 = parseInt($(".nck" + ($number - 1)).text());
            $("." + ID).remove("#".ID);
         }
    }
    $("#" + ID).attr("checked", false);
}

function up(ID) {
    $number = $(".number" + ID).text();
    $number = parseInt($number);
    if ($number == 1) {
        return false;
    }
    else {
        var row = $("." + ID).closest('tr');
        row.insertBefore(row.prev());
    }
    table = document.getElementById("edittable");
    tr = table.getElementsByTagName("tr");
    for (i = 1; i < tr.length; i++) {
        tr[i].getElementsByTagName("td")[2].textContent = i;
    }
    
}

function down(ID) {

    $number = $(".number" + ID).text();
    $number = parseInt($number);
    var row = $("." + ID).closest('tr');
    if ($number == 3) {
        return;
    }
    else {
        row.insertAfter(row.next());
    }
    table = document.getElementById("edittable");
    tr = table.getElementsByTagName("tr");
    for (i = 1; i < tr.length; i++) {
        tr[i].getElementsByTagName("td")[2].textContent = i;
    }
}

//Add Data Function   
function Save() {
    table = document.getElementById("edittable");
    tr = table.getElementsByTagName("tr");
    var list = new Array();
    for (i = 1; i < tr.length; i++) {
        var dt = {
            SemesterID: $('#LoaiTT').val(),
            TopicID: tr[i].getElementsByTagName("td")[0].textContent,
            Order: i
        };
        list.push(dt);
    }
   
    $.ajax({
        url: "/TopicStudent/Add",
        data: JSON.stringify({ 'list': list }),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        async: false,
        success: function (result) {
            $('#edit').remove("button");
            $('#edittable').remove("table");
            var html = "";
            html += '<tr>';
            html += '<td colspan="5">Đã chọn xong đề tài</td>';

            html += '</tr>';
            $('.tbody').html(html);
            $('.page').remove('div');
            toastr.success('Lưu thành công !');
        },
        error: function (errormessage) {
            toastr.error('Lưu thất bại !');
        }
    });
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
    changeDropThucTap($("#LoaiTT").val(), 0, $("#maxRows").val());
})

