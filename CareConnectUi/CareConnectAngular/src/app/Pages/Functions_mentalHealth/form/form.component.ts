import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ScoremeterComponent } from "../scoremeter/scoremeter.component";
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

interface AssessmentData {
  dateTimeOfEntry: string;
  userId: string;
  name: string;
  score: number;
  currentMood: string;
  doctorID: number;
}

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule, ScoremeterComponent, CommonModule],
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent {
  questions = [
    { text: 'Did you wake up feeling well-rested today?', answer: '' },
    { text: 'Were you able to manage stress effectively today?', answer: '' },
    { text: 'Did you feel engaged and focused on your tasks?', answer: '' },
    { text: 'Did you experience positive emotions (happiness, gratitude) at any point today?', answer: '' },
    { text: 'Did you maintain healthy interactions with others today?', answer: '' }
  ];

  @Output() calculatedScore = new EventEmitter<number>();
  score: number = 0;
  showMeter: boolean = false;

  constructor(
    private router: Router,
    private http: HttpClient
  ) {}

  private getMoodBasedOnScore(score: number): string {
    if (score >= 60) return 'Good';
    if (score > 40) return 'Average';
    return 'Poor';
  }

  onSubmit() {
    const x = localStorage.getItem('userName');
    const userId = localStorage.getItem('userId');
    console.log(x);

    // Calculate score
    const totalQuestions = this.questions.length;
    const totalYesAnswers = this.questions.reduce((sum, q) => sum + Number(q.answer), 0);
    this.score = Math.round((totalYesAnswers / totalQuestions) * 100);
    
    this.calculatedScore.emit(this.score);
    this.showMeter = true;

    // Prepare data for POST
    const assessmentData: AssessmentData = {
      dateTimeOfEntry: new Date().toISOString().split('T')[0],
      userId: userId || 'default',
      name: x || 'default',
      score: this.score,
      currentMood: this.getMoodBasedOnScore(this.score),
      doctorID: 0
    };

    // Make POST request
    const API_URL = 'https://localhost:7004/api/MoodTrackers';
    this.http.post(API_URL, assessmentData).subscribe({
      next: (response) => {
        console.log('Assessment data saved successfully:', response);
        
        // Navigate based on score after successful POST
        setTimeout(() => {
          if (this.score >= 60) {
            this.router.navigate(['mental-health/good-health']);
          } else if (this.score > 40) {
            this.router.navigate(['mental-health/average-health']);
          } else {
            this.router.navigate(['mental-health/bad-health']);
          }
        }, 1500);
      },
      error: (error) => {
        console.error('Error saving assessment data:', error);
        // Still navigate even if POST fails
        setTimeout(() => {
          if (this.score >= 60) {
            this.router.navigate(['mental-health/good-health']);
          } else if (this.score > 40) {
            this.router.navigate(['mental-health/average-health']);
          } else {
            this.router.navigate(['mental-health/bad-health']);
          }
        }, 1500);
      }
    });
  }
}
