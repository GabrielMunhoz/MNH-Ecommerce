import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { TruncateModule } from 'ng2-truncate';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProductComponent } from './products/product.component';
import { LoginComponent } from "./user/login/login.Component";
import { GuardRoutes } from './autorization/guard.routes';
import { UserService } from '../services/user/user.service';
import { RegisterUserComponent } from './user/register/register.component';
import { ProductService } from '../services/product/product.service';
import { SearchProductComponent } from './products/search/search.product.component';
import { StoreSearchComponent } from './Store/search/Store.Search.Component';
import { truncate } from 'fs';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProductComponent,
    LoginComponent,
    RegisterUserComponent,
    SearchProductComponent,
    StoreSearchComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule, 
    TruncateModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'product', component: ProductComponent},
      { path: 'enter', component: LoginComponent },
      { path: 'register', component: RegisterUserComponent },
      { path: 'registerProduct', component: ProductComponent },
      { path: 'searchProduct', component: SearchProductComponent, canActivate: [GuardRoutes] }

    ])
  ],
  providers: [UserService,ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
