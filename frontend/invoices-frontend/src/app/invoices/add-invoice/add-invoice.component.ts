import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { CustomerShortView } from '../models/customer/customerShortView';
import { CustomerService } from '../services/customer.service';
import { SellerService } from '../services/seller.service';
import { CompanyNameSeller } from '../models/seller/sellerCompanyName';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  myControl = new FormControl();
  customerOptions: CustomerShortView[];
  sellerOptions: CompanyNameSeller[];
  constructor(private customerService : CustomerService, private sellerService : SellerService) { }

  ngOnInit() {
  }
  
  onKey(value : string) { 
    this.customerService.getCustomerbyName(value)
    .subscribe(data => {
      this.customerOptions = data;
    })
  }
  onKeySeller(value : string){
    this.sellerService.getSellerbyCompanyName(value)
    .subscribe(data=>{
      this.sellerOptions = data;
    })
  }

}
