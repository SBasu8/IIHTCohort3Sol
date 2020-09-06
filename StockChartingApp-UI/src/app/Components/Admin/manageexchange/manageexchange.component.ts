import { Stockprice } from './../../../Models/StockExchangeService/stockprice';
import { StockExchangeService } from './../../../Services/StockExchangeService/stock-exchange.service';
import { Component, OnInit } from '@angular/core';
import { Stockexchange } from '../../../Models/StockExchangeService/stockexchange';

@Component({
  selector: 'app-manageexchange',
  templateUrl: './manageexchange.component.html',
  styleUrls: ['./manageexchange.component.css']
})
export class ManageexchangeComponent implements OnInit {

  se_form_state: boolean = false;
  origin_form_state: boolean = true;
  se_table_display_state: boolean = true;
  sp_table_display_state: boolean = true;
  
  new_se: Stockexchange = new Stockexchange();
  
  se_list: Stockexchange[];
  sp_list: Stockprice[];

  constructor(private se_service : StockExchangeService) 
  { 
    se_service.GetAllStockPrice().subscribe(res=>{
      console.log(res);
      this.sp_list = res;
    },(err)=>{console.log(err);});
    se_service.GetAllStockExchange().subscribe(res=>{
      console.log(res);
      this.se_list = res;
    },(err)=>{console.log(err);});

    
  }

  ngOnInit(): void {
    
  }

  Submit()
  {
    this.se_service.AddNewStockExchange(this.new_se).subscribe(res=>{
      console.log(res);
      window.location.reload();
      alert("Added New Stock Exchange");
      
    })
  }

  AddStockExchangeForm()
  {
    this.se_form_state = true;
    this.origin_form_state = false;
  }
  Origin()
  {
    this.se_form_state = false;
    this.origin_form_state = true;
  }

}
