import { Injectable } from '@angular/core';
import { DummyData } from './data/dummy-data';
import { EventModel } from './event-model';

@Injectable()
export class EventModelService {

  constructor() { }

  getEventModels(): Promise<EventModel[]> {
    return Promise.resolve(DummyData);
  }

}
