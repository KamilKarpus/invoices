import { Component, OnInit, Input } from '@angular/core';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { AddSeller } from '../model/addSeller';
import { Seller } from '../model/seller';
import { SellerService } from '../services/seller-service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-addseller',
  templateUrl: './addseller.component.html',
  styleUrls: ['./addseller.component.css']
})
export class AddsellerComponent implements OnInit {
  public sellerForm : FormGroup;
  constructor(private fb: FormBuilder, private service: SellerService,private router : Router, 
    private toastr: ToastrService ) {
    this.sellerForm = this.fb.group({
      companyNameControl: new FormControl('',[Validators.required]),
      numberControl: new FormControl('',[Validators.required,Validators.minLength(26), Validators.maxLength(26)]),
      nipControl: new FormControl('',[Validators.required,Validators.minLength(10), Validators.maxLength(10)]),
      bankName: new FormControl('',[Validators.required, Validators.minLength(1)]),
      cityControl : new FormControl('',[Validators.required]),
      postalCodeControl : new FormControl('', [Validators.required]),
      adressControl : new FormControl('', [Validators.required]),
      switfControl : new FormControl('', [Validators.required])
   });
  }

  ngOnInit() {
  
  }
  public AddSeller(){
    if(this.sellerForm.invalid != true)
    {
    var companyName =  this.sellerForm.get("companyNameControl").value;
    var adress = this.sellerForm.get("adressControl").value;
    var switf = this.sellerForm.get("switfControl").value;
    var bankName = this.sellerForm.get("bankName").value;
    var accountNumber = this.sellerForm.get("numberControl").value;
    var postalCode = this.sellerForm.get("postalCodeControl").value;
    var nip = this.sellerForm.get("nipControl").value;
    var city = this.sellerForm.get("cityControl").value;
    var seller = new AddSeller(companyName,adress,city,postalCode,bankName,accountNumber,
      switf,nip);
    this.service.addSeller(seller).subscribe(data=>{
      this.toastr.success('Udało się dodać nowego sprzedawce!', 'Sukces');
      this.router.navigate(["/seller", data.id]);
    });
    }
  }

}
