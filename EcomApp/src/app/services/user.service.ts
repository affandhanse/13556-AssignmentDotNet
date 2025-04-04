import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { AuthResponseModel, Login } from '../models/login';
import { Register, RegistrationResponse } from '../models/register';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private baseUrl = 'https://localhost:7119/api/Auth';
  constructor(private http:HttpClient) {}

  login(loginData:Login):Observable<AuthResponseModel>{
    return this.http.post<AuthResponseModel>(`${this.baseUrl}/login`,loginData)
  }

  register(registerData: Register): Observable<RegistrationResponse> {
    return this.http.post<RegistrationResponse>(`${this.baseUrl}/register`, registerData);
  }
  isLoggedIn():boolean{
    return !!localStorage.getItem('token');
  }
}