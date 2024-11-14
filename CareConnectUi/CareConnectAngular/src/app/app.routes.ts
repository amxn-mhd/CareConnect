import { RouterModule, Routes } from '@angular/router';
import { MentalHealthComponent } from './Pages/mental-health/mental-health.component';
import { WellbeingComponent } from './Pages/wellbeing/wellbeing.component';
import { SafetyComponent } from './Pages/safety/safety.component';
import { NgModule } from '@angular/core';
import { ServiceComponent } from './Pages/service/service.component';
import { FormComponent } from './Pages/Functions_mentalHealth/form/form.component';
import { GoodHealthComponent } from './Pages/Functions_mentalHealth/good-health/good-health.component';
import { AverageHealthComponent } from './Pages/Functions_mentalHealth/average-health/average-health.component';
import { BadHealthComponent } from './Pages/Functions_mentalHealth/bad-health/bad-health.component';
import { HomeComponent } from './Pages/home/home.component';
import { LandingPageComponent } from './Pages/LandAndAuth/landing-page/landing-page.component';

export const routes: Routes = [
  { path: '', redirectTo: 'landing-page', pathMatch: 'full' },  // Redirect to a valid path
  {path:'landing-page', component:LandingPageComponent},

  {path:'home', component:HomeComponent ,children:[  
    { path: 'service', component: ServiceComponent },
]},
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
  { path: 'safety', component: SafetyComponent },
  { path: '**', redirectTo: 'home' }  
];

//optional....
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }