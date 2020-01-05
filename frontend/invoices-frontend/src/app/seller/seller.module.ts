import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SellerRoutes } from './seller.routing';
import { SellerComponent } from './seller/seller.component';



@NgModule({
  declarations: [HomeComponent, SellerComponent],
  imports: [
    CommonModule,
    SellerRoutes
  ],
  bootstrap: [SellerComponent]
})
export class SellerModule { }
