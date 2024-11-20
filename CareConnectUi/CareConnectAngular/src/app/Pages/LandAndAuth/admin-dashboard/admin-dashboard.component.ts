import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { HttpClient } from '@angular/common/http';
import { ReportHistoryComponent } from "../../safety/report-history/report-history.component";
import { CommonModule } from '@angular/common';
import { EmailService } from '../../ApiServices/email.service';
interface UserData {
  id: string;
  name: string;
  email: string;
  age: number;
  bloodGroup: string;
}

@Component({
  selector: 'app-admin-dashboard',
  standalone: true,
  imports: [RouterLink, NavBarComponent, CommonModule, RouterOutlet, ReportHistoryComponent],
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {
  reports: UserData[] = [];
  loading: boolean = true;
  error: string | null = null;

  constructor(
    private http: HttpClient,
    private emailService: EmailService
  ) {}

  async sendHelpEmail(report: UserData) {
    try {
      await this.emailService.sendHelpRequestEmail(report);
      alert('Email sent successfully to ' + report.name);
    } catch (error) {
      console.error('Failed to send email:', error);
      alert('Failed to send email. Please try again.');
    }
  }

  ngOnInit(): void {
    this.loadReports();
  }

  loadReports(): void {
    const API_URL = `https://localhost:7094/api/consumer/consumers`;
    
    this.http.get<UserData[]>(API_URL).subscribe({
      next: (response) => {
        this.reports = response;
        this.loading = false;
        console.log(this.reports);
      },
      error: (error) => {
        console.error('Error loading reports:', error);
        this.error = 'Failed to load incident reports.';
        this.loading = false;
      }
    });
  }
}