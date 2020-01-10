import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { OrganizationListView } from '../model/organizationlistview';
import { Organization } from '../model/organization';
import { AddOrganization } from '../model/addorganization';
import { Customer } from '../model/customer';
import { AddCustomer } from '../model/addcustomer';
@Injectable({
  providedIn: 'root'
})
export class OrganizationService {
  private baseUrl = "/organization";
  constructor(private http: HttpClient) {
  }
  public addOrganization(seller: AddOrganization): Observable<any> {
    var url = environment.apiUrl + this.baseUrl;
    return this.http.post(url, seller);
  }
  public getOrganizations(): Observable<OrganizationListView[]> {
    var url = environment.apiUrl + this.baseUrl;
    return this.http.get<OrganizationListView[]>(url);
  }
  public getOrganizationbyId(id: string): Observable<Organization> {
    var url = environment.apiUrl + this.baseUrl + '/' + id;
    return this.http.get<Organization>(url);
  }
  public getCustomerByOrganizationId(id : string) : Observable<Customer[]>{
    var url = `${environment.apiUrl}${this.baseUrl}/${id}/customers`;
    return this.http.get<Customer[]>(url);
  }
  public addCustomerToOrgranizartion(customer : AddCustomer) : Observable<any>{
    var url = `${environment.apiUrl}/customer`;
    return this.http.post(url,customer);
  }
}
