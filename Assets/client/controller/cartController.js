var cart = {
    init: function () {
        cart.registerEvents();
    },
    registerEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        }
            )
    }
}
cart.init();