import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { SleepHistoryComponent } from "../sleep-history/sleep-history.component";
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-sleep-analyser',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterOutlet, RouterLink, NavBarComponent, SleepHistoryComponent],
  templateUrl: './sleep-analyser.component.html',
  styleUrls: ['./sleep-analyser.component.css']
})
export class SleepAnalyserComponent {
  sleepAnalyser = { hours: 0, remarks: '' };
  message: string | null = null;
  isSuccess: boolean = false;

  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7005/api/SleepAnalyser';

  onSubmit(): void {
    // Prepare the data for submission
    const userSleepLog = {
      Rating: this.sleepAnalyser.hours,
      Remarks: this.sleepAnalyser.remarks,
      DateTimeOfEntry: new Date().toISOString().split('T')[0], // YYYY-MM-DD format
      UserId: localStorage.getItem('userId') // Retrieve User ID from local storage
    };

    // Make POST request to the API
    this.http.post(this.apiUrl, userSleepLog).subscribe({
      next: (response) => {
        this.message = 'Sleep history successfully submitted!';
        this.isSuccess = true;

        // Clear form fields after successful submission
        this.sleepAnalyser.hours = 0;
        this.sleepAnalyser.remarks = '';
      },
      error: (error) => {
        console.error('Error submitting reminder:', error);
        this.message = 'Failed to submit sleep history. Please try again.';
        this.isSuccess = false;
      }
    });
  }
}
