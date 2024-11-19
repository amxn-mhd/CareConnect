import { Component, NgModule, inject } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { ReminderHistoryComponent } from "../reminder-history/reminder-history.component";
import { RouterLink } from '@angular/router';
import { FormsModule, NgModel } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-remider-scheduler',
  standalone: true,
  imports: [FormsModule, CommonModule, NavBarComponent, ReminderHistoryComponent, RouterLink, HttpClientModule],
  templateUrl: './remider-scheduler.component.html',
  styleUrls: ['./remider-scheduler.component.css']
})
export class RemiderSchedulerComponent {
  reminder = { title: '', time: '' };
  message: string | null = null;
  isSuccess: boolean = false;

  private http = inject(HttpClient);
  private apiUrl = 'https://localhost:7005/api/ReminderScheduler';

  onSubmit(): void {
    // Prepare the data for submission
    const userReminderLog = {
      Task: this.reminder.title,
      Time: this.reminder.time,
      DateTimeOfEntry: new Date().toISOString().split('T')[0], // YYYY-MM-DD format
      UserId: localStorage.getItem('userId') // Retrieve User ID from local storage
    };

    // Make POST request to the API
    this.http.post(this.apiUrl, userReminderLog).subscribe({
      next: (response) => {
        this.message = 'Reminder successfully submitted!';
        this.isSuccess = true;

        // Clear form fields after successful submission
        this.reminder.title = '';
        this.reminder.time = '';
      },
      error: (error) => {
        console.error('Error submitting reminder:', error);
        this.message = 'Failed to submit reminder. Please try again.';
        this.isSuccess = false;
      }
    });
  }



  
}
