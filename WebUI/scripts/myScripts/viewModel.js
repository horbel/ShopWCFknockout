var products = new Object();

$.getJSON('Home/GetAllProducts', function (data) {
    products = data;    
    ko.applyBindings(products);


    $('.product-title, .product-img').click(function () {
        GetProduct($(this).attr('data-id'));
    })
})


function GetProduct(id) {
    var product = new Object();
    $.getJSON('Home/GetProduct?id='+id, function (data) {
        product = data;    
        alert(product.Name);
        })
}
//function SaveBrandChange(brand) {
//    var newBrand = {
//        ID: $('#edit-brand-id').val(),
//        Name: $('#edit-brand-name').val()
//    }
//    $.ajax({
//        url: '/api/brand/' + newBrand.ID,
//        type: 'PUT',
//        data: JSON.stringify(newBrand),
//        contentType: "application/json;charset=utf-8",
//        success: function (data) {
//            $('#edit-brand-block').css('display', 'none');
//            $('#table-block').css('display', 'block');
//            GetAllBrands(function (brands) { ShowAllBrands(brands) })
//        },
//        error: function (x, y, z) {
//            alert(x + '\n' + y + '\n' + z);
//        }
//    })
//}

