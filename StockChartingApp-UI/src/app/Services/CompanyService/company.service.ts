import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from "../../Models/company";
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CompanyService 
{
  base_url:string = "https://localhost:44329";

  constructor(private client:HttpClient) 
  {

  }

  public GetAllCompanies():Observable<Company[]>
  {
    return this.client.get<Company[]>(this.base_url+"/companyservice/getallcompanies");
  }
}
