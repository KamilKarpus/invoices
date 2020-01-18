import { InvoiceComponent } from './invoice/invoice.component';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { InvoicesListComponent } from './invoices-list/invoices-list.component';

const routes : Routes = [
    {
        path: '',
        component : InvoiceComponent,
        children:
        [
            {
                path: 'list',
                component: InvoicesListComponent 
            }
            
        ]
    }
];

export const InvoicesRoutes: ModuleWithProviders = RouterModule.forChild(routes);