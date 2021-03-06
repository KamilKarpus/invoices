import { NgModule, LOCALE_ID } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InvoicesListComponent } from './invoices-list/invoices-list.component';
import { InvoiceComponent } from './invoice/invoice.component';
import { InvoicesRoutes } from './invoices.routing';
import { MaterialModule } from '../material/material-module';
import { InvoicesService } from './services/invoices.service';
import { HttpClientModule } from '@angular/common/http';
import { AddInvoiceComponent } from './add-invoice/add-invoice.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CustomerService } from './services/customer.service';
import { SellerService } from './services/seller.service';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { MenuComponent } from './menu/menu.component';
import { InvoicesInfoComponent } from './invoices-info/invoices-info.component';
import { ProductAddDialogComponent } from './product-add-dialog/product-add-dialog.component';
import { ConfirmationDialogComponent } from './confirmation-dialog/confirmation-dialog.component';



@NgModule({
  declarations: [InvoicesListComponent, InvoiceComponent, AddInvoiceComponent, MenuComponent, InvoicesInfoComponent, ProductAddDialogComponent, ConfirmationDialogComponent],
  imports: [
    CommonModule,
    InvoicesRoutes,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule
  ],
  entryComponents:[
                    ProductAddDialogComponent,
                    ConfirmationDialogComponent 
                  ],
  bootstrap: [InvoiceComponent],
  providers : [InvoicesService, 
              CustomerService,
              SellerService,
              {provide: MAT_DATE_LOCALE, useValue: 'pl-PL'}
            ]
})
export class InvoicesModule { }
