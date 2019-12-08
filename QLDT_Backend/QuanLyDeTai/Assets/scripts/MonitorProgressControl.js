$(window).on('load', function () {
    getListHocKy();

    changeDropHocKy($(".HocKy #HocKy").val());

   
});

//Thay doi dropdown cua thuc tap
function changeDropThucTap(IDTT, search = "") {
    $("#loading").removeClass("display");
    $(".main").addClass("opacity-bg");
    var IDHK = $(".HocKy #HocKy").val();
    var i = 1;
    $.ajax({
        async: false,
        url: "/TopicStudent/GetByKHvaLoaiTT?IDHK=" + IDHK + "&IDTT=" + IDTT + "&search=" + search ,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '';

            if (result == "") {
                html += '<tr>';
                html += '<td colspan="8">Không có dữ liệu</td>';

                html += '</tr>';
                $('.tbody').html(html);
            }
            else {
                $.each(result, function (key, item) {
                    var thread;
                        thread += "<tr>";
                        thread += '<th class="center-header" scope = "col" > STT</th>';
                        thread += '<th class="center-header" scope="col">Mã SV</th>';
                        thread += '<th class="center-header" scope="col">Họ tên</th>';
                        thread += '<th class="center-header" scope="col" style="width:30%;">Tên đề tài</th>';
                        thread += '<th class="center-header" scope="col">Tiến độ</th>';
                        thread += '<th class="center-header" scope="col">Kết quả</th>';
                        thread += '<th class="center-header" scope="col">Điểm</th>';
                        thread += '<th class="center-header" scope="col">Chi tiết</th>';
                        thread += '</tr>';


                    $('.thead').html(thread);
                    html += '<tr>';
                    html += '<td align="center">' + (i++) + '</td>';
                    html += '<td>' + item.MaSV + '</td>';
                    html += '<td>' + item.FirstName + " " + item.LastName + '</td>';
                    html += '<td>' + item.TopicName + '</td>';
                    if (item.Progress == 0) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Nhận đề tài</label ></td >';
                        
                    }
                    else if (item.Progress == 1) {
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 1</label ></td >';
                    }
                    else if (item.Progress == 2) {
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">BCTD lần 2</label ></td >';
                    }
                    if (item.Result == null) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Chưa đánh giá</label ></td >';
                        html += '<td align="center"></td >';

                    }
                    else if (item.Result == true) {

                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Đạt</label ></td >';
                        html += '<td align="center">' + item.TeacherScore + '</td>';
                    }
                    else{
                        html += '<td align="center"><label style="background-color:cornflowerblue;padding:5px;color:white">Không đạt</label ></td >';
                        html += '<td align="center"></td >';
                    }
                    
                    html += ' <td align="center"><a onclick="return getbyID(' + item.ID + ')"><i style="color:#009933" class="fa fa-edit"></i></a> </td>';

                    html += '</tr>';
                });
                $('.tbody').html(html);
                
                $("#export").attr("href", "/TopicStudent/Export?SemesterID=" + IDHK + "&PracticeID=" + IDTT);

            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    $("#loading").addClass("display");
    $(".main").removeClass("opacity-bg");
}

var id, progress;

//Function for getting the Data Based upon ID  
function getbyID(ID) {
    $('#SuaTenDeTai').css('border-color', 'lightgrey');
    $('#SuaMoTa').css('border-color', 'lightgrey');
    $.ajax({
        url: "/TopicStudent/GetbyID?id=" + ID,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            if (result.Result != null) {
                id = ID;
                progress = result.Progress;
                $('#thongbao').modal('show');
                
            }
            else if (result.Progress == 0) {
                    id = ID;
                progress = result.Progress;
                $('#step2').attr("disabled");
                $('#step2').removeClass('btn-success').addClass('btn-default');
                $('#step-2').hide();
                $('#step1').removeAttr("disabled");
                $('#step1').addClass('btn-success');
                $('#step-1').show();
                $('#step3').attr("disabled");
                $('#step3').removeClass('btn-success').addClass('btn-default');
                $('#step-3').hide();
                $('#giamsattd').modal('show');

                }
            else if (result.Progress == 1){
                $('#step1').attr("disabled");
                $('#step1').removeClass('btn-success').addClass('btn-default');
                $('#step-1').hide();
                $('#step2').removeAttr("disabled");
                $('#step2').addClass('btn-success');
                $('#step-2').show();
                $('#step3').attr("disabled");
                $('#step3').removeClass('btn-success').addClass('btn-default');
                $('#step-3').hide();
                id = ID;
                progress = result.Progress;
                $('#giamsattd').modal('show');
            }
            else if (result.Progress == 2) {
                $('#step1').attr("disabled");
                $('#step1').removeClass('btn-success').addClass('btn-default');
                $('#step-1').hide();
                $('#step-2').hide();
                $('#step3').removeAttr("disabled");
                $('#step3').addClass('btn-success');
                $('#step-3').show();
                $('#step2').attr("disabled");
                $('#step2').removeClass('btn-success').addClass('btn-default');
                id = ID;
                progress = result.Progress;
                $('#giamsattd').modal('show');
            }
            

        },
        error: function (errormessage) {
            $('#notification').addClass('alert-success');
            $('#notification').text('Đã xảy ra lỗi khi xét duyệt');
            myFunction();
        }
    });
            



}

$(document).ready(function () {

    var navListItems = $('div.setup-panel div a'),
        allWells = $('.setup-content'),
        allNextBtn = $('.nextBtn');



    navListItems.click(function (e) {
        e.preventDefault();
        var $target = $($(this).attr('href')),
            $item = $(this);

        //if (!$item.hasClass('disabled')) {
        //    navListItems.removeClass('btn-success').addClass('btn-default');
        //    $item.addClass('btn-success');
        //    allWells.hide();
        //    $target.show();
        //    $target.find('input:eq(0)').focus();
            
        //}
    });

    allNextBtn.click(function () {

        var curStep = $(this).closest(".setup-content"),
            curStepBtn = curStep.attr("id"),
            nextStepWizard = $('div.setup-panel div a[href="#' + curStepBtn + '"]').parent().next().children("a"),
            curInputs = curStep.find("input[type='text'],input[type='url']"),
            isValid = true;

        $(".form-group").removeClass("has-error");
        for (var i = 0; i < curInputs.length; i++) {
            if (!curInputs[i].validity.valid) {
                isValid = false;
                $(curInputs[i]).closest(".form-group").addClass("has-error");
            }
        }

        if (isValid) nextStepWizard.removeAttr('disabled').trigger('click');
        plus(id, ++progress);
    });

    $(".lose").click(function () {
        result(id, false);
        checkfalse(id);
        Reload();
    })
    $(".success").click(function () {
        var score = $("#score").val();
        if (score == null || score == "") {
            $('#giamsattd').modal('hide');
            $('#notification').addClass('alert-danger');
            $('#notification').text('Chưa nhập điểm');
            myFunction();
            
        }
        else if (isNaN(score) == false) {
            result(id, true);
            create(score, id);
            
            toastr.success('Thành công !');
            Reload();
        }
        
        else {
            $('#giamsattd').modal('hide');
            toastr.error('Lỗi khi xét duyệt !');
        }
        
    })

    $('div.setup-panel div a.btn-success').trigger('click');
});

function plus(id,progress) {
    $.ajax({
        url: "/TopicStudent/Plus?id=" + id + "&progress=" + progress,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.Progress == 0) {
                id = ID;
                progress = result.Progress;
                $('#step2').attr("disabled");
                $('#step2').removeClass('btn-success').addClass('btn-default');
                $('#step-2').hide();
                $('#step1').removeAttr("disabled");
                $('#step1').addClass('btn-success');
                $('#step-2').show();
                $('#step3').attr("disabled");
                $('#step3').removeClass('btn-success').addClass('btn-default');
                $('#giamsattd').modal('show');

            }
            else if (result.Progress == 1) {
                $('#step1').attr("disabled");
                $('#step1').removeClass('btn-success').addClass('btn-default');
                $('#step-1').hide();
                $('#step2').removeAttr("disabled");
                $('#step2').addClass('btn-success');
                $('#step-2').show();
                $('#step3').attr("disabled");
                $('#step3').removeClass('btn-success').addClass('btn-default');
                $('#step-3').hide();
                id = ID;
                progress = result.Progress;
                $('#giamsattd').modal('show');
            }
            else if (result.Progress == 2) {
                $('#step1').attr("disabled");
                $('#step1').removeClass('btn-success').addClass('btn-default');
                $('#step-1').hide();
                $('#step-2').hide();
                $('#step3').removeAttr("disabled");
                $('#step3').addClass('btn-success');
                $('#step-3').show();
                $('#step2').attr("disabled");
                $('#step2').removeClass('btn-success').addClass('btn-default');
                id = ID;
                progress = result.Progress;
                $('#giamsattd').modal('show');
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function result(id, result) {
    $.ajax({
        url: "/TopicStudent/Result?id=" + id + "&result=" + result,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function create(score, id) {
    var IDTT = $(".LoaiTT #LoaiTT").val();
    var IDHK = $(".HocKy #HocKy").val();
    $.ajax({
        url: "/Score/Create?SemesterID=" + IDHK + "&PracticeID=" + IDTT + "&Score=" + score + "&Id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Reload();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function checkfalse(id) {
    $.ajax({
        url: "/Score/CheckFalse?Id=" + id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function QuestionUpdate() {
    $('#thongbao').modal('hide');

    if (progress == 0) {
        $('#step2').attr("disabled");
        $('#step2').removeClass('btn-success').addClass('btn-default');
        $('#step-2').hide();
        $('#step1').removeAttr("disabled");
        $('#step1').addClass('btn-success');
        $('#step-1').show();
        $('#step3').attr("disabled");
        $('#step3').removeClass('btn-success').addClass('btn-default');
        $('#step-3').hide();
        $('#giamsattd').modal('show');

    }
    else if (progress == 1) {
        $('#step1').attr("disabled");
        $('#step1').removeClass('btn-success').addClass('btn-default');
        $('#step-1').hide();
        $('#step2').removeAttr("disabled");
        $('#step2').addClass('btn-success');
        $('#step-2').show();
        $('#step3').attr("disabled");
        $('#step3').removeClass('btn-success').addClass('btn-default');
        $('#step-3').hide();
        $('#giamsattd').modal('show');
    }
    else if (progress == 2) {
        $('#step1').attr("disabled");
        $('#step1').removeClass('btn-success').addClass('btn-default');
        $('#step-1').hide();
        $('#step-2').hide();
        $('#step2').removeClass('btn-success').addClass('btn-default');
        $('#step3').removeAttr("disabled");
        $('#step3').addClass('btn-success');
        $('#step-3').show();
        $('#step2').attr("disabled");

        $('#giamsattd').modal('show');
    }
}

function Reload() {
    changeDropThucTap($(".LoaiTT #LoaiTT").val());
}

function Export() {
    var IDTT = $(".LoaiTT #LoaiTT").val();
    var IDHK = $(".HocKy #HocKy").val();
    $("#export").attr("href", "/TopicStudent/Export?SemesterID=" + IDHK + "&PracticeID=" +IDTT);
}