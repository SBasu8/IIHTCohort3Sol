import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from "../../Models/CompanyService/company";
import { Stockexchangedto } from "../../Models/CompanyService/stockexchangedto";
import { HttpClient } from "@angular/common/http";
import { Sectordto } from 'src/app/Models/CompanyService/sectordto';
import { Ipodto } from 'src/app/Models/CompanyService/ipodto';
import { Stockpricerequestdto } from "src/app/Models/CompanyService/stockpricerequestdto";
import { Stockpricedto } from "src/app/Models/CompanyService/stockpricedto";

@Injectable({
  providedIn: 'root'
})
export class CompanyService 
{
  base_url:string = "https://apigatewaysca.azurewebsites.net";

  constructor(private client:HttpClient) 
  {

  }

  public GetAllCompanies():Observable<Company[]>
  {
    return this.client.get<Company[]>(this.base_url+"/companyservice/getallcompanies");
  }

  public GetAllIPOs():Observable<Ipodto[]>
  {
    return this.client.get<Ipodto[]>(this.base_url+"/companyservice/getallipos");
  }

  public AddNewCompany(comp:Company):Observable<Company>
  {
    return this.client.post<Company>(this.base_url+"/companyservice/addnewcompany",comp);
  }

  public AddCompanyIPO(ipo:Ipodto):Observable<any>
  {
    return this.client.post<Ipodto>(this.base_url+"/companyservice/addcompanyipo",ipo);
  }

  public UpdateCompany(comp:Company):Observable<any>
  {
    return this.client.put<Company>(this.base_url+"/companyservice/updatecompany/"+comp.id,comp);
  }

  public DeleteCompany(comp_id:number):Observable<any>
  {
    return this.client.delete(this.base_url+"/companyservice/removecompany/"+comp_id, {responseType: 'text'});
  }

  public GetStockPrices(stock_price_req:Stockpricerequestdto):Observable<Stockpricedto[]>
  {
    return this.client.post<Stockpricedto[]>(this.base_url+"/companyservice/companystockprices",stock_price_req);
  }
}
