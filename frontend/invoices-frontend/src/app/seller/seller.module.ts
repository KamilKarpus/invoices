import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home/home.component';
import { SellerRoutes } from './seller.routing';
import { SellerComponent } from './seller/seller.component';
import { MaterialModule } from '../material/material-module';
import { MenuComponent } from './menu/menu.component';
import { SellersListComponent } from './sellers-list/sellers-list.component';
import { HttpClientModule } from '@angular/common/http';
import { SellerService } from './services/seller-service';
import { SellerinfoComponent } from './sellerinfo/sellerinfo.component';

@NgModule({
  declarations:  [
    HomeComponent, 
    SellerComponent, 
    MenuComponent, 
    SellersListComponent, SellerinfoComponent
  ],
  imports: [
    CommonModule,
    SellerRoutes,
    MaterialModule,
    HttpClientModule
  ],
  providers : [SellerService],
  bootstrap: [SellerComponent]
})
export class SellerModule { }
