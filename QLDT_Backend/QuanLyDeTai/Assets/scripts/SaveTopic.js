$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($("#HocKy").val());

});

var html = "";
var data = [];
function changeDropThucTap(IDTT, search = "") {
    data = [];
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    html = "";
    var IDHK = $("#HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/TopicStudent/GetListForSave?IDHK=" + IDHK + "&IDTT=" + IDTT + "&search=" + search,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.List == "") {

                html += '<tr>';
                html += '<td colspan="8">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                var n = 0;
                $.each(result.List, function (key, item) {
                    check(item.ID);
                });
                $.each(result.List, function (key, item) {
                    if (result.Count[n] == 0) {
                        html += '<tr>';
                        html += '<td class="rowspan" align="center" rowspan="' + 1 + '">' + (i++) + '</td>';
                        html += '<td class="rowspan" rowspan="' + 1 + '">' + item.TopicName + '</td>';
                        n++;

                        getListByTopicId(item.ID);
                    } else {
                        html += '<tr>';
                        html += '<td align="center" rowspan="' + result.Count[n] + '">' + (i++) + '</td>';
                        html += '<td rowspan="' + result.Count[n] + '">' + item.TopicName + '</td>';
                        n++;
                        getListByTopicId(item.ID);
                    }

                    html += '</tr>';
                    
                });
                $('.tbody').html(html);
                html = '<button id="edit" onclick="Save()"  style = "float: right;border-radius: 2%;" class="btn btn-outline-info btn-primary" ><i class="fa fa-save"></i> Lưu lại</button >'
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

    if (filter == "") {
        changeDropThucTap($("#LoaiTT").val());
    }
    else {
        changeDropThucTap($("#LoaiTT").val(), input.value, PgNumber = 0, PgSize = $("#maxRows").val());
    }

}

function getListByTopicId(TopicID) {

    $.ajax({
        async: false,
        url: "/TopicStudent/getListByTopicId?TopicID=" + TopicID ,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result == "") {
                html += '<td colspan="6">Không có dữ liệu</td>';
            }
            else {
                $.each(result, function (key, item) {
                    if (item.Status == true) {
                        if (key == 0) {
                            html += '<td style="display:none">' + item.ID + '</td>';
                            html += '<td class="student">' + item.StudentID + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.Email + '</td>';
                            html += '<td>' + item.Phone + '</td>';
                            html += '<td>' + item.Order + '</td>';
                            if (item.Status == true) {
                                var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                            }
                            else {
                                var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                            }
                        }
                        else {
                                html += "<tr>";
                            html += '<td style="display:none">' + item.ID + '</td>';
                            html += '<td class="student">' + item.StudentID + '</td>';
                            html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                            html += '<td>' + item.Email + '</td>';
                            html += '<td>' + item.Phone + '</td>';
                            html += '<td>' + item.Order + '</td>';
                            if (item.Status == true) {
                                var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                            }
                            else {
                                var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                            }
                            html += "</tr>";
                        }

                    }
                    else {
                        var index = data.findIndex(i => i == item.StudentID);
                        if (index === -1) {
                            if (key == 0) {
                                html += '<td style="display:none">' + item.ID + '</td>';
                                html += '<td class="student">' + item.StudentID + '</td>';
                                html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                                html += '<td>' + item.Email + '</td>';
                                html += '<td>' + item.Phone + '</td>';
                                html += '<td>' + item.Order + '</td>';
                                if (item.Status == true) {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                    html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                                }
                                else {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                    html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                                }
                            }
                            else {
                                html += "<tr>";
                                html += '<td style="display:none">' + item.ID + '</td>';
                                html += '<td class="student">' + item.StudentID + '</td>';
                                html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                                html += '<td>' + item.Email + '</td>';
                                html += '<td>' + item.Phone + '</td>';
                                html += '<td>' + item.Order + '</td>';
                                if (item.Status == true) {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                    html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                                }
                                else {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                    html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                                }
                                html += "</tr>";
                            }
                        }
                        else {
                            if (key == 0) {
                                html += '<td style="display:none">' + item.ID + '</td>';
                                html += '<td class="student" style="background-color:#eaeaea">' + item.StudentID + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.FirstName + " " + item.LastName + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Email + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Phone + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Order + '</td>';
                                if (item.Status == true) {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                    html += '<td style="background-color:#eaeaea" align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                                }
                                else {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",0)';
                                    html += '<td style="background-color:#eaeaea"  align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                                }
                            }
                            else {
                                html += "<tr>";
                                html += '<td style="display:none">' + item.ID + '</td>';
                                html += '<td class="student" style="background-color:#eaeaea">' + item.StudentID + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.FirstName + " " + item.LastName + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Email + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Phone + '</td>';
                                html += '<td style="background-color:#eaeaea">' + item.Order + '</td>';
                                if (item.Status == true) {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                    html += '<td style="background-color:#eaeaea" align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                                }
                                else {
                                    var change = 'changeStatus(' + item.ID + ',"' + item.StudentID + '",1)';
                                    html += '<td style="background-color:#eaeaea" align="center"><label class="switch " style="margin-bottom: 0px;"><input id=' + item.ID + ' onclick=' + change + ' type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                                }
                                html += "</tr>";
                            }
                        }
                    }
                    
                    
                });
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

function check(TopicID) {

    $.ajax({
        async: false,
        url: "/TopicStudent/getListByTopicId?TopicID=" + TopicID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

                $.each(result, function (key, item) {
                    if (item.Status == true) {
                        data.push(item.StudentID);
                    }
                });

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  
//function for change status
function changeStatus(id,studentid,number) {
    $.ajax({
        url: "/TopicStudent/ChangeStatus/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if ($("#"+id).is(':checked')) {
                $("this").attr("checked", result.Status);
                table = document.getElementById("mytable");
                tr = table.getElementsByTagName("tr");

                for (i = 1; i < tr.length; i++) {
                    if (number == 0) {
                        td1 = tr[i].getElementsByTagName("td")[2];
                        td2 = tr[i].getElementsByTagName("td")[3];
                        txtValue1 = td1.textContent || td1.innerText;
                        txtValue2 = td2.textContent || td2.innerText;
                        if (studentid == txtValue2) {
                            td = tr[i].getElementsByTagName("td");
                            for (j = 1; j < td.length; j++) {
                                if (id == txtValue1) {
                                    
                                    td[j].style.backgroundColor = "white";
                                }
                                else if (j == 0 || j == 1) {
                                    td[j].style.backgroundColor = "white";
                                }
                                else {
                                    $("#" + txtValue1).attr("checked", false);
                                    td[j].style.backgroundColor = "#eaeaea";
                                }
                            }
                            //tr[i].style.display = "";
                        }
                    }
                    else {
                        td1 = tr[i].getElementsByTagName("td")[0];
                        td2 = tr[i].getElementsByTagName("td")[1];
                        txtValue1 = td1.textContent || td1.innerText;
                        txtValue2 = td2.textContent || td2.innerText;
                        if (studentid == txtValue2) {
                            td = tr[i].getElementsByTagName("td");
                            for (j = 1; j < td.length; j++) {
                                if (id == txtValue1) {
                                    td[j].style.backgroundColor = "white";
                                }
                                else {
                                    $("#" + txtValue1).attr("checked", false);
                                    td[j].style.backgroundColor = "#eaeaea";
                                }
                            }
                            //tr[i].style.display = "";
                        }
                    }

                }
            } else {
                $("this").attr("checked", result.Status);
                table = document.getElementById("mytable");
                tr = table.getElementsByTagName("tr");

                for (i = 1; i < tr.length; i++) {
                    if (number == 0) {
                        td1 = tr[i].getElementsByTagName("td")[2];
                        td2 = tr[i].getElementsByTagName("td")[3];
                        txtValue1 = td1.textContent || td1.innerText;
                        txtValue2 = td2.textContent || td2.innerText;
                        if (studentid == txtValue2) {
                            td = tr[i].getElementsByTagName("td");
                            for (j = 1; j < td.length; j++) {
                                if (id == txtValue1) {
                                    td[j].style.backgroundColor = "white";
                                }
                                else if (j == 0 || j == 1) {
                                    td[j].style.backgroundColor = "white";
                                }
                                else {

                                    td[j].style.backgroundColor = "white";
                                }
                            }
                            //tr[i].style.display = "";
                        }
                    }
                    else {
                        td1 = tr[i].getElementsByTagName("td")[0];
                        td2 = tr[i].getElementsByTagName("td")[1];
                        txtValue1 = td1.textContent || td1.innerText;
                        txtValue2 = td2.textContent || td2.innerText;
                        if (studentid == txtValue2) {
                            td = tr[i].getElementsByTagName("td");
                            for (j = 1; j < td.length; j++) {
                                if (id == txtValue1) {
                                    td[j].style.backgroundColor = "white";
                                }
                                else {

                                    td[j].style.backgroundColor = "white";
                                }
                            }
                            //tr[i].style.display = "";
                        }
                    }

                }
            }
            
            toastr.success('Cập nhật trạng thái thành công !');
        },

        error: function (errormessage) {
            toastr.error('Cập nhật trạng thái thất bại !');
        }
    });
    return false;
}