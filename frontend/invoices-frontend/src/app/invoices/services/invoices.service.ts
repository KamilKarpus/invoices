import { Injectable, HostListener } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedList } from '../models/PagedList';
import { environment } from 'src/environments/environment';
import { InvoiceAdd } from '../models/invoices-add';
import { InvoicesInfoView } from '../models/invoices-view';
import { ProductPagedList } from '../models/product/productpagedlist';
import { ProductDTO } from '../models/product/product-add-model';
import { ProductUpdate } from '../models/product/product-update-model';



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
    public getInvoice(id : string) : Observable<InvoicesInfoView>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}`;
        return this.http.get<InvoicesInfoView>(url);
    }
    public getProductbyInvoiceId(id : string, pageSize, pageNumber) : Observable<ProductPagedList>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}/products`;
        return this.http.get<ProductPagedList>(url, { params: 
            {
                PageSize: pageSize,
                CurrentPage: pageNumber,
            } 
        });
    }
    public addProduct(product: ProductDTO) : Observable<any>{
        var url = `${environment.apiUrl}${this.baseUrl}/product`;
        return this.http.post<any>(url, product);
    }

    public updateProduct(id, product : ProductUpdate) : Observable<any>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}/products`;
        return this.http.put<any>(url, product);
    }

    public deleteProduct(id, productId) : Observable<any>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}/products/${productId}`;
        return this.http.delete<any>(url);
    }
    public issueInvoice(id) : Observable<any>{
        var url = `${environment.apiUrl}${this.baseUrl}/${id}/issue`;
        return this.http.put<any>(url,null);
    }
  
}