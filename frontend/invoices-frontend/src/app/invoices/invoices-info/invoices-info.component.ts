import { Component, OnInit } from '@angular/core';
import { InvoicesService } from '../services/invoices.service';
import { ActivatedRoute } from '@angular/router';
import { InvoicesInfoView } from '../models/invoices-view';
import { CustomerInfoView } from '../models/customer/customer-info-view';
import { CustomerService } from '../services/customer.service';
import { SellerService } from '../services/seller.service';
import { SellerShortView } from '../models/seller/sellershortview';

@Component({
  selector: 'app-invoices-info',
  templateUrl: './invoices-info.component.html',
  styleUrls: ['./invoices-info.component.css']
})
export class InvoicesInfoComponent implements OnInit {

  private sub;
  public InvoiceView : InvoicesInfoView;
  public customerInfo : CustomerInfoView;
  public sellerInfo : SellerShortView;
  public displayedColumns: string[] = ['product', 'quantity','net', 'gross'];
  constructor(private invoiceService : InvoicesService, private route : ActivatedRoute,
      private customerService : CustomerService, private sellerService : SellerService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.invoiceService.getInvoice(params.id).subscribe(data=>{
        this.InvoiceView = data;
        this.getCustomerInfo(data.customerid);
        this.getSellerInfo(data.sellerid);
    
      });
    });
  }

  getSellerInfo(id){
    this.sellerService.getSellerbyId(id).subscribe(data=>{
      this.sellerInfo = data;
    });
  }
  getCustomerInfo(id){
    this.customerService.getCustomerInfobyId(id)
        .subscribe(data=>{
          this.customerInfo = data;
        })
  }
} 
