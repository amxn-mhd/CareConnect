import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";

interface IncidentReport {
  dateTimeOfEntry: string;
  location: string;
  typeOfAccident: string;
  incidentId: number;
  shortDescription:string;
}

@Component({
  selector: 'app-report-history',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterLink, NavBarComponent],
  templateUrl: './report-history.component.html',
  styleUrls: ['./report-history.component.css']
})
export class ReportHistoryComponent implements OnInit {
  reports: IncidentReport[] = [];
  loading: boolean = true;
  error: string | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.loadReports();
  }

  loadReports(): void {
    const userid=localStorage.getItem('userId');
    const API_URL = `https://localhost:7003/api/ReportIncident/getReportData?userid=${userid}`;
    
    this.http.get<IncidentReport[]>(API_URL).subscribe({
      next: (response) => {
        this.reports = response;
        this.loading = false;

      },
      error: (error) => {
        console.error('Error loading reports:', error);
        this.error = 'Failed to load incident reports.';
        this.loading = false;
      }
    });
  }

  // deleting function implimentaaion.
  deleteReport(index: number): void {
    if (confirm('Are you sure you want to delete this report?')) {
      const reportDate = this.reports[index].dateTimeOfEntry.split('T')[0]; // Format date as YYYY-MM-DD
      const userId = localStorage.getItem('userId');
      const id=this.reports[index].incidentId;
      
      const API_URL = `https://localhost:7003/api/ReportIncident?incidentid=${id}&userid=${userId}`;
      
      this.http.delete(API_URL).subscribe({
        next: () => {
          this.loadReports(); // Reload the reports after successful deletion
        },
        error: (error) => {
          console.error('Error deleting report:', error);
          alert('Failed to delete report. Please try again.');
        }
      });
    }
  }


  
}
