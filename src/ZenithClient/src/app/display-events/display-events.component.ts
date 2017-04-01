import { Component, OnInit ,Input } from '@angular/core';
import { EventModel } from '../event-model';

@Component({
  selector: 'app-display-events',
  templateUrl: './display-events.component.html',
  styleUrls: ['./display-events.component.css']
})
export class DisplayEventsComponent implements OnInit {

  @Input()
  events: EventModel[];

  constructor() { }

  ngOnInit() {
  }

}
