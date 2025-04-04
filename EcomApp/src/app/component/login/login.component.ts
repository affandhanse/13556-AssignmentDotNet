import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AuthResponseModel, Login } from '../../models/login';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule, HttpClientModule,RouterModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginModel: Login = new Login('', '');
  errorMsg='';
  


  constructor(private userService: UserService,private router:Router) {}
  loginUser(loginForm: NgForm) {
    this.loginModel = loginForm.value;
    console.log(this.loginModel);
    this.userService.login(this.loginModel).subscribe({
      next: (response: AuthResponseModel) => {
        console.log('Login Success', response);
        localStorage.setItem('token', response.token);
        localStorage.setItem('userId', response.userId);
        alert('Login Success');
        
        loginForm.reset();

        this.router.navigate(['products']);

      },
      error: (error) => {
        console.error('Login Failed', error);
        this.errorMsg= JSON.stringify(error.error.message);
        alert("Invalid Credentials"+this.errorMsg);
      },
    });
  }
}