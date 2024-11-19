import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemiderSchedulerComponent } from './remider-scheduler.component';

describe('RemiderSchedulerComponent', () => {
  let component: RemiderSchedulerComponent;
  let fixture: ComponentFixture<RemiderSchedulerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RemiderSchedulerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RemiderSchedulerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
