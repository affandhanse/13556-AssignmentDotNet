import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {
  
  isLoggedIn:boolean=false;
  email:string|null='';

  constructor( public userService:UserService,private router: Router) {}
  ngOnInit(): void {
   
  }
  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }
  gotocart() {
    this.router.navigate(['/cartitem']);
  }
}
