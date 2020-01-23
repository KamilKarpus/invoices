import { Component, OnInit } from '@angular/core';
import { InvoicesService } from '../services/invoices.service';
import { PagedList } from '../models/PagedList';
import { Router } from '@angular/router';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent implements OnInit {

  length = 0;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  displayedColumns: string[] = ['creationDate', 'leftToPay', 'status', 'name', 'surname'];
  list : PagedList;
  constructor(private service : InvoicesService, private router: Router  ) { }

  ngOnInit() {
    this.service.getInvoices(10,1)
    .subscribe(data=>{this.list = data;
      this.length = data.totalItems;});
  }
  pageChanged(pageEvent){
    var pageIndex =pageEvent.pageIndex+1;
    var pageSize =pageEvent.pageSize;
    this.service.getInvoices(pageSize,pageIndex)
    .subscribe(data=>{this.list = data,
      this.length = data.totalItems});
  }

  goToInvoice(row){
    this.router.navigate(["/invoices", row.id]);
  }
}
