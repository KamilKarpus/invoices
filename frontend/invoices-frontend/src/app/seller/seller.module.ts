import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SellerRoutes } from './seller.routing';
import { SellerComponent } from './seller/seller.component';
import { MaterialModule } from '../material/material-module';
import { MenuComponent } from './menu/menu.component';
import { SellersListComponent } from './sellers-list/sellers-list.component';
import { HttpClientModule } from '@angular/common/http';
import { SellerService } from './services/seller-service';
import { SellerinfoComponent } from './sellerinfo/sellerinfo.component';
import { AddsellerComponent } from './addseller/addseller.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { SharedModule } from '../customInputs/sharedDirectives';

@NgModule({
  declarations:  [
    SellerComponent, 
    MenuComponent, 
    SellersListComponent, 
    SellerinfoComponent, 
    AddsellerComponent
  ],
  imports: [
    CommonModule,
    SellerRoutes,
    MaterialModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ],
  providers : [SellerService],
  bootstrap: [SellerComponent]
})
export class SellerModule { }
