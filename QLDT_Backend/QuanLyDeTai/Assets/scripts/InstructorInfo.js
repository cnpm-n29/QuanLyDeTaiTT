$(window).on('load', function () {
    getInfo();

});

function getInfo() {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    $.ajax({
        async: false,
        url: "/StudentTeacher/GetInfo",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result=="") {
                html += "Chưa được phân Giáo viên hướng dẫn";
                $('.tbody').html(html);
            }
            else {
                $('#mssv').val(result.MaSV);
                $('#stname').val(result.StFirstName + " " + result.StLastName);
                $('#stbirthday').val(result.StBirthday);
                $('#staddress').val(result.StAddress);
                $('#stemail').val(result.StEmail);
                $('#stphone').val(result.StPhone);
                $('#tcname').val(result.TcFirstName + " " + result.TcLastName);
                $('#ctsubject').val(result.TcSubject);
                $('#ctbirthday').val(result.TcBirthday);
                $('#ctaddress').val(result.TcAddress);
                $('#ctemail').val(result.TcEmail);
                $('#ctphone').val(result.TcPhone);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
}