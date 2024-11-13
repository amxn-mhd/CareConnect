import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mental-health',
  standalone: true,
  imports: [RouterOutlet,CommonModule],
  templateUrl: './mental-health.component.html',
  styleUrls: ['./mental-health.component.css'],
})
export class MentalHealthComponent {
//  var x=[score]

}
