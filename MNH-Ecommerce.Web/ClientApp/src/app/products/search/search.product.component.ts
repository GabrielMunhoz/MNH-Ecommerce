import { Component, OnInit } from "@angular/core";
import { Product } from "../../model/Product";
import { ProductService } from "../../../services/product/product.service";
import { Router } from "@angular/router";

@Component({
  selector: "search-product",
  templateUrl: "./search.product.component.html",
  styleUrls: ["./search.product.component.css"]
})

export class SearchProductComponent implements OnInit {
  public products: Product[];
    public auxProd: Product[];
  ngOnInit(): void {
    }
  constructor(private productService: ProductService, private router: Router) {
    this.productService.getAllProducts().subscribe(
      products => {
            this.products = products;
            this.auxProd = products;
        console.log(products);
      },
      e => {
        console.log(e.error)
      })
  }

    public addProduct() {
        sessionStorage.setItem('ProductSession', JSON.stringify(""));
    this.router.navigate(['/registerProduct'])
  }

  public edit(product: Product) {
    sessionStorage.setItem('ProductSession', JSON.stringify(product));
    this.router.navigate(['/product'])
  }

    public filtrarTabela(value: string)
    {
      
      this.products = this.auxProd.filter(valu => valu.name.includes(value));

    }
  public delete(product: Product) {
    var retrn=confirm("Deseja Realmente Deletar? ");
    if (retrn == true) {
      this.productService.delete(product).subscribe(
        products => {
          this.products = products;

      },
        erro => {
          console.log(erro.error);
      })
    }
  }
}
