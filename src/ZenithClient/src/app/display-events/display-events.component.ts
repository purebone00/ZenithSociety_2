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

  constructor(private eventService: EventModelService) { }

  getEventModels(): void {
    this.eventService.getEventModels()
    .then(events => this.events = events);
  }

  ngOnInit(): void {
    this.getEventModels();
  }

}
