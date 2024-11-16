import { Component } from '@angular/core';
import { NavBarComponent } from "../../dashboard/nav-bar/nav-bar.component";

@Component({
  selector: 'app-emergency-services',
  standalone: true,
  imports: [NavBarComponent],
  templateUrl: './emergency-services.component.html',
  styleUrl: './emergency-services.component.css',
})
export class EmergencyServicesComponent {}
