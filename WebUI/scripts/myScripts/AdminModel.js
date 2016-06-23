function ProductViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI 
    self.Id = ko.observable("");
    self.Name = ko.observable("");
    self.Price = ko.observable("");
    self.Description = ko.observable("");
    self.PictureUrl = ko.observable("");

    var Product = {
        Id: self.Id,
        Name: self.Name,
        Price: self.Price,
        Description: self.Description,
        PictureUrl: self.PictureUrl
    };

    self.Product = ko.observable();
    self.Products = ko.observableArray(); // Contains the list of products

    // Initialize the view-model
    self.init = function () {
        $.ajax({
            url: 'GetAllProducts',
            cache: false,
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                self.Products(data); //Put the response in ObservableArray
            }
        });
    }
    self.init();

    //Add New Item
    self.create = function () {
        if (Product.Name() != "" && Product.Price() != "") {
            self.Product.Id = 0;
            $.ajax({
                url: 'EditProduct',
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(Product),
                success: function (data) {
                    self.Products.push(data);
                    self.Name("");
                    self.Price("");
                    self.Description("");
                    self.PictureUrl("");

                }
            }).fail(
            function (xhr, textStatus, err) {
                alert(err);
            });

        }
        else {
            alert('Please Enter All the Values !!');
        }

    }
    // Delete product details
    self.delete = function (Product) {        
        if (confirm('Are you sure to Delete "' + Product.Name + '" product ??')) {           
            var id = Product.Id;
            $.ajax({
                url: 'DeleteProduct/'+id,
                cache: false,
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: ko.toJSON(id),
                success: function (data) {
                    self.Products.remove(Product);

                }
            }).fail(
            function (xhr, textStatus, err) {
                alert(id);
            });
        }
    }

    // Edit product details
    self.edit = function (Product) {
        self.Product(Product);

    }

    // Update product details
    self.update = function () {
        var Product = self.Product();

        $.ajax({
            url: 'EditProduct',
            cache: false,
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            data: ko.toJSON(Product),
            success: function (data) {
                self.Products.removeAll();
                self.Products(data); //Put the response in ObservableArray
                self.Product(null);
                alert("Record Updated Successfully");
                self.init();
            }
        })
        .fail(
        function (xhr, textStatus, err) {
            alert(err);
        });
    }

    // Reset product details
    self.reset = function () {
        self.Name("");
        self.Price("");
        self.Description("");
    }

    // Cancel product details
    self.cancel = function () {
        self.Product(null);

    }
}
var viewModel = new ProductViewModel();
ko.applyBindings(viewModel);
