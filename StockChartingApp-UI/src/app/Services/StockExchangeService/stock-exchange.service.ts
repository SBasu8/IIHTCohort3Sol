import { Stockprice } from './../../Models/StockExchangeService/stockprice';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Stockexchange } from '../../Models/StockExchangeService/stockexchange';

@Injectable({
  providedIn: 'root'
})
export class StockExchangeService {

  path:string = "https://apigatewaysca.azurewebsites.net";
  constructor(private http: HttpClient) { }

  AddNewStockExchange(item: Stockexchange):Observable<any>
  {
    return this.http.post<Stockexchange>(this.path+"/stockexchangeservice", item);
  }
  GetAllStockExchange():Observable<Stockexchange[]>
  {
    return this.http.get<Stockexchange[]>(this.path+"/stockexchangeservice/getallstockexchanges");
  }


  GetAllStockPrice():Observable<Stockprice[]>
  {
    return this.http.get<Stockprice[]>(this.path+"/stockexchangeservice/getstockprices");
  }

  DeleteJoinCompanyStockExchange(c_id: number, se_id: string):Observable<any>
  {
    return this.http.delete(this.path+"/stockexchangeservice/delete_C_SE/"+c_id+"/"+se_id);
  }
}
