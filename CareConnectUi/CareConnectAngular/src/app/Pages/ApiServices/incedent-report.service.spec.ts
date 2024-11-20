import { TestBed } from '@angular/core/testing';

import { IncedentReportService } from './incedent-report.service';

describe('IncedentReportService', () => {
  let service: IncedentReportService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IncedentReportService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
