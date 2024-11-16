import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SleepAnalyserComponent } from './sleep-analyser.component';

describe('SleepAnalyserComponent', () => {
  let component: SleepAnalyserComponent;
  let fixture: ComponentFixture<SleepAnalyserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SleepAnalyserComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SleepAnalyserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
