var common = {
    init: function () {
        common.registerEvents();
    },
    registerEvents: function () {
        $("#search-product").autocomplete({
            minLength: 1,
            source: function (request, response) {
                $.ajax({
                    url: "/Product/GetListProductByName",
                    dataType: "json",
                    data: {
                        keyword: request.term
                    },
                    success: function (res) {
                        response(res.data);
                    }
                });
            },
            focus: function (event, ui) {
                $("#search-product").val(ui.item.label);
                return false;
            },
            select: function (event, ui) {
                $("#search-product").val(ui.item.label);
                return false;
            }
        }).autocomplete("instance")._resizeMenu = function () {
            var ul = this.menu.element;
            ul.outerWidth(this.element.outerWidth());
        };
    }
}
common.init();