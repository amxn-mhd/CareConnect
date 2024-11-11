import { RouterModule, Routes } from '@angular/router';
import { MentalHealthComponent } from './Pages/mental-health/mental-health.component';
import { WellbeingComponent } from './Pages/wellbeing/wellbeing.component';
import { SafetyComponent } from './Pages/safety/safety.component';
import { NgModule } from '@angular/core';
import { ServiceComponent } from './Pages/service/service.component';

export const routes: Routes = [
    { path: 'mental-health', component: MentalHealthComponent },
{ path: 'wellbeing', component: WellbeingComponent },
{ path: 'safety', component: SafetyComponent },
{ path: 'service', component: ServiceComponent }, 
  { path: '', redirectTo: '/home', pathMatch: 'full' }]

//optional....
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }