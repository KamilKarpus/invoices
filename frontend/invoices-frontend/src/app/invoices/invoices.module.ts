import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoicesListComponent } from './invoices-list/invoices-list.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoicesRoutes } from './invoices.routing';
import { MaterialModule } from '../material/material-module';
import { InvoicesService } from './services/invoices.service';
import { HttpClientModule } from '@angular/common/http';



@NgModule({
  declarations: [InvoicesListComponent, InvoiceComponent],
  imports: [
    CommonModule,
    InvoicesRoutes,
    MaterialModule,
    HttpClientModule
  ],
  bootstrap: [InvoiceComponent],
  providers : [InvoicesService]
})
export class InvoicesModule { }
