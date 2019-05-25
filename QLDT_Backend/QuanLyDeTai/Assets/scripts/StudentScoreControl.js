$(window).on('load', function () {
    getListLoaiTT();
    changeDropThucTap($("#LoaiTT").val());
});

//Thay doi dropdown cua thuc tap
function changeDropThucTap(Id) {
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
                    html += '<td>' + result.TopicName + '</td>';
                    html += '<td>' + result.CompanyScore + '</td>';
                    html += '<td>' + result.TeacherScore + '</td>';
                    html += '<td>' + result.ReportScore + '</td>';
                    html += '<td>' + result.TotalScore + '</td>';
                    

                    html += '</tr>';
                    $('.tbody').html(html);
                
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
} 