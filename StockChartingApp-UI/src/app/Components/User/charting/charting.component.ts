import { Component, OnInit } from '@angular/core';
import * as CanvasJS from './canvasjs.min';
import { Stockpricedto } from 'src/app/Models/CompanyService/stockpricedto';
import { Stockpricerequestdto } from 'src/app/Models/CompanyService/stockpricerequestdto';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';

@Component({
  selector: 'app-charting',
  templateUrl: './charting.component.html',
  styleUrls: ['./charting.component.css']
})
export class ChartingComponent implements OnInit {

  stock_prices = new Array<Stockpricedto>();
  public request_list:Stockpricerequestdto[];
  dataList=[];

  constructor(private company_service:CompanyService) 
  {
    this.request_list = JSON.parse(localStorage.getItem("chart_request"));
  }

  ngOnInit(): void 
  { 
    let chart = new CanvasJS.Chart("chartContainer", {
      zoomEnabled: true,
      animationEnabled: true,
      exportEnabled: true,
      title: {
        text: "Stock Price Plot"
      },
      subtitles:[{
        text: "Stock Charting App"
      }],
      data: this.dataList
    });    
    
    for(var i=0; i<this.request_list.length; i++)
    {
      let comp_name = this.request_list[i].companyName;
      this.company_service.GetStockPrices(this.request_list[i]).subscribe( res =>
        {
          this.stock_prices = res;
          console.log(this.stock_prices);
          let stockPrices = [];
          this.stock_prices.forEach( sp => 
          {
            stockPrices.push({y:sp.price, label:sp.date+" "+sp.time});
          });
          this.dataList.push({type:"line", legendText:comp_name, showInLegend:true, dataPoints:stockPrices});  
          chart.render();    
      }, (err) =>
      {
        console.log(err); alert(err["error"])
      });     
    }

  }

}
