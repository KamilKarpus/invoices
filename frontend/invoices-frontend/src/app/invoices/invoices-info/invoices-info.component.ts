import { Component, OnInit, HostListener } from '@angular/core';
import { InvoicesService } from '../services/invoices.service';
import { ActivatedRoute } from '@angular/router';
import { InvoicesInfoView } from '../models/invoices-view';
import { CustomerInfoView } from '../models/customer/customer-info-view';
import { CustomerService } from '../services/customer.service';
import { SellerService } from '../services/seller.service';
import { SellerShortView } from '../models/seller/sellershortview';
import { ProductPagedList } from '../models/product/productpagedlist';
import { MatDialog } from '@angular/material/dialog';
import { ProductAddDialogComponent } from '../product-add-dialog/product-add-dialog.component';
import { ProductAdd } from '../models/product/product-add-model';
import { Product } from '../models/product/product-model';

@Component({
  selector: 'app-invoices-info',
  templateUrl: './invoices-info.component.html',
  styleUrls: ['./invoices-info.component.css']
})
export class InvoicesInfoComponent implements OnInit {

  private sub;
  public InvoiceView : InvoicesInfoView;
  public customerInfo : CustomerInfoView;
  public sellerInfo : SellerShortView;
  public products : ProductPagedList;
  private flag : boolean = true;
  public displayedColumns: string[] = ['product', 'quantity','net', 'gross'];
  constructor(private invoiceService : InvoicesService, private route : ActivatedRoute,
      private customerService : CustomerService, private sellerService : SellerService,
      public dialog: MatDialog) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.invoiceService.getInvoice(params.id).subscribe(data=>{
        this.InvoiceView = data;
        this.getCustomerInfo(data.customerid);
        this.getSellerInfo(data.sellerid);
        this.getProductInfo(data.id);
    
      });
    });
  }

  getSellerInfo(id){
    this.sellerService.getSellerbyId(id).subscribe(data=>{
      this.sellerInfo = data;
    });
  }
  getCustomerInfo(id){
    this.customerService.getCustomerInfobyId(id)
        .subscribe(data=>{
          this.customerInfo = data;
        })
  }
  getProductInfo(id){
    this.invoiceService.getProductbyInvoiceId(id, 10, 1).subscribe(data=>{
      this.products = data;
    });
  }
  pageChanged(pageEvent){
    var pageIndex = pageEvent.pageIndex+1;
    var pageSize = pageEvent.pageSize;
    this.invoiceService.getProductbyInvoiceId(this.products.id, pageSize, pageIndex).subscribe(data=>{
      this.products = data;
    });
  }
  @HostListener('document:keypress', ['$event'])
  handleKeyboardEvent(event: KeyboardEvent) { 
    if(event.key == 'c' && this.flag == true){
      this.flag= false;
      const dialogRef = this.dialog.open(ProductAddDialogComponent);
      dialogRef.afterClosed().subscribe(result => {
        this.openDialogAdd(result);
      });
    }
  }

  openDialogAdd(result){
    this.flag = true;
    if(result != null){
      var productToAdd = new ProductAdd(this.InvoiceView.id, result.productData.name, result.productData.netPrice, result.productData.quantity);
      this.invoiceService.addProduct(productToAdd)
      .subscribe(data=>{
        this.getProductInfo(this.InvoiceView.id);
      })
    }
  }
  openDialog(): void {
    this.flag = false;
    const dialogRef = this.dialog.open(ProductAddDialogComponent);
    
    dialogRef.afterClosed().subscribe(result => {
      this.openDialogAdd(result);
    });
  }
} 
