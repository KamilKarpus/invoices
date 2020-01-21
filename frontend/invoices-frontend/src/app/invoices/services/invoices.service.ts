import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedList } from '../models/PagedList';
import { environment } from 'src/environments/environment';
import { InvoiceAdd } from '../models/invoices-add';



@Injectable({
    providedIn: 'root'
  })
export class InvoicesService{
    private baseUrl = "/invoices";

    constructor(private http:HttpClient) {
    }
    public getInvoices(pageSize, currentPage) : Observable<PagedList>{
        var url = environment.apiUrl + this.baseUrl;
        return this.http.get<PagedList>(url,{params : {
            PageSize : pageSize,
            CurrentPage: currentPage
        }});
    }
    public addInvoices(invoices : InvoiceAdd) : Observable<any>{
        var url = environment.apiUrl + this.baseUrl;
        return this.http.post<any>(url, invoices);
    }
  
}