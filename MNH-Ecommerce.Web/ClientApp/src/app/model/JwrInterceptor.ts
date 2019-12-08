import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TokenAcesso } from './Token';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        // add authorization header with jwt token if available
        let currentUser: TokenAcesso = JSON.parse(localStorage.getItem('token'));
        if (currentUser && currentUser.accessToken) {
            request = request.clone({
                setHeaders: { 
                    Authorization: `Bearer ${currentUser.accessToken}`
                }
            });
        }

        return next.handle(request);
    }
}
