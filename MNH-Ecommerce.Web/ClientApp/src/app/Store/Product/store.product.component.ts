import { Component,OnInit } from "@angular/core";
import { ProductService } from "../../../services/product/product.service";
import { Product } from "../../model/Product";
import { Router } from "@angular/router";
import { StoreCartComponent } from "../Cart/store.cart.component";

@Component({
    selector: "store-app-product",
    templateUrl: "./store.product.component.html",
    styleUrls: ["./store.product.component.css"]
})

export class StoreProductComponent implements OnInit {
    public product: Product;
    public cartShopping: StoreCartComponent;
    ngOnInit(): void {
        this.cartShopping = new StoreCartComponent();

        var productDetail = sessionStorage.getItem("productDetail");
        if (productDetail) {
            this.product = JSON.parse(productDetail)
        }
    }

    constructor(private productService: ProductService, private router:Router) {

    }

    public buy() {
        this.cartShopping.add(this.product);

        this.router.navigate(["/store-buy"]);
    }
}
