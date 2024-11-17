import { RouterModule, Routes } from '@angular/router';
import { MentalHealthComponent } from './Pages/mental-health/mental-health.component';
import { WellbeingComponent } from './Pages/wellbeing/wellbeing.component';
import { SafetyComponent } from './Pages/safety/safety.component';
import { NgModule } from '@angular/core';
import { FormComponent } from './Pages/Functions_mentalHealth/form/form.component';
import { GoodHealthComponent } from './Pages/Functions_mentalHealth/good-health/good-health.component';
import { AverageHealthComponent } from './Pages/Functions_mentalHealth/average-health/average-health.component';
import { BadHealthComponent } from './Pages/Functions_mentalHealth/bad-health/bad-health.component';
import { HomeComponent } from './Pages/home/home.component';
import { LandingPageComponent } from './Pages/LandAndAuth/landing-page/landing-page.component';
import { LoginComponent } from './Pages/LandAndAuth/login/login.component';
import { RegisterComponent } from './Pages/LandAndAuth/register/register.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { SleepAnalyserComponent } from './Pages/wellbeing/sleep-analyser/sleep-analyser.component';
import { RemiderSchedulerComponent } from './Pages/wellbeing/remider-scheduler/remider-scheduler.component';
import { EmergencyServicesComponent } from './Pages/safety/emergency-services/emergency-services.component';
import { ReportIncidentComponent } from './Pages/safety/report-incident/report-incident.component';
import { AdminDashboardComponent } from './Pages/LandAndAuth/admin-dashboard/admin-dashboard.component';

export const routes: Routes = [
  { path: '', redirectTo: 'landing-page', pathMatch: 'full' },  // Redirect to a valid path
  {path:'landing-page', component:LandingPageComponent},
  {path:'login',component:LoginComponent},
  {path:'register',component:RegisterComponent},
  {path:'dashboard', component:DashboardComponent},
  {
    path: 'mental-health', component: MentalHealthComponent, children: [
      { path: '', redirectTo: 'form', pathMatch: 'full' },  // Redirect to a valid path

      { path: 'form', component: FormComponent },  // Default child route for MentalHealth
      { path: 'good-health', component: GoodHealthComponent },
      { path: 'average-health', component: AverageHealthComponent },
      { path: 'bad-health', component: BadHealthComponent }
    ]
  },
  
  { path: 'wellbeing', component: WellbeingComponent },
  {path: 'sleep-analyser',component:SleepAnalyserComponent},
  {path: 'reminder-scheduler',component:RemiderSchedulerComponent},
  { path: 'safety', component: SafetyComponent },
  { path: 'report-incident', component: ReportIncidentComponent },
  { path: 'emergency-services', component: EmergencyServicesComponent },
  { path: '**', redirectTo: 'home' }  ,
  { path:'admin-dashboard',component:AdminDashboardComponent}
];

//optional....
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }