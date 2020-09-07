import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';
import { Company } from 'src/app/Models/CompanyService/company';
import { Stockexchangedto } from 'src/app/Models/CompanyService/stockexchangedto';
import { Sectordto } from "src/app/Models/CompanyService/sectordto";
import { Ipodto } from "src/app/Models/CompanyService/ipodto";
import { StockExchangeService } from 'src/app/Services/StockExchangeService/stock-exchange.service';
import { SectorService } from 'src/app/Services/SectorService/sector.service';
import { Time } from '@angular/common';
@Component({
  selector: 'app-compareprice',
  templateUrl: './compareprice.component.html',
  styleUrls: ['./compareprice.component.css']
})
export class ComparepriceComponent implements OnInit {
  
  strlst:String[]=["sector","company"];
  comp_list:Company[];
  new_company = new Company();
  new_ipo = new Ipodto();
  existing_ses:Stockexchangedto[];
  existing_sectors:Sectordto[];
  exchange_name:string;
  company_name:string;
  periodicity:Time;
  from_period:Date;
  to_period:Date;
  type:string;
  stock_exchange:string;

  
  constructor(private company_service:CompanyService) 
  {    
    company_service.GetAllCompanies().subscribe(res =>
      {
        console.log(res);
        this.comp_list = res;
      }, (err)=>
      {
        console.log(err);
      });
    
    company_service.GetStockExchangeList().subscribe(res => 
    {
      console.log(res);
      this.existing_ses = res;
    }, (err)=>
    {
      console.log(err);
    });
    company_service.GetSectorList().subscribe(res => 
      {
        console.log(res);
        this.existing_sectors = res;
      }, (err)=>
      {
        console.log(err);
      });
  }
  ngOnInit(): void {
  }
  
 public DoNothing(){
 }


}