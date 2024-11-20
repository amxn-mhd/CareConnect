import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { LocationService } from "../ApiServices/SafetyEmergencyService/location.service";
import { Place, PlacesService } from "../ApiServices/SafetyEmergencyService/places.service";

@Component({
  selector: 'app-nearby-services',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './nearby-services.component.html',
  styleUrls: ['./nearby-services.component.scss']
})
export class NearbyServicesComponent implements OnInit {
  hospitals: Place[] = [];
  policeStations: Place[] = [];
  loading = false;
  error = '';
  userLocation: { latitude: number; longitude: number } | null = null;

  constructor(
    private placesService: PlacesService,
    private locationService: LocationService
  ) {}

  ngOnInit() {
    this.fetchNearbyServices();
  }

  async fetchNearbyServices() {
    try {
      this.loading = true;
      const coords = await this.locationService.getCurrentLocation();
      this.userLocation = {
        latitude:  8.524139,
        longitude: 76.936638
        // latitude: coords.latitude,
        // longitude: coords.longitude
      };

      // Fetch hospitals and police stations in parallel
      const [hospitals, policeStations] = await Promise.all([
        this.placesService.getNearbyPlaces(
          17.4374,78.4824,
          // coords.latitude,
          // coords.longitude,
          'healthcare.hospital'
        ).toPromise(),
        this.placesService.getNearbyPlaces(
          17.4374,78.4824,

          // coords.latitude,
          // coords.longitude,
          'service.police'
        ).toPromise()
      ]);

      this.hospitals = hospitals || [];
      this.policeStations = policeStations || [];
      this.loading = false;
    } catch (error) {
      this.error = 'Error fetching nearby services';
      this.loading = false;
      console.error(error);
    }
  }

  getDirectionsUrl(place: Place): string {
    if (!this.userLocation) return '#';
    
    const origin = `${this.userLocation.latitude},${this.userLocation.longitude}`;
    const destination = `${place.latitude},${place.longitude}`;
    return `https://www.google.com/maps/dir/${origin}/${destination}`;
  }
}

