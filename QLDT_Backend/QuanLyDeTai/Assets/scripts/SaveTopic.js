$(window).on('load', function () {
    getListHocKy();
    changeDropHocKy($("#HocKy").val());

});

var html = "";
function changeDropThucTap(IDTT,search="") {
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
                    if (key == 0) {
                        html += '<td class="student">' + item.StudentID + '</td>';
                        html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                        html += '<td>' + item.Email + '</td>';
                        html += '<td>' + item.Phone + '</td>';
                        html += '<td>' + item.Order + '</td>';
                        if (item.Status == true) {

                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                        }
                        else {
                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                        }
                    }
                    else {
                        html += "<tr>";
                        html += '<td class="student">' + item.StudentID + '</td>';
                        html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                        html += '<td>' + item.Email + '</td>';
                        html += '<td>' + item.Phone + '</td>';
                        html += '<td>' + item.Order + '</td>';
                        if (item.Status == true) {

                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus(' + item.ID + ')" type="checkbox" class="primary" checked> <span class="slider round"></span></label ></td >';
                        }
                        else {
                            html += '<td align="center"><label class="switch " style="margin-bottom: 0px;"><input onclick="changeStatus('+ item.ID + ')" type="checkbox" class="primary"> <span class="slider round"></span></label ></td >';
                        }
                        html += "</tr>";
                    }
                    
                    
                });
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}  

//function for change status
function changeStatus(id,studentid) {

    $.ajax({
        url: "/TopicStudent/ChangeStatus/" + id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $("this").attr("checked", result.Status);
            table = document.getElementById("mytable");
            tr = table.getElementsByTagName("tr");
            
            for (i = 1; i < tr.length; i++) {
                td1 = tr[i].getElementsByTagName("td")[2];
                td2 = tr[i].getElementsByTagName("td")[0];
                txtValue1 = td1.textContent || td1.innerText;
                txtValue2 = td2.textContent || td2.innerText;
                if (studentid == txtValue1 || studentid == txtValue2) {
                    td = tr[i].getElementsByTagName("td");
                    for (j = 1; j < td.length; j++) {
                        if (j==0||j==1) {
                            td[j].style.backgroundColor = "white";
                        }
                        else {
                            
                            //td[j].style.backgroundColor = "#ddd";
                        }
                    }
                    //tr[i].style.display = "";
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