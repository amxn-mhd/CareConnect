import { Component, NgModule } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { ReminderHistoryComponent } from "../reminder-history/reminder-history.component";
import { RouterLink } from '@angular/router';
import { FormsModule, NgModel } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-remider-scheduler',
  standalone: true,
  imports: [FormsModule,CommonModule,NavBarComponent, ReminderHistoryComponent, RouterLink],
  templateUrl: './remider-scheduler.component.html',
  styleUrls: ['./remider-scheduler.component.css']
})
export class RemiderSchedulerComponent {
  reminder = { title: '', time: '' };
  message: string | null = null;
  isSuccess: boolean = false;

  onSubmit(): void {
    // Simulate a successful form submission
    this.message = "Reminder successfully submitted!";
    this.isSuccess = true;
    
    // Optionally, clear the form after submission
    this.reminder.title = '';
    this.reminder.time = '';
  }
}
