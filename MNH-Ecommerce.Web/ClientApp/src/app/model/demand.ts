import { ItemDemand } from "./itemDemand"

export class Demand {
    public id: number;
    public demandDate: Date;
    public userId: number;
    public DeliveryDate: Date;
    public CEP: string;
    public state: string;
    public city: string;
    public completeAddress: string;
    public addressNumber: string;
    public payWayId: number;
    public itemDemands: ItemDemand[];

    constructor() {
        this.demandDate = new Date();

        this.itemDemands = [];
    }
}
