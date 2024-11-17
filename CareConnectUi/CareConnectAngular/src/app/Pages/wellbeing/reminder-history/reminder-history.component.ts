import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-reminder-history',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './reminder-history.component.html',
  styleUrls: ['./reminder-history.component.css']
})
export class ReminderHistoryComponent {
  reminders = [
    { title: 'Meeting with Doctor', time: '10:00 AM' },
    { title: 'Grocery Shopping', time: '02:30 PM' },
    { title: 'Pick up kids from school', time: '03:00 PM' }, // Additional sample data
    { title: 'Yoga Class', time: '06:00 PM' }               // Additional sample data
  ];
}
