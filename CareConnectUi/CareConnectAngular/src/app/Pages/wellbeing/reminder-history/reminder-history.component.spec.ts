import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReminderHistoryComponent } from './reminder-history.component';

describe('ReminderHistoryComponent', () => {
  let component: ReminderHistoryComponent;
  let fixture: ComponentFixture<ReminderHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReminderHistoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReminderHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
