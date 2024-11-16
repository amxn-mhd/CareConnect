import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-report-history',
  standalone: true,
  imports:[FormsModule,CommonModule],
  templateUrl: './report-history.component.html',
  styleUrls: ['./report-history.component.css'],
})
export class ReportHistoryComponent {
  // Dummy data
  reports = [
    { time: '08:30 AM', location: 'Downtown', type: 'Hazard' },
    { time: '02:15 PM', location: 'City Mall', type: 'Accident' },
    { time: '11:45 AM', location: 'Main Street', type: 'Natural Disaster' },
  ];

  // Delete method
  deleteReport(index: number): void {
    if (confirm('Are you sure you want to delete this report?')) {
      this.reports.splice(index, 1);
    }
  }
}
