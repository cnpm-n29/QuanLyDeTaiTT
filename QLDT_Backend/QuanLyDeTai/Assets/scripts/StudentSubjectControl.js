
$(window).on('load', function () {
    getListKhoaHoc();
    getListBoMon();
    changeDropKhoaHoc($("#KhoaHoc").val());
});

var lastChecked = null;

function changeCheck(key) {
    var $chkboxes = $('.checkbox');
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

//var $chkboxes = $('.checkbox');
//var lastChecked = null;
//$chkboxes.click(function (e) {
//    if (!lastChecked) {
//        lastChecked = this.getAttribute("id");
//        return;
//    }

//    if (e.shiftKey) {
//        var start = $chkboxes.index(this);
//        var end = $chkboxes.index(lastChecked);

//        $chkboxes.slice(Math.min(start, end), Math.max(start, end) + 1).prop('checked', lastChecked.checked);

//    }

//    lastChecked = this;
//});

//Thay doi dropdown cua thuc tap
function changeDropKhoaHoc(IDKH) {
    var IDBM = $("#BoMon").val();
    $.ajax({
        async: false,
        url: "/StudentSubject/GetByMaKhoaHoc?IDKH=" + IDKH + "&IDBM=" + IDBM,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.Student == "") {
                html += '<tr>';
                html += '<td colspan="4">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                var n = 0;
                $.each(result.Student, function (key, item) {
                    console.log(key);
                    html += '<tr>';
                    html += '<td style="text-align:center"><input onclick="changeCheck(' + key + ')" style="margin:auto" id="' + key + '" class="checkbox" type="checkbox"></td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
                    html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                    if (result.SubjectName[n] == null) {
                        html += '<td></td>';
                        n++;
                    } else {
                        html += '<td>' + result.SubjectName[n++] + '</td>';
                    }
                    html += "</tr>";

                });
                $('.tbody').html(html);
            }
            if (result.Studentsubject == "") {
                var rs = "";
                rs += '<tr>';
                rs += '<td colspan="4">Không có dữ liệu</td>';

                rs += '</tr>';
                $('.tbodyresult').html(rs);
            }
            else {
                var rs = "";
                var i = 1;
                $.each(result.Studentsubject, function (key, item) {
                    rs += '<tr >';

                    rs += '<td style="text-align:center">' + (i++) + '</td>';
                    rs += '<td style="display:none">' + item.ID + '</td>';
                    rs += '<td>' + item.MaSV + '</td>';
                    rs += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';

                    rs += ' <td align="center"><a onclick="DeleteInDatabase(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                    rs += '</tr>';
                })
                $('.tbodyresult').html(rs);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Thay doi dropdown cua thuc tap
function changeDropBoMon(IDBM) {
    var IDKH = $("#KhoaHoc").val();
    $.ajax({
        async: false,
        url: "/StudentSubject/GetByMaKhoaHoc?IDKH=" + IDKH + "&IDBM=" + IDBM,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.Student == "") {
                html += '<tr>';
                html += '<td colspan="4">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                var n = 0;
                $.each(result.Student, function (key, item) {
                    html += '<tr >';
                    html += '<td style="text-align:center"><input onclick="changeCheck(' + key + ')" style="margin:auto" id="' + key + '" class="checkbox" type="checkbox"></td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
                    html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                    if (result.SubjectName[n] == null) {
                        html += '<td></td>';
                        n++;
                    } else {
                        html += '<td>' + result.SubjectName[n++] + '</td>';
                    }
                    html += "</tr>";

                });
                $('.tbody').html(html);
            }
            if (result.Studentsubject == "") {
                var rs = "";
                rs += '<tr>';
                rs += '<td colspan="4">Không có dữ liệu</td>';

                rs += '</tr>';
                $('.tbodyresult').html(rs);
            }
            else {
                var i = 1;
                var rs = "";
                $.each(result.Studentsubject, function (key, item) {
                    rs += '<tr >';

                    rs += '<td style="text-align:center">' + (i++) + '</td>';
                    rs += '<td style="display:none">' + item.ID + '</td>';
                    rs += '<td>' + item.MaSV + '</td>';
                    rs += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';

                    rs += ' <td align="center"><a onclick="DeleteInDatabase(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                    rs += '</tr>';
                })
                $('.tbodyresult').html(rs);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}



//lua chọn hoac bo lua chon cac checkbox class='checkbox'
$("#select_checkbox").click(function () {
    if ($('#select_checkbox').is(':checked')) {
        $(".checkbox").prop("checked", true);
    } else {
        $(".checkbox").prop("checked", false);
    }
});

var dem = 0;
//lay cac gia tri cua checkbox duoc lua chon
$("#move").click(function () {
    dem++;
    var ids = new Array();
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    table1 = document.getElementById("TableSubject");
    tr1 = table1.getElementsByTagName("tr");
    var html = "";
    var n = 1;
    var i = 1;
    var j = 1;
    while (i < tr.length) {
        if ($(tr[i].getElementsByTagName("td")[0]).find("input").is(":checked")) {
            n++;
            html += '<tr class="choosen" style="background-color:#8080802e">';
            if (tr1.length == 2) {
                if (tr1[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
                    html += '<td style="text-align:center">' + j++ + '</td>';
                }
                else {
                    html += '<td style="text-align:center">' + (parseInt(tr1[tr1.length - 1].getElementsByTagName("td")[0].textContent) + 1) + '</td>';
                }
            }
            else {
                html += '<td style="text-align:center">' + (parseInt(tr1[tr1.length - 1].getElementsByTagName("td")[0].textContent) + 1) + '</td>';
            }
            html += '<td style="display:none">' + tr[i].getElementsByTagName("td")[1].textContent + '</td>';
            html += '<td>' + tr[i].getElementsByTagName("td")[2].textContent + '</td>';
            html += '<td>' + tr[i].getElementsByTagName("td")[3].textContent + '</td>';
            html += '<td align = "center"><a class="choosen" onclick="Deleted(' + tr[i].getElementsByTagName("td")[1].textContent + ')"><i style="color:red" class="fa fa-trash"></i></a></td >'
            html += '</tr>';
            $(tr[i]).remove();

            if (n == 1) {
                i++;
            }
            //var dt = {
            //    SubjectID: $('#KhoaHoc').val(),
            //    StudentID: tr[i].getElementsByTagName("td")[1].textContent
            //};
            //ids.push(dt);

        }
        else {
            i++;
        }
    }
    if (dem == 1) {
        var button = '<button id="edit" onclick="Save()"  style = "float: right; border-radius: 2 %; " class="btn btn-outline-info btn-primary" ><i class="fa fa-save"></i> Lưu lại</button >';

        $('#TableSubject').after(button);
    }
    if (tr1[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
        $('.tbodyresult').html(html);
    }
    else {
        $('.tbodyresult').append(html);
    }

    sort();
    $("#select_checkbox").prop("checked", false);
    CheckDataNull();
});

function sort() {
    var j = 1;
    table1 = document.getElementById("TableSubject");
    tr1 = table1.getElementsByTagName("tr");
    for (i = 1; i < tr1.length; i++) {
        tr1[i].getElementsByTagName("td")[0].textContent = j++;
    }
}

function Deleted(IDSV) {
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    table1 = document.getElementById("TableSubject");
    tr1 = table1.getElementsByTagName("tr");
    var i = 1;
    while (i < tr1.length) {
        td = tr1[i].getElementsByTagName("td")[1];
        if (IDSV == td.textContent) {
            $(tr1[i]).remove();
            sort();
            $.ajax({
                async: false,
                url: "/StudentSubject/GetForReturn?IDSV=" + IDSV,
                type: "GET",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    var html = '';
                    table = document.getElementById("TableStudent");
                    tr = table.getElementsByTagName("tr");
                    var n = tr.length - 1;
                    $.each(result.Student, function (key, item) {
                        html += '<tr>';
                        html += '<td style="text-align:center"><input style="margin:auto" name="ids[]" class="checkbox" type="checkbox"></td>';
                        html += '<td style="display:none">' + item.ID + '</td>';
                        html += '<td>' + item.MaSV + '</td>';
                        html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                        if (result.SubjectName == null) {
                            html += '<td></td>';
                        } else {
                            html += '<td>' + result.SubjectName + '</td>';
                        }
                        html += '</tr>'

                    });
                    if (tr[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
                        $('.tbody').html(html);
                    }
                    else {
                        $('.tbody').append(html);
                    }

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
        }
        else {
            i++;
        }
    }
    CheckDataNull();
}

function CheckDataNull() {
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    table1 = document.getElementById("TableSubject");
    tr1 = table1.getElementsByTagName("tr");
    if (tr.length == 1) {
        html = "";
        html += '<tr>';
        html += '<td colspan="4">Không có dữ liệu</td>';

        html += '</tr>';
        $('.tbody').html(html);
    }
    if (tr1.length == 1) {
        html = "";
        html += '<tr>';
        html += '<td colspan="4">Không có dữ liệu</td>';

        html += '</tr>';
        $('.tbodyresult').html(html);
    }
}

function DeleteInDatabase(IDSV) {
    $.ajax({
        async: false,
        url: "/StudentSubject/Delete?IDSV=" + IDSV,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == true) {
                Deleted(IDSV);
            }
            else {
                alert("Đã có lỗi xảy ra.Vui lòng thử lại");
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Save() {
    var IDBM = $("#BoMon").val();
    table = document.getElementById("TableSubject");
    tr = table.getElementsByTagName("tr");
    var list = new Array();
    if (tr.length == 1) {
        alert("Không có dữ liệu");
    }
    else if (tr[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
        alert("Không có dữ liệu");
    }
    else {

        for (i = 1; i < tr.length; i++) {
            if ($(tr[i]).hasClass("choosen")) {
                var StudentID = tr[i].getElementsByTagName("td")[1].textContent;
                list.push(StudentID);
            }
        }
        if (list.length == 0) {
            changeDropBoMon(IDBM);
        }
        else {
            $.ajax({
                url: "/StudentSubject/Add",
                data: JSON.stringify({ 'list': list, 'IDBM': IDBM }),
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    changeDropBoMon(IDBM);
                    toastr.success('Lưu thành công !');
                },
                error: function (errormessage) {
                    toastr.error('Lưu thất bại !');
                }
            });
        }
    }

}

function search() {
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("myInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    if ($("#searchfor").val() == 0) {

        if (filter == "") {
            changeDropKhoaHoc($("#KhoaHoc").val())
        }
        else {
            for (i = 1; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[2];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    }
    else {
        if (filter == "") {
            changeDropKhoaHoc($("#KhoaHoc").val())
        }
        else {
            for (i = 1; i < tr.length; i++) {
                td = tr[i].getElementsByTagName("td")[3];
                if (td) {
                    txtValue = td.textContent || td.innerText;
                    if (txtValue.toUpperCase().indexOf(filter) > -1) {
                        tr[i].style.display = "";
                    } else {
                        tr[i].style.display = "none";
                    }
                }
            }
        }
    }
}


