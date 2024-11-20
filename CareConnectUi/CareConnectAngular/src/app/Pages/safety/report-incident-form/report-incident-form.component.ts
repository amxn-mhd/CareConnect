import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';

interface IncidentReport {
  dateTimeOfEntry: string;
  userId: string;
  typeOfAccident: string;
  location: string;
  time: string;
  shortDescription: string;
  authorizeEdit: boolean;
}

@Component({
  selector: 'app-report-incident-form',
  standalone: true,
  imports: [FormsModule, CommonModule,RouterLink],
  templateUrl: './report-incident-form.component.html',
  styleUrls: ['./report-incident-form.component.css']
})
export class ReportIncidentFormComponent {
  incidentTypes = [
    'Vehicle Accident',
    'Workplace Injury',
    'Equipment Malfunction',
    'Safety Hazard',
    'Near Miss',
    'Other'
  ];

  report: IncidentReport = {
    dateTimeOfEntry: new Date().toISOString().split('T')[0],
    userId: '',
    typeOfAccident: '',
    location: '',
    time: new Date().toTimeString().split(' ')[0],
    shortDescription: '',
    authorizeEdit: true
  };
incident: any;

  constructor(
    private http: HttpClient,
    private router: Router
  ) {
    // Get userId from localStorage when component initializes
    const userId = localStorage.getItem('userId');
    if (userId) {
      this.report.userId = userId;
    }
  }

  onSubmit() {
    // If no date/time selected, use current date/time
    if (!this.report.dateTimeOfEntry) {
      this.report.dateTimeOfEntry = new Date().toISOString().split('T')[0];
    }
    if (!this.report.time) {
      this.report.time = new Date().toTimeString().split(' ')[0];
    }

    const API_URL = 'https://localhost:7003/api/ReportIncident';
    
    this.http.post(API_URL, this.report).subscribe({
      next: (response: any) => {
        console.log('Incident report submitted successfully:', response);
        // Navigate to success page or show success message
        this.router.navigate(['/report-history']);
      },
      error: (error: any) => {
        console.error('Error submitting incident report:', error);
        // Handle error - show error message to user
      }
    });
  }


  /// implimenting update without service. 

  UpdateReport(): void {
    if (confirm('Are you sure you want to Update this report? Note you can only update !! once 1 Please  mail to update again ')) {
      if (!this.report.dateTimeOfEntry) {
        this.report.dateTimeOfEntry = new Date().toISOString().split('T')[0];
      }
      if (!this.report.time) {
        this.report.time = new Date().toTimeString().split(' ')[0];
      }
      
      const API_URL = `https://localhost:7003/api/ReportIncident/updateReport`;
      
      this.http.put(API_URL,this.report).subscribe({
        next: () => {
          this.router.navigate(['/report-history']); // Reload the reports after successful deletion
        },
        error: (error) => {
          console.error('Error updating report:', error);
          alert('Failed to update report. Please try again.');
        }
      });
    }
  }
}
