import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SellerShortInfo } from '../model/SellerShortInfo';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Seller } from '../model/seller';
import { AddSeller } from '../model/addSeller';

@Injectable({
  providedIn: 'root'
})
export class SellerService {
  private baseUrl = "/seller";

  constructor(private http:HttpClient) {
  }

  public getAllSellers() : Observable<SellerShortInfo[]> {
    var url = environment.apiUrl + this.baseUrl;
    return this.http.get<SellerShortInfo[]>(url);
  }
  public getSellerbyId(id) : Observable<Seller>{
    var url = environment.apiUrl + this.baseUrl + '/'+id
    return this.http.get<Seller>(url);
  }
  public addSeller(seller : AddSeller) : Observable<any>{
    var url = environment.apiUrl + this.baseUrl;
    return this.http.post(url,seller);
  }
}
