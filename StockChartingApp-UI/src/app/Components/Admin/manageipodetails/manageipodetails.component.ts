import { Component, OnInit } from '@angular/core';
import { Ipodto } from 'src/app/Models/CompanyService/ipodto';
import { Stockexchangedto } from 'src/app/Models/CompanyService/stockexchangedto';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';

@Component({
  selector: 'app-manageipodetails',
  templateUrl: './manageipodetails.component.html',
  styleUrls: ['./manageipodetails.component.css']
})
export class ManageipodetailsComponent implements OnInit {

  new_ipo = new Ipodto();
  existing_ipos:Ipodto[];
  existing_ses:Stockexchangedto[];

  constructor(private company_service:CompanyService) 
  {
    company_service.GetStockExchangeList().subscribe(res => 
      {
        console.log(res);
        this.existing_ses = res;
      }, (err)=>
      {
        console.log(err);
      });
    company_service.GetAllIPOs().subscribe(res => 
      {
        console.log(res);
        this.existing_ipos = res;
      }, (err)=>
      {
        console.log(err);
      });
  }

  ngOnInit(): void {
  }

  public AddNewIPO()
  {
    this.company_service.AddCompanyIPO(this.new_ipo).subscribe( ipo_res => 
      {
        console.log(ipo_res);
        window.location.reload();
        alert("IPO details added Successfully")
      }, (err) => 
      {
        console.log(err["error"]);
        alert(err["error"])
      });      
  }

}
