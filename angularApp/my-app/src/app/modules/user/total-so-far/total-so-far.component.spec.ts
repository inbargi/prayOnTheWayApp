import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalSoFarComponent } from './total-so-far.component';

describe('TotalSoFarComponent', () => {
  let component: TotalSoFarComponent;
  let fixture: ComponentFixture<TotalSoFarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TotalSoFarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalSoFarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
