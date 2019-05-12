
$(window).on('load', function () {
    getListLoaiTT();
    changeDropThucTap1($("#LoaiTT").val());
    var i=0;
});


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
                        var html = '<table id="edittable" class="table table-bordered" cellspacing="0" cellpadding="5"><thread><th style="display:none">ID</th><th class="center-header" scope="col" style="width:60%;">Tên đề tài</th><th class="center-header" scope="col">Độ ưu tiên</th><th class="center-header" scope="col">Thao tác</th></thread>';
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
            Order: tr[i].getElementsByTagName("td")[2].textContent
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
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

