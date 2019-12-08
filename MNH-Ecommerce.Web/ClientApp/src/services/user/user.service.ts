import { Injectable, Inject } from "@angular/core"
import { HttpClient, HttpHeaders } from "@angular/common/http"
import { Observable } from "rxjs"
import { User } from "../../app/model/User";
import { TokenAcesso } from "../../app/model/Token";
import { Body } from "@angular/http/src/body";
import { map } from 'rxjs/operators';

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
        let header: HttpHeaders;
        header = new HttpHeaders();
        header.set('content-type', 'application/json');

        return header;
    }

    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }
    public AutenticatedUser(): boolean {
        return this._user != null;
    }
    public adminUser(): boolean {

        return this.AutenticatedUser() && this.user.isAdmin;
    }


    public cleanSession() {
        sessionStorage.setItem("AutenticatedUser", "");
        this._user = null;
    }

    public loginToken(user: User, token: TokenAcesso): Observable<TokenAcesso>
    {
        var body = {
            email : user.email,
            password : user.password
        };
        const headers = new HttpHeaders().set('content-type', 'application/json');
        headers.set("Bearer", "");

        return this.http.post<TokenAcesso>(this.baseUrl + "api/user/logintoken", body, {headers});
    }


    public verifyUser(user: User, token: TokenAcesso): Observable<User> {

        var body = {
            email: user.email,
            Password: user.password
        };

        return this.http.post<User>(this.baseUrl + "api/User/verifyUser", body, { headers : this.headers });
    }

    public registerUser(user: User): Observable<User> {

        return this.http.post<User>(this.baseUrl + "api/user", JSON.stringify(user), { headers: this.headers });
    }

    login(user: User) {
        var body = {
            email: user.email,
            password: user.password
        };

        return this.http.post<any>(`${this.baseUrl}/user/loginToken`, body)
            .pipe(map(user => {
                // login successful if there's a jwt token in the response
                if (user && user.token) {
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('AutenticatedUser', JSON.stringify(user));
                }

                return user;
            }));
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('AutenticatedUser');
    }

}
