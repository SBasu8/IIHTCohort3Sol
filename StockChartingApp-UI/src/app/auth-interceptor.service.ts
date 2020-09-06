import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor{

  constructor() { }
  interceptor(req: HttpRequest<any>, next: HttpHandler)
  {
    const authToken = localStorage.getItem("token");
    req = req.clone(
      {
        setHeaders:{
          Authorization: "Bearer "+authToken
        }
      })
  }
}
