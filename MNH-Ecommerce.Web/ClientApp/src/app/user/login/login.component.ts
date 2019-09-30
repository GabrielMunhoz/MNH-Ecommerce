import { Component, OnInit } from "@angular/core";
import { User } from "../../model/User";
import { Router, ActivatedRoute } from "@angular/router";
import { UserService } from "../../../services/user/user.service";
@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]
})
export class LoginComponent implements OnInit {
  public user;
  public returnUrl: string;
  public message: string;
  public playSpinner: boolean;
  constructor(private router: Router, private activatedRouter: ActivatedRoute, private userService: UserService) {
  }
  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl'];
    this.user = new User();
  }
  login() {
    this.playSpinner = true;

    //Precisa do subscribe para iniciar a requisicao
    this.userService.verifyUser(this.user)
      //tratamento do retorno atravez do subscribe 
      .subscribe(user_json => {
        this.userService.user = user_json;
        if (this.returnUrl == null) {
          this.router.navigate(['/']);
        }
        else {
          this.router.navigate([this.returnUrl]);
        }
      }, err => {
        console.log(err.error);
        this.message = err.error;
          this.playSpinner = false;
        });
  }
}
