import { Component } from '@angular/core';
import { MoodAnalyserComponent } from "../mental-health/mood-analyser/mood-analyser.component";
// import { ReminderSchedulerComponent } from "../wellbeing/dummy/reminder-history.component";
import { NavBarComponent } from "./nav-bar/nav-bar.component";
import { RouterLink } from '@angular/router';
import { ReminderHistoryComponent } from '../wellbeing/reminder-history/reminder-history.component';
import { EmergencyServicesComponent } from '../safety/emergency-services/emergency-services.component';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [MoodAnalyserComponent, ReminderHistoryComponent, NavBarComponent,RouterLink],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css'
})
export class DashboardComponent {

}
