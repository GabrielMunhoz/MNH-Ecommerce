import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtHelperService, JWT_OPTIONS } from "@auth0/angular-jwt";
import { TruncateModule } from 'ng2-truncate';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './products/product.component';
import { GuardRoutes } from './autorization/guard.routes';
import { UserService } from '../services/user/user.service';
import { RegisterUserComponent } from './user/register/register.component';
import { ProductService } from '../services/product/product.service';
import { SearchProductComponent } from './products/search/search.product.component';
import { StoreSearchComponent } from './Store/search/Store.Search.Component';
import { StoreProductComponent } from './Store/Product/store.product.component';
import { StoreBuyComponent } from './Store/Buy/store.buy.component';
import { DemandService } from '../services/Demand/demand.service';
import { CompletedBuyComponent } from './Store/Buy/completedBuy.component';
import {
    SocialLoginModule, AuthServiceConfig, GoogleLoginProvider,
    FacebookLoginProvider,
} from "angular-6-social-login";
import { HttpAuthInterceptor } from './model/http-auth-interceptor';
import { JwtInterceptor } from './model/JwrInterceptor';
import { LoginComponent } from './user/login/login.component';



@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        ProductComponent,
        LoginComponent,
        RegisterUserComponent,
        SearchProductComponent,
        StoreSearchComponent,
        StoreProductComponent,
        StoreBuyComponent,
        CompletedBuyComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        SocialLoginModule,
        FormsModule,
        TruncateModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'product', component: ProductComponent },
            { path: 'enter', component: LoginComponent },
            { path: 'register', component: RegisterUserComponent },
            { path: 'registerProduct', component: ProductComponent },
            { path: 'searchProduct', component: SearchProductComponent, canActivate: [GuardRoutes] },
            { path: 'store-Product', component: StoreProductComponent },
            { path: 'store-buy', component: StoreBuyComponent, canActivate: [GuardRoutes] },
            { path: 'completedBuy', component: CompletedBuyComponent }

        ])
    ],
    providers: [UserService, ProductService, DemandService,
        {
            provide: AuthServiceConfig,
            useFactory: getAuthServiceConfigs
        },
        { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: JWT_OPTIONS, useValue: JWT_OPTIONS },
        JwtHelperService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

export function getAuthServiceConfigs() {
    // tslint:disable-next-line:prefer-const
    let config = new AuthServiceConfig(
        [
            {
                id: FacebookLoginProvider.PROVIDER_ID,
                provider: new FacebookLoginProvider("437399553616919")
            },
            {
                id: GoogleLoginProvider.PROVIDER_ID,
                provider: new GoogleLoginProvider("454624941562-j9uneqfcf0caoo4q24pfiolbmcn322vs.apps.googleusercontent.com")
            }
        ]
    );
    return config;
}


