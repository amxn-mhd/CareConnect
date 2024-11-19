import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-mood-analyser',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './mood-analyser.component.html',
  styleUrls: ['./mood-analyser.component.css']
})
export class MoodAnalyserComponent implements OnInit {
  moodData: any[] = [];
  userData: string | null = '';
  http = inject(HttpClient);

  constructor(private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.getMoodData();
  }

  getMoodData() {
    this.userData = localStorage.getItem('userId');
    console.log(this.userData);
    this.http
      .get(`https://localhost:7004/api/MoodTrackers/getMoodDataByUserID?userid=${this.userData}`)
      .subscribe({
        next: (res: any) => {
          console.log(res);
          this.moodData = Array.isArray(res) ? res : [res]; // Adjust based on API response
          this.cdr.detectChanges(); // Ensure UI updates
        },
        error: (err) => {
          console.error('Error fetching mood data:', err);
          this.moodData = [];
        }
      });
  }
}