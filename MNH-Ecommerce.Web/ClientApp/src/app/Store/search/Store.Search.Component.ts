import { Component, OnInit } from "@angular/core"
import { Product } from "../../model/product";
import { ProductService } from "../../../services/product/product.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-Store",
  templateUrl: "./Store.Search.Component.html",
  styleUrls: ["./Store.Search.Component.css"]
})

export class StoreSearchComponent implements OnInit{
  public products : Product[];

  ngOnInit(): void {

    }
  constructor(private productService: ProductService, private router:Router) {
    this.productService.getAllProducts().subscribe(
      products => {
      this.products = products
      },
      err =>
      {
        console.log(err.error)
      })
    }

    public openProduct(product:Product) {
        sessionStorage.setItem("productDetail", JSON.stringify(product));
        this.router.navigate(['/store-Product'])

    }

}
