import { Component, OnInit } from "@angular/core"
import { Product } from "../../model/product";
import { ProductService } from "../../../services/product/product.service";

@Component({
  selector: "app-Store",
  templateUrl: "./Store.Search.Component.html",
  styleUrls: ["./Store.Search.Component.css"]
})

export class StoreSearchComponent implements OnInit{
  public products : Product[];

  ngOnInit(): void {

    }
  constructor(private productService: ProductService) {
    this.productService.getAllProducts().subscribe(
      products => {
      this.products = products
      },
      err =>
      {
        console.log(err.error)
      })
  }
}
