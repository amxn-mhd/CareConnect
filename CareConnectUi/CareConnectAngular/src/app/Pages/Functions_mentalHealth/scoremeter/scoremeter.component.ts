import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-scoremeter',
  standalone: true,
  imports: [],
  templateUrl: './scoremeter.component.html',
  styleUrl: './scoremeter.component.css'
})
export class ScoremeterComponent {
  @Input() score: number = 0;
}
