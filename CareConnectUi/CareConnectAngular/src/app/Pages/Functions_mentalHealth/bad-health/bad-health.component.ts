import { ChangeDetectorRef, Component, OnInit, inject } from '@angular/core';
import { ScoremeterComponent } from "../scoremeter/scoremeter.component";
import { HttpClient } from '@angular/common/http';
import { DoctorService } from '../../ApiServices/MentalHealthApiService/doctor.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bad-health',
  standalone: true,
  imports: [ScoremeterComponent,CommonModule],
  templateUrl: './bad-health.component.html',
  styleUrl: './bad-health.component.css'
})
export class BadHealthComponent implements OnInit {
  doctors: any[] = []; 

  constructor(private doctorService: DoctorService) {}

  ngOnInit(): void {
    this.loadDoctors();
  }

  loadDoctors(): void {
    this.doctorService.getDoctors().subscribe({
      next: (data: any) => {
        this.doctors = data; // Assign the data to the doctors array
      },
      error: (err) => {
        console.error('Error fetching doctors:', err); // Handle errors
      }
    });
  }
}
