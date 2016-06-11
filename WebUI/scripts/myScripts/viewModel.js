var products = new Object();

$.getJSON('Home/GetAllProducts', function (data) {
    products = data;
    products.PriceStr = products.Price + '$';
    ko.applyBindings(products);
})