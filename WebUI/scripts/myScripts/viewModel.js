
//var ViewModel = function () {
//    var self = this;    
//    this.init = function () {
//        $.getJSON('Home/GetAllProducts', function (data) {
//            self.products = data;
//            ko.applyBindings(self);
            
//        })
//    }
//    this.init();
//    this.products = ko.observableArray();


//}

//var myModel = new ViewModel();

//function GetProduct(id) {
//    var product = new Object();
//    $.getJSON('Home/GetProduct?id=' + id, function (data) {
//        product = data;
//        alert(product.Name);
//    })
//}

//****************************************************************************


function ProductViewModel() {

    //Make the self as 'this' reference
    var self = this;
    //Declare observable which will be bind with UI 
    self.Id = ko.observable("id");
    self.Name = ko.observable("name");
    self.Price = ko.observable("price");
    self.Description = ko.observable("desc");
    self.PictureUrl = ko.observable("pic");

    var Product = {
        Id: self.Id,
        Name: self.Name,
        Price: self.Price,
        Description: self.Description,
        PictureUrl: self.PictureUrl
    };
    
    self.Product = ko.observable();
    self.Products = ko.observableArray(); 

    //init function
    $.ajax({
        url: 'Home/GetAllProducts',
        cache: false,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',       
        success: function (data) {
            self.Products(data);

     
        }
    });
    //ShowInfo func
    self.showInfo = function (Product) {        
        self.Product = Product;          
    }


   
}

var viewModel = new ProductViewModel();
ko.applyBindings(viewModel);





