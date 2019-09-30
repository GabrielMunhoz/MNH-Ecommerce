import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { UserService } from "../../services/user/user.service";

@Injectable({
  providedIn: 'root'
})

export class GuardRoutes implements CanActivate {

  constructor(private router: Router, private userService: UserService) {
  }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    
    if (this.userService.AutenticatedUser()) {
      return true;
    }
    else
    {
      this.router.navigate(['/enter'], { queryParams: { returnUrl: state.url } });
      return false;
    }
    
  }


}
