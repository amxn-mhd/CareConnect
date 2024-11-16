import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MoodAnalyserComponent } from './mood-analyser.component';

describe('MoodAnalyserComponent', () => {
  let component: MoodAnalyserComponent;
  let fixture: ComponentFixture<MoodAnalyserComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MoodAnalyserComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MoodAnalyserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
