import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mood-analyser',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './mood-analyser.component.html',
  styleUrls: ['./mood-analyser.component.css']
})
export class MoodAnalyserComponent {
  moodData = [
    { date: '2024-11-01', score: 8 },
    { date: '2024-11-02', score: 7 },
    { date: '2024-11-03', score: 6 },
    { date: '2024-11-04', score: 5 },
    { date: '2024-11-05', score: 9 }
  ];
}
