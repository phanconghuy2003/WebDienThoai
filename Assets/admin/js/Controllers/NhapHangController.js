
document.ready(function () {
    getAll();
})
function getAll() {
    $.ajax({
        url: "/Admin/NhapHang/DSPhieuNhapHang",
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.SOPHIEUNHAPHANG + '</td>';
                html += '<td>' + item.MA_NCC + '</td>';
                html += '<td>' + item.NGUOIGIAO + '</td>';
                html += '<td>' + item.NGAYGIAO + '</td>';
                html += '<td>' + item.TRANGTHAINHAPHANG + '</td>';
                html += '<td><a href="#" onclick="return getId(' + item.PHIEUNHAPHANG_ID + ')">Edit</a> | <a href="#" onclick="return _delete(' + item.PHIEUNHAPHANG_ID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('#example .tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    return false;
}
function getId() {
    $.ajax({
        url: '/NhapHang/GetPhieuNhapHang/' + id,
        // data: JSON.stringify(dto),
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#StudentId').val(result.StudentId);
            $('#Name').val(result.Name);
            $('#Status').val(result.Status);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Insert() {
    var obj = {
        SOPHIEUNHAPHANG: $('#SOPHIEUNHAPHANG').val(),
        MA_NCC: $('#MA_NCC').val(),
        NGUOIGIAO: $('#NGUOIGIAO').val(),
        NGAYGIAO: $('#NGAYGIAO').val(),
        TRANGTHAINHAPHANG: $('#TRANGTHAINHAPHANG').val()
    }
    $.ajax({
        url: '/Admin/NhapHang/CreatePhieuNhap',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            _getAll();
            $('#addModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Update() {
    var obj = {
        StudentId: $('#StudentId').val(),
        Name: $('#Name').val(),
        Status: $('#Status').val(),
    }
    $.ajax({
        url: '/Admin/NhapHang/CreatePhieuNhap',
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",

        success: function (result) {
            getAll();
            $('#EditModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function Delete(id) {
    var cf = confirm('Are you sure want to permanently delete this row?');
    if (cf) {
        $.ajax({
            url: '/Admin/NhapHang/CreatePhieuNhap' + id,
            type: "POST",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            async: true,
            success: function (result) {
                getAll();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}