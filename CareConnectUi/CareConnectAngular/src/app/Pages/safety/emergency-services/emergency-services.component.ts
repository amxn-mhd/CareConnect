import { Component } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";
import { LocationComponent } from '../location/location.component';

@Component({
  selector: 'app-emergency-services',
  standalone: true,
  imports: [NavBarComponent,LocationComponent],
  templateUrl: './emergency-services.component.html',
  styleUrl: './emergency-services.component.css',
})
export class EmergencyServicesComponent {}
