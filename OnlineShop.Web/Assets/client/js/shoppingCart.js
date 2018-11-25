var cart = {
    init: function () {
        cart.loadData();
        cart.registerEvent();
    },
    registerEvent: function () {
        $('#btnAddToCart').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.addItem(productId);
        });

        $('.btnDeleteItem').off('click').on('click', function (e) {
            e.preventDefault();
            var productId = parseInt($(this).data('id'));
            cart.deleteItem(productId);
        });

        $('.num-product').off('keyup').on('keyup', function () {
            var quantity = parseInt($(this).val());
            var productid = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {

                var amount = quantity * price;

                $('#amount_' + productid).text("\$ " + amount);
            }
            else {
                $('#amount_' + productid).text(0);
            }
        });

        $(".btn-num-product-down").on("click", function () {

            var $button = $(this);
            var oldValue = $button.parent().find("input").val();

            if (oldValue != 1) {
                var newVal = parseFloat(oldValue) - 1;
            }
            else {
                var newVal = 1;
            }

            $button.parent().find("input").val(newVal);

            var quantity = parseInt(newVal);
            var productid = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {

                var amount = quantity * price;

                $('#amount_' + productid).text("\$ " + amount);
            }
            else {
                $('#amount_' + productid).text(0);
            }
        });

        $(".btn-num-product-up").on("click", function () {

            var $button = $(this);
            var oldValue = $button.parent().find("input").val();

            var newVal = parseFloat(oldValue) + 1;

            $button.parent().find("input").val(newVal);

            var quantity = parseInt(newVal);
            var productid = parseInt($(this).data('id'));
            var price = parseFloat($(this).data('price'));
            if (isNaN(quantity) == false) {

                var amount = quantity * price;

                $('#amount_' + productid).text("\$ " + amount);
            }
            else {
                $('#amount_' + productid).text(0);
            }
        });

    },

    addItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/Add',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    alert('Đã thêm sản phẩm vào giỏ hàng.');
                }
            }
        });
    },

    deleteItem: function (productId) {
        $.ajax({
            url: '/ShoppingCart/DeleteItem',
            data: {
                productId: productId
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                }
            }
        });
    },

    loadData: function () {
        $.ajax({
            url: '/ShoppingCart/GetAll',
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var template = $('#tplCart').html();
                    var html = '';
                    var data = res.data;
                    $.each(data, function (i, item) {
                        html += Mustache.render(template, {
                            ProductId: item.ProductId,
                            Image: item.Product.Image,
                            ProductName: item.Product.Name,
                            Price: item.Product.Price,
                            PromotionPrice: item.Product.PromotionPrice,
                            Quantity: item.Quantity,
                            Amount: item.Quantity * item.Product.Price
                        });
                    });

                    $('#cartBody').html(html);
                    cart.registerEvent();
                }
            }
        })
    }
}
cart.init();