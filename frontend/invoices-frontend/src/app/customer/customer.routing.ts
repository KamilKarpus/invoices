import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { ClientAddComponent } from './client-add/client-add.component';
const routes : Routes = [
    {
        path: '',
        component : CustomerComponent,
        children:
        [
            {
                path: 'add',
                component: ClientAddComponent
            }
        ]
    }
];

export const CustomerRoutes: ModuleWithProviders = RouterModule.forChild(routes);