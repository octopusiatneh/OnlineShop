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
            $('#lblTotalOrder').text("\$ " + cart.getTotalOrder());

            cart.updateAll();
        });
        $(".btn-num-product-down").off('click').on("click", function () {
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
            $('#lblTotalOrder').text("\$ " + cart.getTotalOrder());

            cart.updateAll();
        });
        $(".btn-num-product-up").off('click').on("click", function () {
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
            $('#lblTotalOrder').text("\$ " + cart.getTotalOrder());

            cart.updateAll();
        });
        $('#btnContinue').off('click').on('click', function (e) {
            e.preventDefault();
            window.location.href = "/san-pham";
        });

        $('#btnCheckout').off('click').on('click', function (e) {
            e.preventDefault();
            $('#divCheckout').show();
        });

        $('#btnCreateOrder').off('click').on('click', function (e) {
            e.preventDefault();
            //var isValid = $('#frmPayment').valid();
            //if (isValid) {
            //    cart.createOrder();
            //}
            cart.createOrder();

        });
    },
    createOrder: function () {
        var order = {
            CustomerName: $('#txtName').val(),
            CustomerAddress: $('#txtAddress').val(),
            CustomerMobile: $('#txtPhone').val(),
            CustomerMessage: $('#txtMessage').val(),
            PaymentMethod: "Thanh toán tiền mặt",
            Status: false
        }
        $.ajax({
            url: '/ShoppingCart/CreateOrder',
            type: 'POST',
            dataType: 'json',
            data: {
                orderViewModel: JSON.stringify(order)
            },
            success: function (response) {
                if (response.status) {
                    console.log('create order ok');
                    $('#cartContent').hide();
                    cart.deleteAll();
                    setTimeout(function () {
                        $('#cartContent').show();
                        $('#cartContent').html('<h2 align="center" style="padding-bottom: 130px; padding-top: 50px; padding-left:50px">Bạn đã đặt hàng thành công. </br>Chúng tôi sẽ liên lạc với bạn qua số điện thoại bạn đã cung cấp để xác nhận đơn hàng.</h2>');
                    }, 100);

                }
            }
        });
    },

    getTotalOrder: function () {
        var listTextBox = $('.txtQuantity');
        var total = 0;
        $.each(listTextBox, function (i, item) {
            total += parseInt($(item).val()) * parseFloat($(item).data('price'));
        });
        return total;
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
    deleteAll: function () {
        $.ajax({
            url: '/ShoppingCart/DeleteAll',
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();                
                }
            }
            
        });
    },
    updateAll: function () {
        var cartList = [];
        $.each($('.txtQuantity'), function (i, item) {
            cartList.push({
                ProductId: $(item).data('id'),
                Quantity: $(item).val()
            });
        });
        $.ajax({
            url: '/ShoppingCart/Update',
            type: 'POST',
            data: {
                cartData: JSON.stringify(cartList)
            },
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    cart.loadData();
                    console.log('Update ok');
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
                    if (html == '') {
                        $('#cartContent').html('<h2 align="center" style="padding-bottom: 130px; padding-top: 50px; padding-left:50px">Không có sản phẩm nào trong giỏ hàng.</h2>');
                    }
                    $('#lblTotalOrder').text("\$ " + cart.getTotalOrder());
                    cart.registerEvent();
                }
            }
        })
    }
}
cart.init(); 