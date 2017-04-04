import { Component, OnInit ,Input } from '@angular/core';
import { EventModel } from '../event-model';
import { EventModelService } from '../event-model.service';
@Component({
  selector: 'app-display-events',
  templateUrl: './display-events.component.html',
  styleUrls: ['./display-events.component.css'],
  providers: [EventModelService]
})
export class DisplayEventsComponent implements OnInit {

  @Input()
  events: EventModel[];

  eventsToShow: EventModel[];
  isAuth: boolean;
  today : Date;
  startWeek : Date;

  constructor(private eventService: EventModelService) {
    this.eventsToShow = [];
  }

  getCurrentSunday() {
    this.today = new Date();
    return new Date(this.today.setDate(this.today.getUTCDate() - this.today.getUTCDay()-1));
  }

  getLastDayOfWeek() {
    this.today = new Date();
    return new Date(this.today.setDate(this.today.getUTCDate() - this.today.getUTCDay()+7));
  }

  getEventModels(): void {
    this.eventService.getEventModels()
    .then(events => {
      this.events = events
      this.startWeek = this.getCurrentSunday()
      this.updateCurrentEvents(this.events, this.startWeek, this.getLastDayOfWeek());

    });
  }

  ngOnInit(): void {
    this.getEventModels();
  }

  isAuthenticated() : boolean {
      let user = localStorage.getItem("access_token");
      if(user)
        this.isAuth = true;
      else
        this.isAuth = false;
      return this.isAuth;
  }

//

  updateCurrentEvents(events?: EventModel[], startWeek ?: Date, endWeek ?: Date) {
    let eventsThisWeek: EventModel[];
    eventsThisWeek = [];
    events.forEach(singleEvent => {
      if ((new Date(singleEvent.eventDate)) >= startWeek && (new Date(singleEvent.eventDate)) <= endWeek) {
        eventsThisWeek.push(singleEvent);
      }
    });
    this.eventsToShow = eventsThisWeek;
  }

  clickNextBtn(): void {
  }

  clickPreviousBtn(): void {
  }

}
