"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var StoreCartComponent = /** @class */ (function () {
    function StoreCartComponent() {
        this.products = [];
    }
    StoreCartComponent.prototype.add = function (product) {
        var productLocalStorage = localStorage.getItem("productLocalStorage");
        if (!productLocalStorage) {
            //se n existir nada no local storage
            this.products.push(product);
        }
        else {
            //se ja existir no local storage
            this.products = JSON.parse(productLocalStorage);
            this.products.push(product);
        }
        localStorage.setItem("productLocalStorage", JSON.stringify(this.products));
    };
    StoreCartComponent.prototype.cartGetProducts = function () {
        var productLocalStorage = localStorage.getItem("productLocalStorage");
        if (productLocalStorage) {
            return JSON.parse(productLocalStorage);
        }
        return this.products;
    };
    StoreCartComponent.prototype.removeProduct = function (product) {
        var productLocalStorage = localStorage.getItem("productLocalStorage");
        if (productLocalStorage) {
            this.products = JSON.parse(productLocalStorage);
            this.products = this.products.filter(function (p) { return p.id != product.id; });
            localStorage.setItem("productLocalStorage", JSON.stringify(this.products));
        }
    };
    StoreCartComponent.prototype.update = function (products) {
        localStorage.setItem("productLocalStorage", JSON.stringify(products));
    };
    StoreCartComponent.prototype.haveItems = function () {
        var items = this.cartGetProducts();
        return (items.length > 0);
    };
    StoreCartComponent.prototype.clearProducts = function () {
        localStorage.setItem("productLocalStorage", "");
    };
    return StoreCartComponent;
}());
exports.StoreCartComponent = StoreCartComponent;
//# sourceMappingURL=store.cart.component.js.map