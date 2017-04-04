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
  startWeek : Date;
  endWeek: Date;

  constructor(private eventService: EventModelService) {
    this.eventsToShow = [];
  }

  getCurrentSunday(today: Date) {
    this.startWeek = today;
    return new Date(this.startWeek.setDate(this.startWeek.getDate() - this.startWeek.getDay()-1));
  }

  getLastDayOfWeek(today: Date) {
    this.endWeek = today;
    return new Date(this.endWeek.setDate(this.endWeek.getDate() + 7));
  }

  getEventModels(today: Date): void {
    this.eventService.getEventModels()
    .then(events => {
      this.events = events.sort(function(a, b) {
        var key1 = new Date(a.eventDate);
        var key2 = new Date(b.eventDate);

        if (key1 < key2) {
            return -1;
        } else if (key1 == key2) {
            return 0;
        } else {
            return 1;
        }
      })
      console.log(today);
      this.updateCurrentEvents(this.events, this.getCurrentSunday(today), this.getLastDayOfWeek(today));
    });
  }

  ngOnInit(): void {
    this.getEventModels(new Date());
  }

  isAuthenticated() : boolean {
      let user = localStorage.getItem("access_token");
      if(user)
        return true;
      else
        return false;
  }

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
    var temp1 = new Date(this.startWeek.setDate(this.startWeek.getDate() + 7));
    this.getEventModels(temp1);
  }

  clickPreviousBtn(): void {
    var temp1 = new Date(this.startWeek.setDate(this.startWeek.getDate() - 7));
    this.getEventModels(temp1);
  }

}
