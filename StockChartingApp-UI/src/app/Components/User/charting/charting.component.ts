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

  constructor(private company_service:CompanyService) 
  {
    
  }

  ngOnInit(): void 
  {    
    let req = new Stockpricerequestdto();
    req.companyId = 18;
    req.stockExchangeId = "BSE";
    req.from = "01-08-2020 09:00:00";
    req.to = "01-08-2020 15:00:00";
    req.periodicity = 1;
    this.company_service.GetStockPrices(req).subscribe( res =>
      {
        this.stock_prices = res;
        console.log(this.stock_prices);
        let data = [];
        this.stock_prices.forEach( sp => 
        {
          data.push({y:sp.price, label:sp.date+" "+sp.time});
        });

        let chart = new CanvasJS.Chart("chartContainer", {
          zoomEnabled: true,
          animationEnabled: true,
          exportEnabled: true,
          title: {
            text: "Stock Price @ "+req.stockExchangeId
          },
          subtitles:[{
            text: "Try Zooming and Panning"
          }],
          data: [
          {
            type: "line",                
            dataPoints: data
          }]
        });
          
        chart.render();
      }, (err) =>
      {
        console.log(err); alert(err["error"])
      });
  }

}
