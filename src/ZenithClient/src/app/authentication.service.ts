import { Injectable } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/map'
@Injectable()
export class AuthenticationService {

  private response: JSON;

  constructor(
    private _http: Http
  ) { }

  public login(username: string, password: string) {
    let credentials = 'username=' + username + '&password=' + password + '&grant_type=password';
    let options = new RequestOptions({
      headers: new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' })
    });

    return this._http.post('http://localhost:5000/connect/token', credentials, options)
      .toPromise()
      .then(function(resp) {
        let user = resp.json();
        console.log(user);
        if (user && user.access_token) {
          localStorage.setItem('access_token', user.access_token);
          localStorage.setItem('currentUser', JSON.stringify(user));
        }
      })
      .catch(this.handleError);
  }

  public logout() {
    localStorage.removeItem('currentUser');
    localStorage.removeItem('access_token');
  }

  private handleError(error: any):Promise<any> {
    console.error('An error occurred', error); // for demo purposes only
    return Promise.reject(error.message || error);
  }

}
