import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SellerShortInfo } from '../model/SellerShortInfo';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

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
}
