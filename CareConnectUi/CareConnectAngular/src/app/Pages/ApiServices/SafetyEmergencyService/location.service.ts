import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  private apiKey = '286a6a26241941089806893506e516cf'; // Replace with your actual API key
  private apiUrl = 'https://api.geoapify.com/v1/geocode/reverse';

  constructor(private http: HttpClient) {}

  getCurrentLocation(): Promise<GeolocationCoordinates> {
    return new Promise((resolve, reject) => {
      if (!navigator.geolocation) {
        reject('Geolocation is not supported by your browser');
      }
      
      navigator.geolocation.getCurrentPosition(
        (position) => {
          resolve(position.coords);
        },
        (error) => {
          reject(error);
        }
      );
    });
  }

  getLocationDetails(latitude: number, longitude: number): Observable<any> {
    const params = {
      lat: latitude.toString(),
      lon: longitude.toString(),
      apiKey: this.apiKey,
      format: 'json'
    };

    return this.http.get(this.apiUrl, { params }).pipe(
      map((response: any) => {
        const result = response.results[0];
        return {
          location: result.formatted,
          city: result.city,
          state: result.state,
          country: result.country,
          postcode: result.postcode
        };
      })
    );
  }
}
