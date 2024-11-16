import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportIncidentFormComponent } from './report-incident-form.component';

describe('ReportIncidentFormComponent', () => {
  let component: ReportIncidentFormComponent;
  let fixture: ComponentFixture<ReportIncidentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReportIncidentFormComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportIncidentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
