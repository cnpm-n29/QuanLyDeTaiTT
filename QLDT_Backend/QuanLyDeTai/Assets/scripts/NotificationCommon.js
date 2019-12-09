/// <reference path="studentpracticecontrol.js" />
$(window).on('load', function () {
    GetNotification();

});

function GetNotification() {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    $.ajax({
        url: "/Notification/GetbyStudentIDLimit/",
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
                        i++;
                    }
                    else {
                        html += '<li><a href="#" class="notification-item" onclick="info(' + item.ID + ')"><span class="dot bg-danger"></span>' + item.Title + '</a></li>';
                    }

                });

                html += '<li><a onclick="GetAllNotification()" class="more">Đọc tất cả</a></li>';
                $('.nt').html(html);
                $('.bg').html(i);
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
}

function GetAllNotification() {
    $.ajax({
        url: "/Notification/GetbyStudentID/",
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            var html = '';
            var i = 0;
            if (result == "") {

                html += '<li>Không có thông báo nào</li>';


                $('#allnotification').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    changeStatus(item.ID);
                    if (parseInt(item.Day) < 10) {
                        item.Day = "0" + item.Day;
                    }
                    if (parseInt(item.Month) < 10) {
                        item.Month = "0" + item.Month;
                    }
                    if (parseInt(item.Hour) < 10) {
                        item.Hour = "0" + item.Hour;
                    }
                    if (parseInt(item.Minute) < 10) {
                        item.Minute = "0" + item.Minute;
                    }
                    if (item.Status == null || item.Status == false) {
                        html += ' <a href="#" class="list-group-item list-group-item-action flex-column align-items-start"><div class="d-flex w-100 justify-content-between" ><h5 class="mb-1" style="font-weight: bolder;color: mediumblue;">' + item.Title + '</h5></div ><p class="mb-1">' + item.Content + '</p><small>' + item.Hour + ":" + item.Minute + " " + item.Day + "/" + item.Month + "/" + item.Year +'</small></a>';
                    }
                    else {
                        html += ' <a href="#" class="list-group-item list-group-item-action flex-column align-items-start"><div class="d-flex w-100 justify-content-between" ><h5 class="mb-1" style="font-weight: bolder;color: mediumblue;">' + item.Title + '</h5></div ><p class="mb-1">' + item.Content + '</p><small>' + item.Hour + ":" + item.Minute + " " + item.Day + "/" + item.Month + "/" + item.Year +'</small></a>';
                    }

                });
                
                $('#allnotification').html(html);
            }
            $('#xemtatcathongbao').modal('show');
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
            toastr.success('Thay đổi trạng thái thành công !');
        },
        error: function (errormessage) {
            toastr.error('cập nhật lỗi !');
        }
    });

}
