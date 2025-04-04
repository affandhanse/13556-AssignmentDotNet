import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Products } from '../models/products';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private productUrl = 'https://localhost:7119/api/Products';
  private apiUrl = 'https://localhost:7119/api/CartItem';
  constructor(private http:HttpClient) { }
  getAllProducts():Observable<Products[]> {
    return this.http.get<Products[]>(`${this.productUrl}`);
  }
  addToCart(payload: any): Observable<any> {
    const token = localStorage.getItem('token');     
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json' // Optional, but good practice to specify
    });

    return this.http.post(this.apiUrl, payload, { headers });
  }

}
