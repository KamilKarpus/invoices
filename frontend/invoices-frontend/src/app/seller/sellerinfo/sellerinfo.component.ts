import { Component, OnInit, OnDestroy } from '@angular/core';
import { SellerService } from '../services/seller-service';
import { ActivatedRoute } from '@angular/router';
import { Seller } from '../model/seller';

@Component({
  selector: 'app-sellerinfo',
  templateUrl: './sellerinfo.component.html',
  styleUrls: ['./sellerinfo.component.css']
})
export class SellerinfoComponent implements OnInit, OnDestroy {
  private sub;
  public seller : Seller;
  constructor(private service : SellerService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.service.getSellerbyId(params.id)
      .subscribe(data =>{
        this.seller = data;
      });
   });
  }
  ngOnDestroy(){
    this.sub.unsubscribe();
  }
}


