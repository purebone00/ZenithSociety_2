import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import 'rxjs/add/operator/toPromise';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [AuthenticationService]
})
export class LoginComponent implements OnInit {

  user: any = {};
  error: boolean = false;

  constructor(private authentication: AuthenticationService, private router: Router) { }

  ngOnInit() {
    this.authentication.logout();
  }

  submitLogin() {
    this.authentication.login(this.user.username, this.user.password);
    this.router.navigate(['/events']);
  }

}
