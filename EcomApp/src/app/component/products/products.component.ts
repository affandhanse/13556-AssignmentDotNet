import { Component, OnInit } from '@angular/core';
import { Products } from '../../models/products';
import { ProductsService } from '../../services/products.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { UserService } from '../../services/user.service';


@Component({
  selector: 'app-products',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  products: Products[] = [];
  constructor(private ProductsService: ProductsService,private router:Router,private userService:UserService) { }
  ngOnInit(): void {
    this.getProducts();
  }
  
  getProducts():void {
    this.ProductsService.getAllProducts().subscribe((res) => {
      console.log(res);
      this.products = res;
    });
  }
  
  goToCart() {
    this.router.navigate(['cartitem']); 
  }

  addItemToCart(productId: number, quantity: number): void {

    if (!this.userService.isLoggedIn()) {
     
      this.router.navigate(['/login']);
    } else {
      
     
      const payload = {userId: "default", productId, quantity };
      this.ProductsService.addToCart(payload).subscribe(() => {
        alert('Product added to cart');
        
        this.getProducts();
      });
    }
  }
}