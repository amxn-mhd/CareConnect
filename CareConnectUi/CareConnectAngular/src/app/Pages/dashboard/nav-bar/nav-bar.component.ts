import { Component } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { routes } from '../../../app.routes';

@Component({
  selector: 'app-nav-bar',
  standalone: true,
  imports: [RouterOutlet,RouterLink],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent {
  isUserLoggedIn: boolean=false;
  constructor(private router: Router) {}

  ngOnInit(): void {
    // Check if userId exists in localStorage
    this.isUserLoggedIn = !localStorage.getItem('userId');
  }

  logout(): void {
    // Clear localStorage and update isUserLoggedIn
    localStorage.clear();
    this.isUserLoggedIn = false;
  }
}
  
