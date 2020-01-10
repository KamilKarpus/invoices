import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { OrganizationService } from '../service/organization.service';
import { AddOrganization } from '../model/addorganization';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-organization-add',
  templateUrl: './organization-add.component.html',
  styleUrls: ['./organization-add.component.css']
})
export class OrganizationAddComponent implements OnInit {

  public customerForm : FormGroup;
  constructor(private fb: FormBuilder, private service : OrganizationService,private router : Router, 
    private toastr: ToastrService) {
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
      var customer = new AddOrganization(name,adress,city,postalCode, nip);
      this.service.addOrganization(customer).subscribe(
        data=>{
          this.toastr.success('Udało się dodać nowego klienta!', 'Sukces');
          this.router.navigate(["/customer", data.id]);
        }
      );

      
    }
  }

}
