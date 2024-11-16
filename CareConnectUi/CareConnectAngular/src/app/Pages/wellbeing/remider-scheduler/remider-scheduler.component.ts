import { Component } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { ReminderHistoryComponent } from "../reminder-history/reminder-history.component";
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-remider-scheduler',
  standalone: true,
  imports: [NavBarComponent, ReminderHistoryComponent,RouterLink],
  templateUrl: './remider-scheduler.component.html',
  styleUrl: './remider-scheduler.component.css'
})
export class RemiderSchedulerComponent {

}
