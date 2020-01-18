import { Component, OnInit } from '@angular/core';
import { InvoicesService } from '../services/invoices.service';
import { PagedList } from '../models/PagedList';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent implements OnInit {

  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  private list : PagedList;
  constructor(private service : InvoicesService ) { }

  ngOnInit() {
    this.service.getInvoices(10,1)
    .subscribe(data=>{this.list = data});
  }
  pageChanged(pageEvent){
    console.log(JSON.stringify(pageEvent));
    var pageIndex =pageEvent.pageIndex+1;
    var pageSize =pageEvent.pageSize;
    this.service.getInvoices(pageSize,pageIndex)
    .subscribe(data=>{this.list = data});
  }
}
