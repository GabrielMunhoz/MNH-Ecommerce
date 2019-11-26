import { Component, OnInit } from "@angular/core";

@Component({
    templateUrl: "./completedBuy.component.html"
})

export class CompletedBuyComponent implements OnInit {

    public demandId: string;

    ngOnInit(): void {
        this.demandId = sessionStorage.getItem("demandId");
    }

}
