import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AverageHealthComponent } from './average-health.component';

describe('AverageHealthComponent', () => {
  let component: AverageHealthComponent;
  let fixture: ComponentFixture<AverageHealthComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AverageHealthComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AverageHealthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
