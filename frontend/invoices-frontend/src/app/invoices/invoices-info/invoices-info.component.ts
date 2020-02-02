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
import { ProductDTO } from '../models/product/product-add-model';
import { Product } from '../models/product/product-model';
import { ProductUpdate } from '../models/product/product-update-model';
import { SelectionModel } from '@angular/cdk/collections';
import { ToastrService } from 'ngx-toastr';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { FileInfo } from '../models/file';
import { environment } from 'src/environments/environment';

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
  public fileInfo : FileInfo;
  public displayedColumns: string[] = ['product', 'quantity','net', 'gross', 'action'];



  constructor(private invoiceService : InvoicesService, private route : ActivatedRoute,
      private customerService : CustomerService, private sellerService : SellerService,
      public dialog: MatDialog, private toastr: ToastrService) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      this.invoiceService.getInvoice(params.id).subscribe(data=>{
        this.InvoiceView = data;
        this.getCustomerInfo(data.customerid);
        this.getSellerInfo(data.sellerid);
        this.getProductInfo(data.id);
        this.getFileInfo(data.id);
    
      });
    });
  }
  getFileInfo(id){
    this.invoiceService.invoiceFileInfo(id).subscribe(p=>{
      this.fileInfo = p;
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
    if(event.key == 'c' && this.flag == true && this.InvoiceView.status == 1){
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
      var productToAdd = new ProductDTO(this.InvoiceView.id, result.productData.name, result.productData.netPrice, result.productData.quantity);
      this.invoiceService.addProduct(productToAdd)
      .subscribe(data=>{
        this.getProductInfo(this.InvoiceView.id);
        this.toastr.success('Udało się dodać nowy produkt do faktury!', 'Sukces');
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
  editDialog(product){
    this.flag = false;
    const dialogRef = this.dialog.open(ProductAddDialogComponent,
      {data : {name: product.name,netPrice : product.netperunit, quantity : product.quantity}
    });
    dialogRef.afterClosed().subscribe(result => {
      this.flag = true;
    if(result != null){
      var productToUpdate = new ProductUpdate(product.productId, result.productData.netPrice, result.productData.quantity,result.productData.name);
      this.invoiceService.updateProduct(this.InvoiceView.id, productToUpdate).subscribe(data=>{
        this.getProductInfo(this.InvoiceView.id);
        this.toastr.success(`Udało się zaktualizować produkt ${productToUpdate.name}!`, 'Sukces');
      });
      }
    });
  }
  deleteProduct(product){
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,
      {data: {title: 'Usuń przedmiot',content: `Czy chcesz usunać przedmiot o nazwie ${product.name}`}});

      dialogRef.afterClosed().subscribe(result => {
        if(result.confirmation === true){
            this.invoiceService.deleteProduct(this.InvoiceView.id, product.productId)
            .subscribe(data=>{
              this.getProductInfo(this.InvoiceView.id);
              this.toastr.success(`Produkt został usunięty ${product.name}!`, 'Sukces');
            });
        }
      });
  }
  openConfirmationDialog(){
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,
      {data: {title: 'Wystaw Fakturę',content: `Czy chcesz wystawić fakture?`}});

      dialogRef.afterClosed().subscribe(result => {
        if(result.confirmation === true){
          this.invoiceService.issueInvoice(this.InvoiceView.id)
            .subscribe(sub=>{
              this.invoiceService.getInvoice(this.InvoiceView.id)
              .subscribe(invoice=>{
                this.InvoiceView = invoice;
              });
              this.toastr.success(`Faktura została wystawiona!`, 'Sukces');
            });
        }
      });
  }
  download(){
    window.open(`${environment.apiUrl}/invoices/${this.InvoiceView.id}/download`, "_blank")
  }

  prepareFile(){
    this.invoiceService.prepareFile(this.InvoiceView.id).subscribe(p=>{
      this.getFileInfo(this.InvoiceView.id);
    })
  }
} 
