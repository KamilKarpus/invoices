import {RouterModule, Routes} from '@angular/router';
import {ModuleWithProviders} from '@angular/core';
import { HomeComponent } from './home/home.component';
import { SellerComponent } from './seller/seller.component';
import { SellersListComponent } from './sellers-list/sellers-list.component';
import { SellerinfoComponent } from './sellerinfo/sellerinfo.component';

const routes: Routes = [
    {
        path: '',
        component: SellerComponent,
        children:
        [
        {
            path: 'home',
            component: HomeComponent,
        },
        {
            path: 'list',
            component : SellersListComponent
        },
        {
            path: ':id',
            component : SellerinfoComponent
        }
        ]
    }
];

export const SellerRoutes: ModuleWithProviders = RouterModule.forChild(routes);