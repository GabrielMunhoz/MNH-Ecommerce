import { Component, OnInit } from "@angular/core"
import { ProductService } from "../../services/product/product.service";
import { Product } from "../model/product";
import { Router } from "@angular/router";

@Component({
  selector: "app-produto", //defini o nome da tag html onde o produto sera renderizado
  templateUrl: "./product.component.html", //Estrutura html onde vou renderizar o meu component
  styleUrls: ["./product.component.css"]
})
export class ProductComponent implements OnInit{
   
  public product :Product
  public arquivoSelecionado: File;
  public message: string;
  public playSpinner: boolean;

  constructor(private productService: ProductService, private router: Router) {

  }
  ngOnInit(): void {
    var productSession = sessionStorage.getItem("ProductSession");

    if (productSession) {
      this.product = JSON.parse(productSession);
    } else {
      this.product = new Product()
    }

  }

  public register() {
    this.playSpinner = true;
    this.productService.register(this.product)
      .subscribe(
        productReturn => {

          console.log(productReturn);
          this.playSpinner = false;
          this.router.navigate(['/searchProduct'])

        },
        err => {

          console.log(err.error);
          this.message = err.error;
          this.playSpinner = false;
        }

    );
    
  }

  public inputChange(files: FileList) {
    this.playSpinner = true;
    this.arquivoSelecionado = files.item(0);

    this.productService.sendFile(this.arquivoSelecionado)
      .subscribe(
        fileReturn => {
          this.product.fileName = fileReturn
          console.log(fileReturn);
        },
        e => {
          console.log(e.error);
        }
    );
    this.playSpinner = false;
  }
}
