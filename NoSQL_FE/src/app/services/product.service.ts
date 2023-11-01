import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Product } from '../models/products.model';
@Injectable({
  providedIn: 'root'
})
export class ProductService {

  baseApiUrl: string = environment.baseApiUrl; 
  constructor(private http: HttpClient) { }

  getAllProducts(){
    return this.http.get<Product[]>(this.baseApiUrl + '/SanPham');
  }

  AddProduct(){
    return this.http.post(this.baseApiUrl + '/SanPham', null);
  }
}
 