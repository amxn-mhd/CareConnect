import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { SleepHistoryComponent } from "../sleep-history/sleep-history.component";

@Component({
  selector: 'app-sleep-analyser',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterOutlet, RouterLink, NavBarComponent, SleepHistoryComponent],
  templateUrl: './sleep-analyser.component.html',
  styleUrls: ['./sleep-analyser.component.css']
})
export class SleepAnalyserComponent {
  hours: number = 8;
  time: string = '';
  message: string | null = null;
  isSuccess: boolean = false;

  // Form Submit Handler
  onSubmit(): void {
    // Simulate a successful form submission
    this.message = "Sleep data successfully submitted!";
    this.isSuccess = true;

    // Optionally, clear the form after submission
    this.hours = 8; // Default value
    this.time = ''; // Clear the time input
  }
}
