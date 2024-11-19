import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-reminder-history',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './reminder-history.component.html',
  styleUrls: ['./reminder-history.component.css']
})
export class ReminderHistoryComponent implements OnInit {
  reminderData: any[] = [];
  userData: string | null = '';
  http = inject(HttpClient);
  Date: string | undefined;
  userId: any;
  DateTimeOfEntry: any;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.GetReminder();
  }

  GetReminder() {
    this.userData = localStorage.getItem('userId');
    console.log(this.userData);
    this.Date = new Date().toISOString().split('T')[0];


    this.http
      .get(`https://localhost:7005/api/ReminderScheduler/getReminderData?userid=${this.userData}&date=${this.Date}`)
      .subscribe({
        next: (res: any) => {
          console.log(res);
          this.reminderData = Array.isArray(res) ? res : [res]; // Adjust based on API response
          this.cdr.detectChanges(); // Ensure UI updates
        },
        error: (err) => {
          console.error('Error fetching mood data:', err);
          this.reminderData = [];
        }
      });
  }
  deleteReminder(index: number): void {

    if (confirm('Are you sure you want to delete this reminder?')) {
 
      // Format date as YYYY-MM-DD
 
      const userId = localStorage.getItem('userId');
 
 
 
      const API_URL = `https://localhost:7005/api/ReminderScheduler?Totalreminders=${index}&id=${userId}`;
 
 
 
      this.http.delete(API_URL).subscribe({
 
        next: () => {
 
          this.GetReminder(); // Reload the reports after successful deletion
 
        },
 
        error: (error) => {
 
          console.error('Error deleting report:', error);
 
          alert('Failed to delete reminder. Please try again.');
 
        }
 
      });
 
    }
 
  }
 
 


}