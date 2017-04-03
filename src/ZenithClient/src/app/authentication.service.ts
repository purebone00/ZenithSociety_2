import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {

  constructor(private _http: Http) { }

  public login(username: string, password: string) {
    let credentials = 'username=' + username + '&password=' + password + '&grant_type=password';
    let options = new RequestOptions({
      headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' , 'Access-Control-Allow-Credentials': true })
    });

    return this._http.post('http://localhost:5000/connect/token', credentials, options)
      .map((response: Response) => {

          let user = response.json();

          if (user && user.access_token) {
            localStorage.setItem('access_token', user.access_token);
            localStorage.setItem('user', JSON.stringify(user));
          }
      })

  }

  public logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('access_token');
  }

}
