import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product } from '../models/product/product-model';
import { FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-product-add-dialog',
  templateUrl: './product-add-dialog.component.html',
  styleUrls: ['./product-add-dialog.component.css']
})
export class ProductAddDialogComponent implements OnInit {
  
  public productForm = new FormGroup(
    {
      name : new FormControl('',Validators.required),
      price : new FormControl('', Validators.required),
      quantity: new FormControl('',Validators.required)
    }
    )
  ngOnInit(): void {
  }

  constructor(public dialogRef: MatDialogRef<ProductAddDialogComponent>) {}


  onYesClick() : void{
  if(!this.productForm.invalid){
   var name = this.productForm.get('name').value;
   var price = this.productForm.get('price').value;
   var quantity = this.productForm.get('quantity').value;
   var productData = new Product(name,price,quantity);
   this.dialogRef.close({productData});
  }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
