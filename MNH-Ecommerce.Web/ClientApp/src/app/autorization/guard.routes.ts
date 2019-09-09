import { Injectable } from "@angular/core";
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";

@Injectable({
  providedIn: 'root'
})

export class GuardRoutes implements CanActivate {

  constructor(private router: Router) {
  }

  canActivate(route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean {
    var autenticado = sessionStorage.getItem("usuarioAutenticado");
    //se usuario autenticado
    if (autenticado == "1") {
      return true;
    }
    else
    {
      this.router.navigate(['/entrar'], { queryParams: { returnUrl: state.url } });
      return false;
    }
    
  }


}
