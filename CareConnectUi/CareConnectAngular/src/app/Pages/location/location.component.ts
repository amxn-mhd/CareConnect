import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { LocationService } from '../ApiServices/SafetyEmergencyService/location.service';


export interface LocationDetails {
  location: string;
  city: string;
  state: string;
  country: string;
  postcode: string;
}
@Component({
  selector: 'app-location',
  templateUrl: './location.component.html',
  styleUrl: './location.component.css',
  standalone: true,
  imports: [CommonModule]
})
export class LocationComponent implements OnInit {
  locationDetails: LocationDetails | null = null;
  error: string = '';
  loading: boolean = false;

  constructor(private locationService: LocationService) {}

  ngOnInit() {
    this.getCurrentLocation();
  }

  async getCurrentLocation() {
    try {
      this.loading = true;
      const coords = await this.locationService.getCurrentLocation();
      
      this.locationService.getLocationDetails(coords.latitude, coords.longitude)
        .subscribe(
          (details: LocationDetails) => {
            this.locationDetails = details;
            this.loading = false;
          },
          (error) => {
            this.error = 'Error fetching location details';
            this.loading = false;
            console.error(error);
          }
        );
    } catch (error) {
      this.error = 'Error getting current location';
      this.loading = false;
      console.error(error);
    }
  }
}
