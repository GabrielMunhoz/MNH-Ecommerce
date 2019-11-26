import { Component, OnInit } from "@angular/core"
import { StoreCartComponent } from "../Cart/store.cart.component"
import { Product } from "../../model/Product";
import { Demand } from "../../model/demand";
import { UserService } from "../../../services/user/user.service";
import { ItemDemand } from "../../model/itemDemand";
import { DemandService } from "../../../services/Demand/demand.service";
import { Route, Router } from "@angular/router";

@Component({
    selector: "store-buy",
    templateUrl: "./store.buy.component.html",
    styleUrls: ["./store.buy.component.css"]
})

export class StoreBuyComponent implements OnInit{

    public cartShopping: StoreCartComponent;
    public products: Product[];
    public total: number;

    ngOnInit(): void {
        this.cartShopping = new StoreCartComponent();
        this.products = this.cartShopping.cartGetProducts();
        this.updateTotal();
    }

    constructor(private userService:UserService, private demandService:DemandService, private router:Router) {

    }

    public updatePrice(product: Product, quant: number) {
        if (!product.priceOrginal) {
            product.priceOrginal = product.price;
        }
        product.price = product.priceOrginal * quant;
        this.cartShopping.update(this.products);
        this.updateTotal();
    }

    public remover(product: Product) {
        this.cartShopping.removeProduct(product);
        this.products = this.cartShopping.cartGetProducts();
        this.updateTotal();
    }
    public updateTotal() {
        this.total = this.products.reduce((acc, product) => acc + product.price, 0);
    }

    public Buy() {

        this.demandService.buy(this.createDemand())
            .subscribe(
                demandId => {
                    sessionStorage.setItem("demandId", demandId.toString());
                    this.products = [];
                    this.cartShopping.clearProducts();
                    this.router.navigate(["/completedBuy"]);
                },
                err => {
                    console.log(err.error);
                }
            )
    }
    public createDemand():Demand {
        let demand = new Demand();
        demand.id = 50;
        demand.userId = this.userService.user.Id;
        demand.CEP = "049328590";
        demand.city = "poa";
        demand.state = "RS";
        demand.DeliveryDate = new Date();
        demand.payWayId = 1;
        demand.addressNumber = "12";

        this.products = this.cartShopping.cartGetProducts();
        for (let prod of this.products) {
            let itemDemand = new ItemDemand();
            itemDemand.ProductId = prod.id;
            if (!prod.quant) {
                prod.quant = 1;
            }

            itemDemand.Quantity = prod.quant;

            demand.itemDemands.push(itemDemand);
        }

        return demand;
    }

}
