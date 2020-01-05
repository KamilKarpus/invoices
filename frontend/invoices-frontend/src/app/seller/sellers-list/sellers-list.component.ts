import { Component, OnInit } from '@angular/core';
import { SellerService } from '../services/seller-service';
import { SellerShortInfo } from '../model/SellerShortInfo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sellers-list',
  templateUrl: './sellers-list.component.html',
  styleUrls: ['./sellers-list.component.css']
})
export class SellersListComponent implements OnInit {
  sellers : SellerShortInfo[];
  constructor(private sellerService : SellerService, private router : Router) { }

  displayedColumns: string[] = ['companyName', 'nip'];

  ngOnInit() {
  this.sellerService.getAllSellers()
      .subscribe(data=>{
        this.sellers = data;
      });
  }
  goToSeller(row){
    console.log(row.id);
    this.router.navigate(["/seller", row.id]);
  }

}
