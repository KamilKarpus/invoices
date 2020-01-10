import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerComponent } from './customer/customer.component';
import { CustomerRoutes } from './customer.routing';
import { MaterialModule } from '../material/material-module';
import { MenuComponent } from './menu/menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { CustomerInfoComponent } from './customer-info/customer-info.component';
import { OrganizationInfoComponent } from './organization-info/organization-info.component';
import { OrganizationService } from './service/organization.service';
import { OrganizationAddComponent } from './client-add/organization-add.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';



@NgModule({
  declarations: [CustomerComponent, MenuComponent, OrganizationAddComponent, CustomerListComponent, OrganizationListComponent, CustomerInfoComponent, OrganizationInfoComponent, AddCustomerComponent],
  imports: [
    CommonModule,
    CustomerRoutes,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers : [OrganizationService]
})
export class CustomerModule { }
