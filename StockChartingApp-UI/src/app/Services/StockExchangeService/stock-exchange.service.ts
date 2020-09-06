import { Stockprice } from './../../Models/StockExchangeService/stockprice';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Stockexchange } from '../../Models/StockExchangeService/stockexchange';

@Injectable({
  providedIn: 'root'
})
export class StockExchangeService {

  path : string = "https://localhost:44329/stockexchangeservice";
  constructor(private http: HttpClient) { }

  AddNewStockExchange(item: Stockexchange):Observable<any>
  {
    return this.http.post<Stockexchange>(this.path, item);
  }
  GetAllStockExchange():Observable<Stockexchange[]>
  {
    return this.http.get<Stockexchange[]>(this.path);
  }


  GetAllStockPrice():Observable<Stockprice[]>
  {
    return this.http.get<Stockprice[]>(this.path+"/getstockprices");
  }
}
