import {RouterModule, Routes} from '@angular/router';
import {ModuleWithProviders} from '@angular/core';
import { HomeComponent } from './home/home.component';
import { SellerComponent } from './seller/seller.component';

const routes: Routes = [
    {
        path: '',
        component: SellerComponent,
        children:
        [
        {
            path: 'home',
            component: HomeComponent,
        }
        ]
    }
];

export const SellerRoutes: ModuleWithProviders = RouterModule.forChild(routes);