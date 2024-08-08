var contact = {
    init: function () {
        cart.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $("#txtName").val();
            var sdt = $("#txtSdt").val();
            var email = $("#txtEmail").val();
            var address = $("#txtAddress").val();
            var title = $("#txtTitle").val();
            var content = $("#txtContent").val();
   
        });
        $.ajax({
            url: "Contact/Send",
            type: "POST",
            dataType: "json",
            data: {
                name: name,
                sdt: sdt,
                address: address,
                email: email,
                title: title,
                content: content,
            },
            success: function (res) {
                if (res.status == true) {
                    alert("Gửi thành công!");
                }
            }
        });
    }
}
contact.init();