import { Component, OnInit, Input } from '@angular/core';
import { Organization } from '../model/organization';
import { OrganizationService } from '../service/organization.service';
import { Customer } from '../model/customer';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  @Input() OrganizationId: string;
  customers = new Array<Customer>();
  displayedColumns: string[] = ['name', 'surname'];
  constructor(private service: OrganizationService) { }
  
  ngOnInit() {
    this.service.getCustomerByOrganizationId(this.OrganizationId)
      .subscribe(data=> {
        this.customers = data;
      })
  }

}
