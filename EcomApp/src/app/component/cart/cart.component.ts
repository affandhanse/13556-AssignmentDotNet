import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [CommonModule,RouterModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css'
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];
  totalPrice:number = 0;
  constructor(private cartService: CartService,private http: HttpClient, private router:Router) {}
  ngOnInit(): void {
    this.loadCartItems();
  }
  loadCartItems() {
    this.cartService.getCartItems().subscribe((items: any[]) => {
      this.cartItems = items;
      this.calculateTotalPrice();
    });
  }
  calculateTotalPrice(): void {
    this.totalPrice = this.cartItems.reduce((total, item) => {
        const itemPrice = Number(item.product.price); 
        const itemQuantity = Number(item.quantity); 
        
        if (isNaN(itemPrice) || isNaN(itemQuantity)) {
            console.error('Invalid values:', itemPrice, itemQuantity);
            return total; 
        }

        return total + (itemPrice * itemQuantity); 
    }, 0);
}

  // addToCart(productId: number, quantity: number = 1) {
  //   this.cartService.addToCart(productId, quantity).subscribe({
  //     next: (cartItem) => {
  //       console.log('Added to cart:', cartItem);
  //       // Show success message
  //     },
  //     error: (err) => {
  //       console.error('Failed to add to cart:', err);
  //       // Handle error
  //     }
  //   });
  // }
  removeFromCart(cartItemId: number): void {
    this.cartService.removeFromCart(cartItemId).subscribe({
      next: () => {
        alert('Item removed from cart successfully!');
        this.loadCartItems(); // Refresh the cart items
      },
      error: (err) => {
        console.error('Error removing item:', err);
        alert('Failed to remove item from cart');
      }
    });
  }
  gotoProducts() {
    this.router.navigate(['products']); 

  }

}
