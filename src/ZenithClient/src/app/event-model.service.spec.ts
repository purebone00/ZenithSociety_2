import { TestBed, inject } from '@angular/core/testing';

import { EventModelService } from './event-model.service';

describe('EventModelService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EventModelService]
    });
  });

  it('should ...', inject([EventModelService], (service: EventModelService) => {
    expect(service).toBeTruthy();
  }));
});
