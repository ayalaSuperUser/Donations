import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditComponent } from './components/add-edit/add-edit.component';
import { ListComponent } from './components/list/list.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatExpansionModule} from '@angular/material/expansion';
import { MatNativeDateModule } from '@angular/material/core';
import { LayoutComponent } from './components/layout/layout.component';
import { Router, RouterModule } from '@angular/router';
import { DonationRoutingModule } from './donation-routing.module';

@NgModule({
  declarations: [
    AddEditComponent,
    ListComponent,
    LayoutComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatExpansionModule,
    MatNativeDateModule,
    DonationRoutingModule,
    RouterModule  ],
})
export class DonationModule { }
