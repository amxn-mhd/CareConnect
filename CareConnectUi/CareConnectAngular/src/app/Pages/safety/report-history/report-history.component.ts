import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-report-history',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './report-history.component.html',
  styleUrls: ['./report-history.component.css'],
})
export class ReportHistoryComponent {
  // Expanded dummy data
  reports = [
    { time: '08:30 AM', location: 'Downtown', type: 'Hazard' },
    { time: '02:15 PM', location: 'City Mall', type: 'Accident' },
    { time: '11:45 AM', location: 'Main Street', type: 'Natural Disaster' },
    { time: '05:00 PM', location: 'Park Avenue', type: 'Fire' },
    { time: '07:30 PM', location: 'West Side', type: 'Flood' },
    { time: '09:15 PM', location: 'East End', type: 'Power Outage' },
    { time: '06:20 AM', location: 'Greenwood', type: 'Medical Emergency' },
    { time: '10:45 AM', location: 'Sunset Boulevard', type: 'Robbery' },
    { time: '01:30 PM', location: 'Lakeside', type: 'Vandalism' },
    { time: '03:50 PM', location: 'Uptown', type: 'Gas Leak' },
    { time: '08:10 AM', location: 'Riverdale', type: 'Hazard' },
    { time: '04:00 PM', location: 'Highland', type: 'Fire' },
  ];

  // Delete method
  deleteReport(index: number): void {
    if (confirm('Are you sure you want to delete this report?')) {
      this.reports.splice(index, 1);
    }
  }
}
