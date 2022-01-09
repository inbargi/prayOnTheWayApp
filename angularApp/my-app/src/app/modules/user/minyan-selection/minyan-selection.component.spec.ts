import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MinyanSelectionComponent } from './minyan-selection.component';

describe('MinyanSelectionComponent', () => {
  let component: MinyanSelectionComponent;
  let fixture: ComponentFixture<MinyanSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MinyanSelectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MinyanSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
