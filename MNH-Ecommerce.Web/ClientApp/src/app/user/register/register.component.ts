import { Component, OnInit } from "@angular/core";
import { User } from "../../model/User";
import { UserService } from "../../../services/user/user.service";

@Component({
  selector: "register-user",
  templateUrl: "./register.component.html",
  styleUrls: ["register.component.css"]
})

export class RegisterUserComponent implements OnInit {
  public user: User;
  public message: string;
  public playSpinner: boolean;
  public registredUser: boolean;
  constructor(private userService: UserService) {

  }

  ngOnInit(): void {
    this.user = new User();
  }

  public registerUser() {
    this.playSpinner = true;
    this.userService.registerUser(this.user)
      .subscribe(
        userReturn => {
          this.registredUser = true;
          this.message = "";
          this.playSpinner = false;
        },
        error => {
          this.registredUser = false;
          this.message = error.error;
          this.playSpinner = false;
        }
      );


  }
}
