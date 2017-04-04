import { Component } from '@angular/core';
import { EventModel } from './event-model';
import { EventModelService } from './event-model.service';
import { AuthenticationService } from './authentication.service';
@Component({
  selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [EventModelService, AuthenticationService]
})
export class AppComponent {

  constructor(
    private eventService: EventModelService,
    private authentication: AuthenticationService
  ) {}

  public isAuthenticated() : boolean {
      let user = localStorage.getItem("access_token");
      if(user)
       return true;
      else
        return false;
  }

  public logout() {
    this.authentication.logout();
  }


}
