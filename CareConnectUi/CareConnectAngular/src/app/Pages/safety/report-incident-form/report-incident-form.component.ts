import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-report-incident-form',
  standalone: true,
  imports:[FormsModule],
  templateUrl: './report-incident-form.component.html',
  styleUrls: ['./report-incident-form.component.css'],
})
export class ReportIncidentFormComponent {
  @Output() incidentReported = new EventEmitter<any>();

  incident = {
    type: '',
    location: '',
    time: '',
    description: '',
  };

  incidentTypes = ['Hazard', 'Accident', 'Natural Disaster'];

  onSubmit() {
    this.incidentReported.emit({ ...this.incident });
    this.incident = { type: '', location: '', time: '', description: '' };
  }
}
