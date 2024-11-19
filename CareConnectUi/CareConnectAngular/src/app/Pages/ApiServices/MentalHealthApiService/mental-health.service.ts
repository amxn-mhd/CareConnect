import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MentalHealthService {

  constructor(private http:HttpClient) {
     
   }
    getMood( Id: number) {
      return this.http.get(`https://localhost:7253/api/MoodTrackers/GetByUser?id=${Id}`);  }
  
}




