import { Injectable, Inject, OnInit } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { Product } from "../../app/model/Product";
@Injectable({
  providedIn: "root"
})

export class ProductService implements OnInit {
   
    
  private _baseUrl: string;
  public products: Product[];

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._baseUrl = baseUrl;
  }

  ngOnInit(): void {
    this.products = [];
  }

  get headers(): HttpHeaders {
  return new HttpHeaders().set('content-type', 'application/json')
  }



  public register(product: Product): Observable<Product> {
     
    return this.http.post<Product>(this._baseUrl + "api/product",JSON.stringify(product), {headers:this.headers})
  }

  public save(product: Product): Observable<Product> {
    return this.http.post<Product>(this._baseUrl + "api/product/register", JSON.stringify(product), { headers: this.headers })
  }

  public delete(product: Product): Observable<Product[]> {
    return this.http.post<Product[]>(this._baseUrl + "api/product/Delete", JSON.stringify(product), { headers: this.headers })
  }
  public getAllProducts() {
    return this.http.get<Product[]>(this._baseUrl + "api/product");
  }

  public sendFile(selectedFile: File): Observable<string> {
    const formData: FormData = new FormData();
    formData.append("selectedFile", selectedFile, selectedFile.name);

    return this.http.post<string>(this._baseUrl + "api/product/SendFile", formData);
  }
}
