import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  isAuthenticated(): boolean {
    const token = localStorage.getItem('token');
    const userId = localStorage.getItem('userId');
    const role=localStorage.getItem('role')
    return !!token && !!userId;
  }

  private apiUrl = 'https://localhost:7094/api/Auth'; // Replace with your API base URL

 private currentUserSubject = new BehaviorSubject<any>(null);

 currentUser$ = this.currentUserSubject.asObservable();

 constructor(private http: HttpClient, private router: Router) {}

 register(userData: any) {

  return this.http.post(`${this.apiUrl}/register`, userData);

 }

 login(credentials: any) {

  return this.http.post(`${this.apiUrl}/login`, credentials);

 }

 saveUserData(userData: any) {

  localStorage.setItem('user', JSON.stringify(userData));
  localStorage.setItem('userId',userData.user.id)
  localStorage.setItem('userName',userData.user.userName)
  

  this.currentUserSubject.next(userData);

 }

 logout() {

  localStorage.removeItem('user');

  this.currentUserSubject.next(null);

  this.router.navigate(['/login']);

 }

 getCurrentUser() {

  const userData = localStorage.getItem('user');

  if (userData) {

   return JSON.parse(userData);

  }

  return null;

 }

}
