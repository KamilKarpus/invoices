import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { AddCustomer } from '../model/addcustomer';
import { OrganizationService } from '../service/organization.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})
export class AddCustomerComponent implements OnInit {

  private organizationId : string;
  private formGroup = new FormGroup({
      name : new FormControl(),
      surname: new FormControl()
    }
  );

  constructor(private route: ActivatedRoute, private service: OrganizationService, private router: Router) { 
    this.route.params.subscribe(params => {
      this.organizationId = params.id;
   });
  }

  ngOnInit() {
  }

  addCustomer(){
    var name =  this.formGroup.get("name").value;
    var surname = this.formGroup.get("surname").value;
    var customer = new AddCustomer(name, surname, this.organizationId);
    this.service.addCustomerToOrgranizartion(customer).subscribe(data=>{
      this.router.navigate(["/organization", this.organizationId]);
    });
  }
}

