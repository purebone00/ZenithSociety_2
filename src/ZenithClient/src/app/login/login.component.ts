import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthenticationService]
})
export class LoginComponent implements OnInit {

  user: any = {};
  error: boolean = false;

  constructor(
    private authentication: AuthenticationService,
    private route: Router,
  ) { }

  ngOnInit() {
    this.authentication.logout();
  }

  submitLogin() {
    this.authentication.login(this.user.username, this.user.password)
      .subscribe(
        data => {
          this.route.navigate(['/events']);
        }
      );
  }

}
