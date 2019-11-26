import { Injectable, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Demand } from "../../app/model/demand";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class DemandService {
    public _buseUrl: string;

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this._buseUrl = baseUrl;
    }

    get headers(): HttpHeaders {
        return new HttpHeaders().set('content-type', 'application/json')
    }
    public buy(demand: Demand): Observable<number> {
        return this.http.post<number>(this._buseUrl + "api/demand", JSON.stringify(demand), { headers: this.headers });

    }
}
