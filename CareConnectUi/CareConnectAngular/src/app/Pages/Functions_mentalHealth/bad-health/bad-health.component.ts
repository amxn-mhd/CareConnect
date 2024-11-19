import { Component } from '@angular/core';
import { ScoremeterComponent } from "../scoremeter/scoremeter.component";

@Component({
  selector: 'app-bad-health',
  standalone: true,
  imports: [ScoremeterComponent],
  templateUrl: './bad-health.component.html',
  styleUrl: './bad-health.component.css'
})
export class BadHealthComponent {

}
