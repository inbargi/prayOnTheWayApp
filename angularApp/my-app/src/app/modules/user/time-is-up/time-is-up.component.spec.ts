import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TimeIsUpComponent } from './time-is-up.component';

describe('TimeIsUpComponent', () => {
  let component: TimeIsUpComponent;
  let fixture: ComponentFixture<TimeIsUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TimeIsUpComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TimeIsUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
