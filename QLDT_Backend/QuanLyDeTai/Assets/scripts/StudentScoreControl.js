$(window).on('load', function () {
    getListLoaiTT();
    changeDropThucTap($("#LoaiTT").val());
});

//Thay doi dropdown cua thuc tap
function changeDropThucTap(Id) {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    var i = 1;
    $.ajax({
        async: false,
        url: "/Score/GetByThucTap?IDTT=" + Id,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            if (result == "") {
                html += '<tr>';
                html += '<td colspan="6">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                html += '<tr>';
                html += '<td align="center">' + (i++) + '</td>';
                if (result.TopicName != null) {
                    html += '<td>' + result.TopicName + '</td>';
                }
                else {
                    html += '<td></td>';
                }
                if (result.CompanyScore != null) {
                    html += '<td align="center">' + result.CompanyScore + '</td>';
                }
                else {
                    html += '<td></td>';
                }
                if (result.TeacherScore != null) {
                    html += '<td align="center">' + result.TeacherScore + '</td>';
                }
                else {
                    html += '<td></td>';
                } if (result.ReportScore != null) {
                    html += '<td align="center">' + result.ReportScore + '</td>';
                }
                else {
                    html += '<td></td>';
                } if (result.TotalScore != null) {
                    html += '<td align="center">' + result.TotalScore + '</td>';
                }
                else {
                    html += '<td></td>';
                }
                    html += '</tr>';
                    $('.tbody').html(html);
                
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
} 