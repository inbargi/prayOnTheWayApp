import { TestBed } from '@angular/core/testing';

import { FeedbeckService } from './feedbeck.service';

describe('FeedbeckService', () => {
  let service: FeedbeckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FeedbeckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
