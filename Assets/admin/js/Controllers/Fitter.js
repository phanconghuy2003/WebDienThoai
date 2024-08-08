
var fiter = {
    init: function () {
        fiter.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "FiterNSX",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.status == true) {
                        btn.text('Hoạt động');
                    }
                    else {
                        btn.text('Khoá');
                    }
                }
            });
        });
    }
}
fiter.init();