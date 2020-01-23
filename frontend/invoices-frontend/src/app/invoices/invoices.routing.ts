import { InvoiceComponent } from './invoice/invoice.component';
import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';
import { InvoicesListComponent } from './invoices-list/invoices-list.component';
import { AddInvoiceComponent } from './add-invoice/add-invoice.component';
import { InvoicesInfoComponent } from './invoices-info/invoices-info.component';

const routes : Routes = [
    {
        path: '',
        component : InvoiceComponent,
        children:
        [
            {
                path: 'list',
                component: InvoicesListComponent 
            },
            {
                path: 'add',
                component: AddInvoiceComponent
            },
            {
                path: ':id',
                component: InvoicesInfoComponent
            }
        ]
    }
];

export const InvoicesRoutes: ModuleWithProviders = RouterModule.forChild(routes);