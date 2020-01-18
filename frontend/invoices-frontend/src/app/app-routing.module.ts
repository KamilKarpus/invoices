import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';


const routes: Routes = 
[
{
  path: "home",
  component: HomeComponent
},
{
  path: "seller",
  loadChildren: () => import('./seller/seller.module').then(m =>m.SellerModule)
},
{
  path: "organization",
  loadChildren: () => import('./customer/customer.module').then(m=>m.CustomerModule)
},
{
  path: "invoices",
  loadChildren: ()=> import('./invoices/invoices.module').then(m=>m.InvoicesModule)
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
