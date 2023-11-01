import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/products.model';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
 products: Product[]=[];
 constructor(private ProductService: ProductService){}
 ngOnInit(): void {
     this.ProductService.getAllProducts().subscribe({
      next: (products) => {
        this.products = products;
      },
      error: (response) => {
        console.log(response);
      }
     })
 }
}
