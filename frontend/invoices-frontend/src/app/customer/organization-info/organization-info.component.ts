import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Organization } from '../model/organization';
import { OrganizationService } from '../service/organization.service';

@Component({
  selector: 'app-organization-info',
  templateUrl: './organization-info.component.html',
  styleUrls: ['./organization-info.component.css']
})
export class OrganizationInfoComponent implements OnInit, OnDestroy {
  organization : Organization;
  sub : any;
  panelOpenState : boolean;
  constructor(private route: ActivatedRoute, private service : OrganizationService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.getOrganization(params.id);
   });
  }

  getOrganization(id: string){
    this.service.getOrganizationbyId(id)
    .subscribe(data=>{
      this.organization = data;
    });
  }

  ngOnDestroy(){
    this.sub.unsubscribe();
  }

}
