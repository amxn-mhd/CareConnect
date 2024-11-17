import { Component, NgModule } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-emergency-services',
  standalone: true,
  imports: [NavBarComponent,FormsModule,CommonModule],
  templateUrl: './emergency-services.component.html',
  styleUrls: ['./emergency-services.component.css'],
})
export class EmergencyServicesComponent {
  hospitals = [
    { name: 'City Hospital', address: '123 Main St, YourCity', contact: '+1 555-1234' },
    { name: 'HealthCare Plus', address: '456 Elm St, YourCity', contact: '+1 555-5678' },
    { name: 'Wellness Center', address: '789 Pine St, YourCity', contact: '+1 555-9012' }
  ];

  policeStations = [
    { name: 'Central Police Station', address: '101 Main St, YourCity', contact: '+1 555-9876' },
    { name: 'Eastside Precinct', address: '202 Elm St, YourCity', contact: '+1 555-5432' },
    { name: 'West End Precinct', address: '303 Oak St, YourCity', contact: '+1 555-6543' }
  ];
}
