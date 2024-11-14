import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { MentalHealthService } from '../ApiServices/MentalHealthApiService/mental-health.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-service',
  standalone: true,
  imports: [RouterLink,CommonModule],
  
  templateUrl: './service.component.html',
  styleUrl: './service.component.css'
})
export class ServiceComponent{}