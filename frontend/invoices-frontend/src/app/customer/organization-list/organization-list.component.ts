import { Component, OnInit } from '@angular/core';
import { OrganizationListView } from '../model/organizationlistview';
import { Router } from '@angular/router';
import { OrganizationService } from '../service/organization.service';

@Component({
  selector: 'app-organization-list',
  templateUrl: './organization-list.component.html',
  styleUrls: ['./organization-list.component.css']
})
export class OrganizationListComponent implements OnInit {
  public organizations : OrganizationListView[];
  displayedColumns: string[] = ['name', 'nip', 'adress'];
  constructor(public service : OrganizationService, private router : Router) { }

  ngOnInit() {
    this.service.getOrganizations()
      .subscribe(data=>{
        this.organizations = data;
      })
  }
    goToOrganization(row){
    this.router.navigate(["/organization", row.id]);
  }
}
