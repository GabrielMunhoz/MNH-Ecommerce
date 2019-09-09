import { Component } from "@angular/core"

@Component({
  selector: "app-produto", //defini o nome da tag html onde o produto sera renderizado
  template: "<html><body>{{ getName() }}</body></html>" //Estrutura html onde vou renderizar o meu component
})
export class ProductComponent{
  public name: string;
  public available: boolean;

  public getName(): string {
    //return this.name;
    return "Samsung";
  }
}
