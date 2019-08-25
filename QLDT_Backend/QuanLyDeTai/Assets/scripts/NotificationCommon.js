/// <reference path="studentpracticecontrol.js" />
$(window).on('load', function () {
    GetNotification();

});

function GetNotification() {
    $.ajax({
        url: "/Notification/GetbyStudentID/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var i = 0;
            if (result == "") {
                
                html += '<li><a href="#" class="notification-item"><span class="dot bg-warning"></span>Không có dữ liệu</a></li>';

                
                $('.nt').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    
                    if (item.Status == null || item.Status == false) {
                        html += '<li><a href="#" style="background-color:#eaeaea" class="notification-item" onclick="info(' + item.ID + ')"><span class="dot bg-danger"></span>' + item.Title + '</a></li>';
                    }
                    else {
                        html += '<li><a href="#" class="notification-item" onclick="info(' + item.ID + ')"><span class="dot bg-danger"></span>' + item.Title + '</a></li>';
                    }
                    i++;
                });

                html += '<li><a href="" class="more">Đọc tất cả</a></li>';
                $('.nt').html(html);
                $('.bg').html(i);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon ID  
function info(ID) {
    GetNotification();
    $.ajax({
        url: "/Notification/GetbyID/" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $.each(result, function (key, item) {
                $('#title').text(item.Title);
                $('#content').text(item.Content);
                changeStatus(item.StNotificationID)
            });
            $('#xemthongbao').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}
function changeStatus(ID) {
    $.ajax({
        url: "/Notification/ChangeStatus?id=" + ID,
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
