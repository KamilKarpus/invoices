import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent implements OnInit {

  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  constructor() { }

  ngOnInit() {
  }
  pageChanged(pageEvent){
    console.log(JSON.stringify(pageEvent));
  }
}
