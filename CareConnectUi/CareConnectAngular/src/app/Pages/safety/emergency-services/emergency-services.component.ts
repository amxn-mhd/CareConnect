import { Component, NgModule } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { LocationComponent } from '../../location/location.component';
import { NearbyServicesComponent } from '../../nearby-services/nearby-services.component';


@Component({
  selector: 'app-emergency-services',
  standalone: true,
  imports: [NavBarComponent,FormsModule,CommonModule,NearbyServicesComponent,LocationComponent],
  templateUrl: './emergency-services.component.html',
  styleUrls: ['./emergency-services.component.css'],
})
export class EmergencyServicesComponent {
 
}
