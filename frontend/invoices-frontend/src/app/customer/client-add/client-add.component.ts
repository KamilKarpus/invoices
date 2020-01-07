import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { CustomerRoutes } from '../customer.routing';
import { AddCustomer } from '../model/addcustomer';

@Component({
  selector: 'app-client-add',
  templateUrl: './client-add.component.html',
  styleUrls: ['./client-add.component.css']
})
export class ClientAddComponent implements OnInit {

  public customerForm : FormGroup;
  constructor(private fb: FormBuilder) {
    this. customerForm = this.fb.group({
      nameControl: new FormControl('',[Validators.required]),
      nipControl : new FormControl('',[Validators.required,Validators.minLength(10), Validators.maxLength(10)]),
      adressControl : new FormControl('', [Validators.required]),
      cityControl : new FormControl('',[Validators.required]),
      postalCodeControl : new FormControl('',[Validators.required])
    });
   }
  ngOnInit() {
  }

  public addCustomer(){
    if(this.customerForm.invalid != true)
    {
      var name =  this.customerForm.get("nameControl").value;
      var adress = this.customerForm.get("adressControl").value;
      var postalCode = this.customerForm.get("postalCodeControl").value;
      var nip = this.customerForm.get("nipControl").value;
      var city = this.customerForm.get("cityControl").value;
      var customer = new AddCustomer(name,adress,city,postalCode, nip);
      console.log(customer);
    }
  }

}
