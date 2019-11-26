import { Product } from "../../model/Product";

export class StoreCartComponent {
    
    
    public products: Product[] = [];
    public add(product: Product) {
        var productLocalStorage = localStorage.getItem("productLocalStorage");

        if (!productLocalStorage) {
            //se n existir nada no local storage
            this.products.push(product);
        } else {
            //se ja existir no local storage
            this.products = JSON.parse(productLocalStorage);
            this.products.push(product);
        }
        localStorage.setItem("productLocalStorage", JSON.stringify(this.products));

    }
    public cartGetProducts(): Product[] {

        var productLocalStorage = localStorage.getItem("productLocalStorage");

        if (productLocalStorage) {
            return JSON.parse(productLocalStorage);
        }
        return this.products;
    }
    public removeProduct(product: Product) {
        var productLocalStorage = localStorage.getItem("productLocalStorage");

        if (productLocalStorage) {
            this.products = JSON.parse(productLocalStorage);

            this.products = this.products.filter(p => p.id != product.id);
            localStorage.setItem("productLocalStorage", JSON.stringify(this.products));

        }
    }
    public update(products: Product[]) {
        localStorage.setItem("productLocalStorage", JSON.stringify(products));
    }
    public haveItems(): boolean {
        var items = this.cartGetProducts();

        return (items.length > 0);
    }
    public clearProducts() {
        localStorage.setItem("productLocalStorage", "");
    }
}
