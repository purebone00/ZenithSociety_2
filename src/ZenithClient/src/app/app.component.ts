import { Component } from '@angular/core';
import { EventModel } from './event-model';
import { EventModelService } from './event-model.service';

@Component({
  selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    providers: [EventModelService]
})
export class AppComponent {

  constructor(private eventService: EventModelService) {}

  events: EventModel[];

  getEventModels(): void {
    this.eventService.getEventModels()
    .then(events => this.events = events);
  }

  ngOnInit(): void {
    this.getEventModels();
  }
}
