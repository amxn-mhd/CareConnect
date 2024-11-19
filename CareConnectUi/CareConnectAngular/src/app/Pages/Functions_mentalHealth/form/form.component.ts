import { Component, EventEmitter, Output } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ScoremeterComponent } from "../scoremeter/scoremeter.component";
import { CommonModule } from '@angular/common';

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
    // { text: 'Did you spend quality time with friends or family?', answer: '' },
    // { text: 'Did you take a moment to relax or unwind?', answer: '' },
    // { text: 'Did you feel confident in handling challenges today?', answer: '' },
    // { text: 'Did you make decisions without hesitation?', answer: '' },
    // { text: 'Did you feel grateful for something today?', answer: '' }

  ];
  
  @Output() calculatedScore = new EventEmitter<number>();
  score: number = 0;
  showMeter: boolean = false;

  constructor(private router: Router) {}

  onSubmit() {
    const totalPossibleScore = this.questions.length * 2;
    const actualScore = this.questions.reduce((sum, q) => sum + Number(q.answer), 0);
    this.score = Math.round((actualScore / totalPossibleScore) * 100);
    this.showMeter = true;
    this.calculatedScore.emit(this.score);

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
}
