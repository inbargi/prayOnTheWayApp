import { TestBed } from '@angular/core/testing';

import { MinyanService } from './minyan.service';

describe('MinyanService', () => {
  let service: MinyanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MinyanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
