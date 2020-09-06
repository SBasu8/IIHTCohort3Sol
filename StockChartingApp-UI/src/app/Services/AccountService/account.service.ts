import { Role } from './../../Models/AuthService/role';
import { HttpClient } from '@angular/common/http';
import { TokenDetails } from './../../Models/AuthService/token-details';
import { InputDetails } from './../../Models/AuthService/input-details';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  path: string = "https://localhost:44329";
  constructor(private http: HttpClient) { }

  AdminLogin(inputDetails): Observable<TokenDetails> 
  {
    return this.http.post<TokenDetails>(this.path+"/authservice/adminlogin",inputDetails);
  }

  UserLogin(inputDetails): Observable<TokenDetails> 
  {
    return this.http.post<TokenDetails>(this.path+"/authservice/userlogin",inputDetails);
  }

  Signup(item: Role): Observable<Role>
  {
    return this.http.post<Role>(this.path+"/authservice/signup",item);
  }
  
}
