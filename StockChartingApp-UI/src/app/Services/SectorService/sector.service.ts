import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from "../../Models/CompanyService/company";
import { Stockexchangedto } from "../../Models/CompanyService/stockexchangedto";
import { HttpClient } from "@angular/common/http";
import { Sectordto } from 'src/app/Models/CompanyService/sectordto';

@Injectable({
  providedIn: 'root'
})
export class SectorService 
{
  base_url:string = "https://localhost:44329";
  constructor(private client:HttpClient) 
  {
  }
  public GetAllSectors():Observable<Sectordto[]>
  {
    return this.client.get<Sectordto[]>(this.base_url+"/sectorservice/getallsectors");
  }
  public AddNewSector(sect:Sectordto):Observable<Sectordto>
  {
    return this.client.post<Sectordto>(this.base_url+"/sectorservice/addnewsector",sect);
  }
  public GetSectorCompanyList(sect:Sectordto):Observable<string[]>
  {
    return this.client.get<string[]>(this.base_url+"/sectorservice/getcompanylist/"+sect.id);
  }
  public UpdateSector(comp:Company,sect:Sectordto):Observable<any>
  {
    return this.client.put<Sectordto>(this.base_url+"/sectorservice/updatesector/"+comp.id,sect.id);
  }
}