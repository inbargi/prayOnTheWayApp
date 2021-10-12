import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoadNavComponent } from './road-nav.component';

describe('RoadNavComponent', () => {
  let component: RoadNavComponent;
  let fixture: ComponentFixture<RoadNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoadNavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoadNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
