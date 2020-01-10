import { ModuleWithProviders, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { OrganizationListComponent } from './organization-list/organization-list.component';
import { OrganizationInfoComponent } from './organization-info/organization-info.component';
import { OrganizationAddComponent } from './client-add/organization-add.component';
import { AddCustomerComponent } from './add-customer/add-customer.component';
const routes : Routes = [
    {
        path: '',
        component : CustomerComponent,
        children:
        [
            {
                path: 'add',
                component: OrganizationAddComponent
            },
            {
                path: 'list',
                component: OrganizationListComponent
            },
            {
                path: ':id',
                component: OrganizationInfoComponent
            },
            {
                path: ':id/add',
                component : AddCustomerComponent
            }
        ]
    }
];

export const CustomerRoutes: ModuleWithProviders = RouterModule.forChild(routes);