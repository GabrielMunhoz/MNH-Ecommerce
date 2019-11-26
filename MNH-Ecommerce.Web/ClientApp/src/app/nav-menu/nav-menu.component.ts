import { Component, OnInit } from '@angular/core';
import { Session } from 'protractor';
import { Router } from '@angular/router';
import { UserService } from '../../services/user/user.service';
import { StoreCartComponent } from '../Store/Cart/store.cart.component';

@Component({
    selector: 'app-nav-menu',
    templateUrl: './nav-menu.component.html',
    styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent implements OnInit{
    isExpanded = false;
    public cart: StoreCartComponent;

    get user() {

        var user = this.userService.user;

        return user;
    }

    ngOnInit(): void {
        this.cart = new StoreCartComponent();
    }
    constructor(private router: Router, private userService: UserService) {

    }

    collapse() {
        this.isExpanded = false;
    }

    toggle() {
        this.isExpanded = !this.isExpanded;
    }

    public AutenticatedUser(): boolean {
        if (this.userService.AutenticatedUser() == null || this.userService.AutenticatedUser() == false) {
            return false;
        }
        return true
    }
    public adminUser():boolean {
        return this.userService.adminUser();
    }

    Logout() {
        this.userService.cleanSession();
        this.router.navigate(['/']);
    }

    public haveItems(): boolean {

        return this.cart.haveItems();
    }
}
