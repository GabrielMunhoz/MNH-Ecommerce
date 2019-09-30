import { Component } from '@angular/core';
import { Session } from 'protractor';
import { Router } from '@angular/router';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})

export class NavMenuComponent {
  isExpanded = false;

  get user() {

    var u = this.userService.user;

     return u;
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

   return this.userService.AutenticatedUser();
  }

  Logout() {
    this.userService.cleanSession();
    this.router.navigate(['/']);
  }

}
