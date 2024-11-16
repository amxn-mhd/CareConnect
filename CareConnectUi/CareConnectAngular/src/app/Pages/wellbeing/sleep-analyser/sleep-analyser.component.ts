import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { SleepHistoryComponent } from "../sleep-history/sleep-history.component";

@Component({
  selector: 'app-sleep-analyser',
  standalone: true,
  imports: [RouterOutlet, RouterLink, NavBarComponent, SleepHistoryComponent],
  templateUrl: './sleep-analyser.component.html',
  styleUrl: './sleep-analyser.component.css'
})
export class SleepAnalyserComponent {

}
