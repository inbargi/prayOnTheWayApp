import { TestBed } from '@angular/core/testing';

import { SelectMinyanService } from './select-minyan.service';

describe('SelectMinyanService', () => {
  let service: SelectMinyanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SelectMinyanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
