import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CompanyNameSeller } from '../models/seller/sellerCompanyName';
import { environment } from 'src/environments/environment';
import { SellerShortView } from '../models/seller/sellershortview';


@Injectable({
    providedIn: 'root'
  })
export class SellerService{
    private baseUrl = "/seller";

    constructor(private http:HttpClient) {
    }

    public getSellerbyCompanyName(name) : Observable<CompanyNameSeller[]>{
        var url = environment.apiUrl + this.baseUrl + '/name';
        return this.http.get<CompanyNameSeller[]>(url,{
                params: {
                companyName: name
            }
        });
    }
    public getSellerbyId(id) : Observable<SellerShortView>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}/register`;
        console.log(url);
        return this.http.get<SellerShortView>(url);
    }

}