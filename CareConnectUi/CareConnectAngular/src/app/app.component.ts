import { Component,OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Router, NavigationEnd, Event } from '@angular/router';import { filter } from 'rxjs/operators';
import { CommonModule } from '@angular/common';
import { HomeComponent } from "./Pages/home/home.component";
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { LandingPageComponent } from './Pages/LandAndAuth/landing-page/landing-page.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink,CommonModule,LandingPageComponent, HomeComponent,MatIconModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements  OnInit  {

  title = 'CareConnectAngular';

  showButtons = true;

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events
      .pipe(filter((event: Event): event is NavigationEnd => event instanceof NavigationEnd))
      .subscribe((event: NavigationEnd) => {
        // Show buttons only on the default route (home page)
        this.showButtons = event.url === '/' || event.url === '/';
      });
    }
}
