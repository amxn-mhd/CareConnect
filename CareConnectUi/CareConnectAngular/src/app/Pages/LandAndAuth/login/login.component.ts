import { Component } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../Service/auth.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [RouterLink,FormsModule,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginData = {

    userName: '',
  
    password: '',
  
   };
  
   errorMessage = '';
  
   constructor(private authService: AuthService, private router: Router) {}
  
   onLogin() {
  
    this.authService.login(this.loginData).subscribe({
  
     next: (response: any) => {
  
      this.authService.saveUserData(response.result);
  
      const role = response.result.role;
  
      if (role === 'Admin') {
  
       this.router.navigate(['/admin-dashboard']);
  
      } else if (role === 'User') {
  
       this.router.navigate(['/dashboard']);
  
      }
  
     },
  
     error: (err) => {
  
      this.errorMessage = err.error?.message || 'Login failed.';
  
     },
  
    });
  
   }
  
  }

