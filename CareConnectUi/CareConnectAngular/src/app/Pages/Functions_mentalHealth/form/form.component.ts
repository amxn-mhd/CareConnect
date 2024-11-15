import { Component ,EventEmitter,Output} from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ScoremeterComponent } from "../scoremeter/scoremeter.component";
import { CommonModule } from '@angular/common';
import { BadHealthComponent } from "../bad-health/bad-health.component";

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [FormsModule, ScoremeterComponent, CommonModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {
  //questions need to be edited . 
  questions = [
    { text: 'How often do you feel stressed?', answer: '' },
    { text: 'How well do you sleep at night?', answer: '' },
    { text: 'How often do you feel energetic?', answer: '' },
    { text: 'How often do you feel positive about the future?', answer: '' },
    { text: 'How well can you concentrate on tasks?', answer: '' }
  ];
  @Output() calculatedScore = new EventEmitter<number>();
   score: number = 0;
  showMeter: boolean = false;

  constructor(private router: Router) {}

  onSubmit() {
    const totalPossibleScore = this.questions.length * 4;
    const actualScore = this.questions.reduce((sum, q) => sum + Number(q.answer), 0);
    this.score = Math.round((actualScore / totalPossibleScore) * 100);
    this.showMeter = true;
    this.calculatedScore .emit(this.score)
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
