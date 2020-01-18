import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoicesListComponent } from './invoices-list/invoices-list.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoicesRoutes } from './invoices.routing';
import { MaterialModule } from '../material/material-module';



@NgModule({
  declarations: [InvoicesListComponent, InvoiceComponent],
  imports: [
    CommonModule,
    InvoicesRoutes,
    MaterialModule
  ],
  bootstrap: [InvoiceComponent]
})
export class InvoicesModule { }
