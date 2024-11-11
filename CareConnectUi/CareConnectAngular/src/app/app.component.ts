import { Component,OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Router, NavigationEnd, Event } from '@angular/router';import { filter } from 'rxjs/operators';
import { ServiceComponent } from "./Pages/service/service.component";
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,CommonModule, ServiceComponent],
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
        this.showButtons = event.url === '/' || event.url === '/home';
      });
    }
}
