import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditComponent } from './components/add-edit/add-edit.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ListComponent } from './components/list/list.component';

const routes: Routes = [
    {
      path:'', component:LayoutComponent,
      children: [
        { path: '', component: ListComponent },
        { path: 'add', component: AddEditComponent },
    ]
    },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DonationRoutingModule { }
