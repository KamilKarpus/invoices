import {RouterModule, Routes} from '@angular/router';
import {ModuleWithProviders} from '@angular/core';
import { SellerComponent } from './seller/seller.component';
import { SellersListComponent } from './sellers-list/sellers-list.component';
import { SellerinfoComponent } from './sellerinfo/sellerinfo.component';
import { AddsellerComponent } from './addseller/addseller.component';

const routes: Routes = [
    {
        path: '',
        component: SellerComponent,
        children:
        [
        {
            path: 'list',
            component : SellersListComponent
        },
        {
            path: 'add',
            component: AddsellerComponent
        },
        {
            path: ':id',
            component : SellerinfoComponent
        }
        ]
    }
];

export const SellerRoutes: ModuleWithProviders = RouterModule.forChild(routes);