import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CustomerShortView } from '../models/customer/customerShortView';
import { CustomerService } from '../services/customer.service';
import { SellerService } from '../services/seller.service';
import { CompanyNameSeller } from '../models/seller/sellerCompanyName';
import { InvoiceAdd } from '../models/invoices-add';
import { InvoicesService } from '../services/invoices.service';

@Component({
  selector: 'app-add-invoice',
  templateUrl: './add-invoice.component.html',
  styleUrls: ['./add-invoice.component.css']
})
export class AddInvoiceComponent implements OnInit {
  myControl = new FormControl();
  customerOptions: CustomerShortView[];
  sellerOptions: CompanyNameSeller[];
  pickedSeller: CompanyNameSeller;
  pickedCustomer : CustomerShortView;

  formGroup = new FormGroup({
    customer: new FormControl('',[Validators.required]),
    seller: new FormControl('',[Validators.required]),
  });

  constructor(private customerService : CustomerService, private sellerService : SellerService,
    private invoicesService : InvoicesService) { }

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
  setSeller(seller : CompanyNameSeller){
    this.pickedSeller = seller;
    console.log(seller);
  }

  setCustomer(customer: CustomerShortView){
    this.pickedCustomer = customer;
    console.log(customer);
  }
  submit(){
    if(this.formGroup.invalid != true)
    {
      var invoice = new InvoiceAdd(this.pickedCustomer.id,this.pickedSeller.id,
        "PLN",23);
        console.log(invoice);
        this.invoicesService.addInvoices(invoice).subscribe(data => console.log(data));
    }
  }
}
