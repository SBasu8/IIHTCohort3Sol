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
  del_join_c_se_form_state: boolean = false;
  origin_form_state: boolean = true;
  se_table_display_state: boolean = true;
  
  new_se: Stockexchange = new Stockexchange();
  
  se_list: Stockexchange[];
  del_c_id: number;
  del_se_id: string;

  constructor(private se_service : StockExchangeService) 
  { 
    se_service.GetAllStockExchange().subscribe(res=>{
      console.log(res);
      this.se_list = res;
    });

    
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

  DelSubmit()
  {
    this.se_service.DeleteJoinCompanyStockExchange(this.del_c_id,this.del_se_id).subscribe(res=>{
      console.log(res);
      window.location.reload();
      alert("Deleted Company - Stock Exchange Link");
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
    this.del_join_c_se_form_state=false;
    this.origin_form_state = true;
  }
  DeleteJoinCompanyStockExchangeForm()
  {
    this.del_join_c_se_form_state = true;
    this.origin_form_state = false;
  }

}
