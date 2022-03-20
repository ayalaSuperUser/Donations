import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DonationModule } from './donation/donation.module';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
    {
      path:'', component:HomeComponent,
     
    },
    { path: 'donations', loadChildren: ()=>import('./donation/donation.module').then(m=>m.DonationModule) },
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
