import { Injectable, Inject } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import {Observable} from "rxjs"
import { User } from "../../app/model/User";

@Injectable({
  providedIn: "root",
   
})

export class UserService {

  private baseUrl: string;
  private _user: User

  get user(): User {
    let user_json = sessionStorage.getItem("AutenticatedUser");
    this._user = JSON.parse(user_json);
    return this._user;
  }

  set user(user: User) {
    sessionStorage.setItem("AutenticatedUser", JSON.stringify(user));
    this._user = user;
  }

  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json')
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
  }
  public AutenticatedUser(): boolean {
    return this._user != null;
  }

  public cleanSession() {
    sessionStorage.setItem("AutenticatedUser", "");
    this._user = null;
  }



  public verifyUser(user: User): Observable<User> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: user.email,
      Password: user.password
    };

    return this.http.post<User>(this.baseUrl+"/api/User/verifyUser", body, { headers });
  }

  public registerUser(user: User): Observable<User> {

    return this.http.post<User>(this.baseUrl + "api/user", JSON.stringify(user), {headers:this.headers});
  }
}
