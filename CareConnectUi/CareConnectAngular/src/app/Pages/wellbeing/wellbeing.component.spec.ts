import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WellbeingComponent } from './wellbeing.component';

describe('WellbeingComponent', () => {
  let component: WellbeingComponent;
  let fixture: ComponentFixture<WellbeingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [WellbeingComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(WellbeingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
