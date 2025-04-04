import { Injectable } from '@angular/core';
import { Products } from '../models/products';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private cartUrl = "https://localhost:7119/api/CartItem";
  constructor(private http: HttpClient) { }
  // addToCart(product: Products, quantity: number): Observable<any> {
  //   const cartItem = {
  //     userId: this.userid,
  //     quantity: quantity,
  //     productId: product.id
  //   };
  //   return this.http.post(this.cartUrl, cartItem);
  // }
  getCartItems(): Observable<any[]> {
    const token = localStorage.getItem('token'); 

    
    const urlWithToken = `${this.cartUrl}/${token}`;

    
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<any[]>(urlWithToken, { headers });
  }
  // addToCart(productId: number, quantity: number) {
  //   const cartItem = { productId, quantity };
  //   return this.http.post(`${this.cartUrl}`, cartItem);
  // }
  // getCartItems(): Observable<any[]> {
  //   const token = localStorage.getItem('token');
  //   const header = new HttpHeaders({'Authorization': `Bearer ${token}`});
  //   return this.http.get<any[]>(`${this.cartUrl}?userId=${token}`, { headers: header });
  // }

  removeFromCart(cartItemId: number): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
  
    return this.http.delete(`${this.cartUrl}/${cartItemId}`, { headers });
  }
}