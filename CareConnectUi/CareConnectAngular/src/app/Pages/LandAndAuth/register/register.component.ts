import { Component } from '@angular/core';
import { AuthService } from '../../Service/auth.service';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {


  registerData = {

    Email: '',
  
    Name: '',
  
    PhoneNumber: '',
  
    Password: '',

    Age: 0,
  
    BloodGroup: '',
  
    MaritalStatus: '',

    JobDescription:'',
  
    role: 'User',
  
   };
  
   successMessage = '';
  
   errorMessage = '';
  
   constructor(private authService: AuthService, private router: Router) {}
  
   onRegister() {
  
    this.authService.register(this.registerData).subscribe({
  
     next: () => {
  
      this.successMessage = 'Registration successful!';
  
      this.errorMessage = '';
  
      this.router.navigate(['/login']);
  
     },
  
     error: (err) => {
  
      this.errorMessage = err.error?.message || 'Registration failed.';
  
     },
  
    });
  
   }
  
  }
  
  
  
  
  
  
  
  


