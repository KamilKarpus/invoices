import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerShortView } from '../models/customer/customerShortView';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class CustomerService{
    private baseUrl = "/customer";

    constructor(private http:HttpClient) {
    }

    public getCustomerbyName(name: string) : Observable<CustomerShortView[]>{
        var url = environment.apiUrl + this.baseUrl;
        return this.http.get<CustomerShortView[]>(url, {params : 
            {
                FullName : name
            }
        });
    }

}