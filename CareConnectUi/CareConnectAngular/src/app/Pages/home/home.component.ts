import { CommonModule, DatePipe } from '@angular/common';
import { ImplicitReceiver } from '@angular/compiler';
import { Component, OnInit, inject } from '@angular/core';
import { MentalHealthService } from '../ApiServices/MentalHealthApiService/mental-health.service';
import { RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [FormsModule ,RouterLink,CommonModule,],
  providers: [DatePipe],  // Add this line
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  constructor(private datePipe: DatePipe) {}

  mentalHealthService=inject(MentalHealthService)
  DateWiseMoodList:any[]=[];
  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(){
    this.mentalHealthService.getMood(1).subscribe((res: any) => {
      console.log(res);  // Check the structure of the returned data
      this.DateWiseMoodList = res;})
  }

 

  reminders = [
    { id: 'breakfast', task: 'Have Breakfast', time: '08:00 AM' },
    { id: 'card', task: 'Swipe ID Card', time: '09:00 AM' },
    { id: 'snack', task: 'Have Snack', time: '11:00 AM' },
    { id: 'boss', task: 'Call Boss', time: '11:30 AM' },
    { id: 'water', task: 'Drink Water', time: '12:00 PM' },
    { id: 'lunch', task: 'Have Lunch', time: '02:00 PM' },
    { id: 'task', task: "Complete Yesterday's Task", time: '03:00 PM' },
    { id: 'dinner', task: 'Order food for Dinner', time: '07:00 PM' }
  ];
}

