import { Component } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ReportIncidentFormComponent } from "../report-incident-form/report-incident-form.component";
import { ReportHistoryComponent } from "../report-history/report-history.component";
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";

@Component({
  selector: 'app-report-incident',
  standalone: true,
  imports: [ReportIncidentFormComponent, ReportHistoryComponent, NavBarComponent],
  templateUrl: './report-incident.component.html',
  styleUrls: ['./report-incident.component.css'],
})
export class ReportIncidentComponent {
  incidents: any[] = [];

  handleIncidentReported(newIncident: any) {
    this.incidents.push(newIncident);
  }
}
