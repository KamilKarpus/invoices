import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerComponent } from './customer/customer.component';
import { CustomerRoutes } from './customer.routing';
import { MaterialModule } from '../material/material-module';
import { MenuComponent } from './menu/menu.component';
import { ClientAddComponent } from './client-add/client-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [CustomerComponent, MenuComponent, ClientAddComponent],
  imports: [
    CommonModule,
    CustomerRoutes,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class CustomerModule { }
