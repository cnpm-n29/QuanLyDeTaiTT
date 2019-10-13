$(window).on('load', function () {
    getListHocKy();
    getListBoMon2();
    changeDropBoMon($("#BoMon").val());
    changeDropHocKy($("#HocKy").val());
    changeDropThucTap($("#LoaiTT").val());
    var lastChecked = null;

    var $chkboxes = $('.checkbox');
    $chkboxes.click(function (event) {
        if (!lastChecked) {
            lastChecked = this;
            return;
        }

        if (event.shiftKey) {
            var start = $chkboxes.index(this);
            var end = $chkboxes.index(lastChecked);

            $chkboxes.slice(Math.min(start, end), Math.max(start, end) + 1).attr('checked', lastChecked.checked);

        }

        lastChecked = this;
    });

});

function getListBoMon2() {
    $.ajax({
        url: "/List/ListBoMon/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="BoMon" class="form-control" onchange ="changeDropBoMon(this.value)">';
            html += '<option disabled > -- Chọn bộ môn -- </option>';
            html += '<option value=0>Tất cả</option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SubjectName + '</option>';
            });
            html += '</select>'
            $(".ddlBoMon").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

var lastChecked = null;

function changeCheck(key) {
    var $chkboxes = $('.checkboxteacher');
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


//Thay doi dropdown cua bomon
function changeDropBoMon(IDBM) {
    var i = 1;
    $.ajax({
        async: false,
        url: "/Teacher/GetListBySubject?SubjectId=" + IDBM ,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result == "" || result==null) {
                html += '<tr>';
                html += '<td colspan="5">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                var n = 0;
                $.each(result, function (key, item) {
                    html += '<tr >';
                    html += '<td>' + (i++) + '</td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.MaGV + '</td>';
                    html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                    html += '<td>' + item.Birthday + '</td>';
                    
                    html += '<td style="text-align:center"><input onclick="changeCheck(' + key + ')" style="margin:auto" id="' + key + '" class="checkboxteacher" type="checkbox"></td>';
                    html += "</tr>";
                });
                $('.tbody').html(html);
            }
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

$("#select_checkbox_teacher").click(function () {
    if ($('#select_checkbox_teacher').is(':checked')) {
        $(".checkboxteacher").prop("checked", true);
    } else {
        $(".checkboxteacher").prop("checked", false);
    }
});

function assignedReport() {
    var IDTT = $("#LoaiTT").val();
    if (IDTT != "1") {
        $("#btn-random").addClass("display");
    }
    else {
        $("#btn-random").removeClass("display");
    }
    var i = 1;
    dem = 0;
    table = document.getElementById("myTable");
    tr = table.getElementsByTagName("tr");
    var html = '<select id="GiangVien"  class="select form-control selectpicker" data-live-search="true" onchange ="changeDropGiangVien(this.value)">';
    html += '<option disabled > -- Chọn giảng viên -- </option>';
    while (i < tr.length) {
        
        if ($(tr[i].getElementsByTagName("td")[5]).find("input").is(":checked")) {
            html += '<option value=' + tr[i].getElementsByTagName("td")[1].textContent + '>' + tr[i].getElementsByTagName("td")[3].textContent + '</option>';
            dem++;
            if (dem == 1) {
                changeDropGiangVien(tr[i].getElementsByTagName("td")[1].textContent);
            }
        }
        i++;
    }

    html += '</select>'
    if (dem != 0) {
        $(".ddlGiangVien").html(html);
        $(".form-search").removeClass("display");
        $(".main1").addClass("display");
        $(".main2").removeClass("display");
    }
    else {
        $("#error").modal("show");
    }
    
}

function Back() {
    $(".form-search").addClass("display");
    $(".main1").removeClass("display");
    $(".main2").addClass("display");
}

function getDetailReport(IDGV) {
    var i = 1;
    $.ajax({
        async: false,
        url: "/StudentPractice/GetByTeacherReport?teacherID=" + IDGV,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "" || result.List==null) {
                html += '<tr>';
                html += '<td colspan="4">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbodyteacher').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr >';

                    html += '<td style="text-align:center">' + (i++) + '</td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
                    html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';

                    html += ' <td align="center"><a onclick="DeleteInDatabase(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                    html += '</tr>';
                });
                $('.tbodyteacher').html(html);
                
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}


function changeDropThucTap(IDTT) {
    var IDHK = $("#HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/StudentPractice/GetByKHvaLoaiTTReport?IDHK=" + IDHK + "&IDTT=" + IDTT ,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.List == "" || result.List==null) {
                html += '<tr>';
                html += '<td colspan="4">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbodystudent').html(html);
            }
            else {
                $.each(result.List, function (key, item) {
                    html += '<tr>';
                    html += '<td style="text-align:center"><input onclick="changeCheck(' + key + ')" style="margin:auto" id="' + key + '" class="checkbox" type="checkbox"></td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.Masv + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.TeacherName + '</td>';
                    html += '</tr>';
                });
                $('.tbodystudent').html(html);
                
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

function Report() {
    var IDHK = parseInt($("#HocKy").val());
    var IDTT = parseInt($("#LoaiTT").val());
    var listteacher = new Array();
    $("#GiangVien option").each(function (i) {
        if (i != 0) {
            listteacher.push($(this).val());
        }
    });
    $.ajax({
        async: false,
        url: "/StudentPractice/Random",
        data: JSON.stringify({ 'IDHK': IDHK, 'IDTT': IDTT, "listteacher": listteacher }),
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            changeDropGiangVien($('#GiangVien').val());
            toastr.success('Sắp xếp thành công !');
        },
        error: function (errormessage) {
            toastr.error('Sắp xếp thất bại !');
        }
    });
}  




//Thay doi dropdown cua thuc tap
function changeDropGiangVien(IDGV) {
    var IDHK = $("#HocKy").val();
    var IDTT = $("#LoaiTT").val();
    $.ajax({
        async: false,
        url: "/StudentPractice/GetByTeacher?IDHK=" + IDHK + "&IDTT=" + IDTT+ "&IDGV=" + IDGV,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result.Student == "") {
                html += '<tr>';
                html += '<td colspan="4">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbodystudent').html(html);
            }
            else {
                var n = 0;
                $.each(result.Student, function (key, item) {
                    html += '<tr >';
                    html += '<td style="text-align:center"><input style="margin:auto" name="ids[]" class="checkbox" type="checkbox"></td>';
                    html += '<td style="display:none">' + item.ID + '</td>';
                    html += '<td>' + item.Masv + '</td>';
                    html += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';
                    html += '<td>' + item.TeacherName+'</td>';
                    html += "</tr>";

                });
                $('.tbodystudent').html(html);
            }
            if (result.StudentTeacher == "") {
                var rs = "";
                rs += '<tr>';
                rs += '<td colspan="4">Không có dữ liệu</td>';

                rs += '</tr>';
                $('.tbodyteacher').html(rs);
            }
            else {
                var i = 1;
                var rs = "";
                $.each(result.StudentTeacher, function (key, item) {
                    rs += '<tr >';

                    rs += '<td style="text-align:center">' + (i++) + '</td>';
                    rs += '<td style="display:none">' + item.ID + '</td>';
                    rs += '<td>' + item.Masv + '</td>';
                    rs += '<td>' + item.FirstName + ' ' + item.LastName + '</td>';

                    rs += ' <td align="center"><a onclick="DeleteInDatabase(' + item.ID + ')"><i style="color:red" class="fa fa-trash"></i></a></td>';
                    rs += '</tr>';
                })
                $('.tbodyteacher').html(rs);
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

var demmove = 0;
//lay cac gia tri cua checkbox duoc lua chon
$("#move").click(function () {
    demmove++;
    var ids = new Array();
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    table1 = document.getElementById("TableTeacher");
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
    if (demmove ==1) {
        var button = '<button id="edit" onclick="Save()"  style = "float: right; border-radius: 2 %; " class="btn btn-outline-info btn-primary" ><i class="fa fa-save"></i> Lưu lại</button >';

        $('#TableTeacher').after(button);
    }
    if (tr1[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
        $('.tbodyteacher').html(html);
    }
    else {
        $('.tbodyteacher').append(html);
    }

    sort();
    $("#select_checkbox").prop("checked", false);
    CheckDataNull();
});

function sort() {
    var j = 1;
    table1 = document.getElementById("TableTeacher");
    tr1 = table1.getElementsByTagName("tr");
    for (i = 1; i < tr1.length; i++) {
        tr1[i].getElementsByTagName("td")[0].textContent = j++;
    }
}

function Deleted(IDSV) {
    table = document.getElementById("TableStudent");
    tr = table.getElementsByTagName("tr");
    table1 = document.getElementById("TableTeacher");
    tr1 = table1.getElementsByTagName("tr");
    var i = 1;
    while (i < tr1.length) {
        td = tr1[i].getElementsByTagName("td")[1];
        if (IDSV == td.textContent) {
            $(tr1[i]).remove();
            sort();
            $.ajax({
                async: false,
                url: "/StudentPractice/GetForReturn?IDSV=" + IDSV,
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
                        if (result.TeacherName == null) {
                            html += '<td></td>';
                        } else {
                            html += '<td>' + result.TeacherName + '</td>';
                        }
                        html += '</tr>'

                    });
                    if (tr[1].getElementsByTagName("td")[0].textContent == "Không có dữ liệu") {
                        $('.tbodystudent').html(html);
                    }
                    else {
                        $('.tbodystudent').append(html);
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
    table1 = document.getElementById("TableTeacher");
    tr1 = table1.getElementsByTagName("tr");
    if (tr.length == 1) {
        html = "";
        html += '<tr>';
        html += '<td colspan="4">Không có dữ liệu</td>';

        html += '</tr>';
        $('.tbodystudent').html(html);
    }
    if (tr1.length == 1) {
        html = "";
        html += '<tr>';
        html += '<td colspan="4">Không có dữ liệu</td>';

        html += '</tr>';
        $('.tbodyteacher').html(html);
    }
}

function DeleteInDatabase(IDSV) {
    var IDHK = $("#HocKy").val();
    var IDTT = $("#LoaiTT").val();
    $.ajax({
        async: false,
        url: "/StudentPractice/DeleteReport?IDSV=" + IDSV + "&IDHK=" + IDHK + "&IDTT=" + IDTT,
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
    var IDHK = $("#HocKy").val();
    var IDTT = $("#LoaiTT").val();
    var IDGV = $("#GiangVien").val();
    table = document.getElementById("TableTeacher");
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
            changeDropGiangVien($("#GiangVien").val());
        }
        else {
            $.ajax({
                url: "/StudentPractice/AddReport",
                data: JSON.stringify({ 'list': list, 'IDGV': IDGV, 'IDHK': IDHK, 'IDTT': IDTT }),
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                async: false,
                success: function (result) {
                    changeDropGiangVien(IDGV);
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


