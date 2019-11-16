$(window).on('load', function () {
    load();
    //loadcheck();
   
});

function load() {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    $.ajax({
        async: false,
        url: "/StudentField/GetList",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr >';
                html += '<td align="center"><input id="' + item.ID + '" onclick="check(' + item.ID + ')" type="checkbox" ></td >';
                html += '<td style="display:none">' + item.ID + '</td>';
                html += '<td>' + item.FieldName + '</td>';
                html += '<td>' + item.Description + '</td>';

            });
            $('.tbody').html(html);
            loadcheck();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
}

function loadcheck() {
    $.ajax({
        async: false,
        url: "/StudentField/GetListByStudent",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                $("#" + item.FieldID).attr("checked", true);

            });

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function check(id) {
    if ($("#" + id).is(":checked")) {
        $.ajax({
            async: false,
            url: "/StudentField/Create?FieldId=" + id,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                if (result == true) {
                    toastr.success('Chọn thành công !');
                }
                else {
                    toastr.error('Chọn thất bại !');
                }
            },
            error: function (errormessage) {
                toastr.error('Đã có lỗi !');
            }
        });
    }
    else {
        $.ajax({
            async: false,
            url: "/StudentField/Delete?FieldId=" + id,
            type: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                toastr.success('Bỏ chọn thành công !');
            },
            error: function (errormessage) {
                toastr.error('Đã có lỗi !');
            }
        });
    }
}

