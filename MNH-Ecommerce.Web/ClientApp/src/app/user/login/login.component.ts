import { Component, OnInit } from "@angular/core";
import { User } from "../../model/User";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls:["./login.component.css"]
})
export class LoginComponent implements OnInit {
  public user;
  public returnUrl: string;

  constructor(private router:Router, private activatedRouter:ActivatedRoute) {
    this.user = new User()
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']
  }
  entrar() {
    if (this.user.email == "teste@123" && this.user.senha == "abc123") {
      sessionStorage.setItem("usuarioAutenticado", "1");
      this.router.navigate([this.returnUrl]);
    }
  }
}
