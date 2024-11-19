import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { ChangeDetectorRef, Component, NgModule, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sleep-history',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './sleep-history.component.html',
  styleUrls: ['./sleep-history.component.css']
})
export class SleepHistoryComponent {
  sleeprData: any[] = [];
  userData: string | null = '';
  http = inject(HttpClient);
  Date: string | undefined;

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.GetSleepHistory();
  }

  GetSleepHistory() {
    this.userData = localStorage.getItem('userId');
    console.log(this.userData);
    this.Date = new Date().toISOString().split('T')[0];


    this.http
      .get(`https://localhost:7005/api/SleepAnalyser?userid=${this.userData}`)
      .subscribe({
        next: (res: any) => {
          console.log(res);
          this. sleeprData = Array.isArray(res) ? res : [res]; // Adjust based on API response
          this.cdr.detectChanges(); // Ensure UI updates
        },
        error: (err) => {
          console.error('Error fetching sleep data:', err);
          this. sleeprData = [];
        }
      });
  }
  deleteHistory(index: number): void {

    if (confirm('Are you sure you want to delete this history?')) {
 
      // Format date as YYYY-MM-DD
 
      const userId = localStorage.getItem('userId');
 
      
 
 
 
      const API_URL = `https://localhost:7005/api/SleepAnalyser?EntryId=${index}&useri=${userId}`;
 
 
 
      this.http.delete(API_URL).subscribe({
 
        next: () => {
 
          this.GetSleepHistory(); // Reload the reports after successful deletion
 
        },
 
        error: (error) => {
 
          console.error('Error deleting report:', error);
 
          alert('Failed to delete history. Please try again.');
 
        }
 
      });
 
    }
 
  }
 
 

}
