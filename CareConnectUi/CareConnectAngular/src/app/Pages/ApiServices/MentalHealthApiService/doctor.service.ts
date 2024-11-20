import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {


  constructor(private http:HttpClient) { }

getDoctors(){
  return this.http.get(`https://localhost:7004/api/Doctors`);

}
}

