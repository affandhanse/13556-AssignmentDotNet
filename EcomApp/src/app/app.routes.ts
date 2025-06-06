import { Routes } from '@angular/router';
import { LoginComponent } from './component/login/login.component';
import { RegisterComponent } from './component/register/register.component';
import { ProductsComponent } from './component/products/products.component';
import { CartComponent } from './component/cart/cart.component';
import { HomeComponent } from './component/home/home.component';

export const routes: Routes = [
    { path: '', component: HomeComponent },
    {path:'login', component:LoginComponent},
    {path:'register', component:RegisterComponent},
    {path:'products',component:ProductsComponent},
    {path:'cartitem', component:CartComponent}
];
