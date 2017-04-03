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
  currentWeekSunday: Date;

  constructor(private eventService: EventModelService) {
    this.currentWeekSunday = new Date();
  }

  getCurrentSunday() {
    var curDate = new Date();
    while (curDate.getDay() != 1) {
      curDate.setDate(curDate.getDate() - 1);
    }
    return curDate.getTime();
  }

  getEventModels(): void {
    this.eventService.getEventModels()
    .then(events => this.events = events);
  }

  ngOnInit(): void {
    this.getEventModels();
    this.currentWeekSunday.setTime(this.getCurrentSunday());
  }

  isAuthenticated() : boolean {
      let user = localStorage.getItem("access_token");
      if(user)
        this.isAuth = true;
      else
        this.isAuth = false;
      return this.isAuth;
  }

  updateCurrentEvents() {
    let eventsThisWeek: EventModel[];
    eventsThisWeek = [];
    this.events.forEach(singleEvent => {
      if (this.currentWeekSunday.getTime() < (new Date(singleEvent.eventDate)).getTime() &&
              ( (new Date(singleEvent.eventDate)).getTime()) < (this.sevenDayFromNow().getTime())) {
        eventsThisWeek.push(singleEvent);
      }
    });

    this.eventsToShow = eventsThisWeek;
  }

  sevenDayFromNow():Date {
    var temp = this.currentWeekSunday;
    temp.setDate(temp.getDate() + 7)
    return temp;
  }

  sevenDayBeforeNow():Date {
    var temp = this.currentWeekSunday;
    temp.setDate(temp.getDate() - 7)
    return temp;
  }

  clickNextBtn(): void {
    this.currentWeekSunday.setTime(this.sevenDayFromNow().getTime());
    this.updateCurrentEvents();
  }

  clickPreviousBtn(): void {
    this.currentWeekSunday.setTime(this.sevenDayBeforeNow().getTime());
    this.updateCurrentEvents();
  }

}
