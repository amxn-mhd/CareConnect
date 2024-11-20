import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from "../dashboard/nav-bar/nav-bar.component";

@Component({
  selector: 'app-mental-health',
  standalone: true,
  imports: [FormsModule, RouterOutlet, CommonModule, NavBarComponent],
  templateUrl: './mental-health.component.html',
  styleUrls: ['./mental-health.component.css'],
})
export class MentalHealthComponent {
//  var x=[score]
   updatedscore:number=0;

   updateScore(score:number){
    this.updatedscore=score;
   }

}
