import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { LocationComponent } from './location/location.component';

@Component({
  selector: 'app-safety',
  standalone: true,
  imports: [RouterOutlet,RouterLink,CommonModule,LocationComponent],
  templateUrl: './safety.component.html',
  styleUrl: './safety.component.css'
})
export class SafetyComponent {

}
