import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SleepHistoryComponent } from './sleep-history.component';

describe('SleepHistoryComponent', () => {
  let component: SleepHistoryComponent;
  let fixture: ComponentFixture<SleepHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SleepHistoryComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SleepHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
