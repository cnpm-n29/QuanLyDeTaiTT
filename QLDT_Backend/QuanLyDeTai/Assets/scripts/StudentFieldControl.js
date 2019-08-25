$(window).on('load', function () {
    load();
    //loadcheck();
   
});

function load() {
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

                }
                else {
                    alert('Đã xảy ra lỗi!');
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
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
               
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

