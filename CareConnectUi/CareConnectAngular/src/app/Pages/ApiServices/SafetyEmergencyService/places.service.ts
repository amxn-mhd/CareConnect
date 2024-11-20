// src/app/services/places.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface Place {
  name: string;
  address: string;
  city: string;
  state: string;
  country: string;
  postcode: string;
  distance: number;
  latitude: number;
  longitude: number;
}

@Injectable({
  providedIn: 'root'
})
export class PlacesService {
  private apiKey = '286a6a26241941089806893506e516cf';
  private placesApiUrl = 'https://api.geoapify.com/v2/places';

  constructor(private http: HttpClient) {}

  getNearbyPlaces(
    latitude: number,
    longitude: number,
    type: string,
    limit: number = 5
  ): Observable<Place[]> {
    const params = {
      apiKey: this.apiKey,
      categories: type,
      filter: `circle:${longitude},${latitude},5000`, // 5km radius
      limit: limit.toString(),
      bias: `proximity:${longitude},${latitude}`,
      format: 'json'
    };

    return this.http.get(this.placesApiUrl, { params }).pipe(
      map((response: any) => {
        return response.features.map((feature: any) => ({
          name: feature.properties.name || 'Unnamed',
          address: feature.properties.address_line1 || feature.properties.formatted,
          city: feature.properties.city,
          state: feature.properties.state,
          country: feature.properties.country,
          postcode: feature.properties.postcode,
          distance: Math.round(feature.properties.distance || 0),
          latitude: feature.properties.lat,
          longitude: feature.properties.lon
        }));
      })
    );
  }
}