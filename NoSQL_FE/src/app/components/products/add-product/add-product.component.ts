import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/products.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
 
  constructor(private productService: ProductService, private router: Router) { }
  ngOnInit(): void {
  }

  AddProduct(){
    this.productService.AddProduct().subscribe((res: any) => {
      if(res.status){
        this.router.navigate(['/products']);
      }
    });
  }
}
