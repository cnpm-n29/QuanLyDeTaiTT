//Common
//Combobox loai thuctap
//Lay het gia tri cua loai thuctap
function getListLoaiTT() {
    $.ajax({
        url: "/List/listLoaiTT/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            
            var html = '<select class="LTT form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT">';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';
            });
            html += '</select>'
            $(".ddlLoaiTT").html(html);
            $(".CreateLoaiTT").html(html);
        },

        error: function (errormessage) {

        }
    });
    return false;
}


//combobox loai hoc ky 

function getListHocKy() {
    $.ajax({
        url: "/List/listHocKy/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="HocKy" class="HK form-control" onchange = "changeDropHocKy(this.value)">';
            html += '<option disabled > -- Chọn loại học kỳ -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SemesterName + '</option>';
            });
            html += '</select>'
            $(".ddlHocKy").html(html);
            $(".CreateHocKy").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}


//combobox khoa hoc
function getListKhoaHoc() {
    $.ajax({
        url: "/List/listKhoaHoc/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="KhoaHoc" class="form-control" onchange ="changeDropKhoaHoc(this.value)">';
            html += '<option disabled > -- Chọn loại khóa học -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.FacultyName + '</option>';
            });
            html += '</select>'
            $(".ddlKhoaHoc").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//combobox khoa hoc
function getListKhoaHoc2() {
    $.ajax({
        url: "/List/listKhoaHoc/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="KhoaHoc" name="FacultyId" class="form-control">';
            html += '<option disabled > -- Chọn loại khóa học -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.FacultyName + '</option>';
            });
            html += '</select>'
            $(".ddlKhoaHoc1").html(html);
            $(".ddlKhoaHoc2").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//combo bộ môn
function getListBoMon() {
    $.ajax({
        url: "/List/ListBoMon/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="BoMon" class="form-control" onchange ="changeDropBoMon(this.value)">';
            html += '<option disabled > -- Chọn bộ môn -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.SubjectName + '</option>';
            });
            html += '</select>'
            $(".ddlBoMon").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//combo Giảng viên
function getListGiangVien() {
    $.ajax({
        url: "/List/ListGiangVien/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="GiangVien"  class="form-control" onchange ="changeDropGiangVien(this.value)">';
            html += '<option disabled > -- Chọn giảng viên -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.FirstName + " " + item.LastName + '</option>';
            });
            html += '</select>'
            $(".ddlGiangVien").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
//=================Topic-Index===========================

//thay doi dropdown hoc ky
function changeDropHocKy(IDHK) {
    $.ajax({
        url: "/Topic/GetLoaiTTByHK/" + IDHK,
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            var html = '<select class="LTT form-control" onchange = "changeDropThucTap(this.value)" id="LoaiTT" >';
            html += '<option disabled> -- Chọn loại thực tập -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.PracticeName + '</option>';
                
            });
            html += '</select>'
            
            $(".ddlLoaiTT").html(html);
            changeDropThucTap($("#LoaiTT").val());
            var IDTT = $(".LoaiTT #LoaiTT").val();
            $("#export").attr("href", "/TopicStudent/Export?SemesterID=" + IDHK + "&PracticeID=" + IDTT);
        },

        error: function (errormessage) {

        }
    });
    return false;
}

function getListLinhVuc() {
    $.ajax({
        url: "/StudentField/GetList/",
        type: "GET",
        async: false,
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            var html = '<select id="LinhVuc" class="form-control">';
            html += '<option disabled > -- Chọn loại lĩnh vực -- </option>';
            $.each(result, function (key, item) {
                html += '<option value=' + item.ID + '>' + item.FieldName + '</option>';
            });
            html += '</select>'
            $(".ddlLinhvuc").html(html);
        },

        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}





