import { CommonModule } from '@angular/common';
import { Component, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sleep-history',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './sleep-history.component.html',
  styleUrls: ['./sleep-history.component.css']
})
export class SleepHistoryComponent {
  sleepData = [
    { date: '2024-11-01', hoursSlept: 8 },
    { date: '2024-11-02', hoursSlept: 7 },
    { date: '2024-11-03', hoursSlept: 6.5 },
    { date: '2024-11-04', hoursSlept: 8 },
    { date: '2024-11-05', hoursSlept: 7.5 }
  ];
}
