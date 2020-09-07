import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';
import { Company } from 'src/app/Models/CompanyService/company';
import { Stockexchangedto } from 'src/app/Models/CompanyService/stockexchangedto';
import { Sectordto } from "src/app/Models/CompanyService/sectordto";
import { Ipodto } from "src/app/Models/CompanyService/ipodto";
import { StockExchangeService } from 'src/app/Services/StockExchangeService/stock-exchange.service';
import { SectorService } from 'src/app/Services/SectorService/sector.service';

@Component({
  selector: 'app-managesector',
  templateUrl: './managesector.component.html',
  styleUrls: ['./managesector.component.css']
})
export class ManagesectorComponent implements OnInit {

  
  sect_list:Sectordto[];
  new_sector = new Sectordto();
  existing_sectors:Sectordto[];
  sect_form_state = false;
  origin_form_state = true;
  sect_update_state=false;
  

  constructor(private sector_service:SectorService) 
  {    
    sector_service.GetAllSectors().subscribe(res =>
      {
        console.log(res);
        this.sect_list = res;
      }, (err)=>
      {
        console.log(err);
      });
  }

  ngOnInit(): void {
  }

  public AddNewSector()
  {
    this.sector_service.AddNewSector(this.new_sector).subscribe( sect_res =>
    {
        console.log(sect_res);
        window.location.reload();
        alert("Sector Added Successfully")
    }, (err) => 
    {
      console.log(err);
    });
  }

  public UpdateExistingSector()
  {
    this.sector_service.UpdateSectorDetails(this.new_sector).subscribe( sect_res =>
    {
        console.log(sect_res);
        window.location.reload();
        alert("Sector Updated Successfully")
    }, (err) => 
    {
      console.log(err);
    });
  }


  public AddSectorForm()
  {
    this.sect_form_state = true;
    this.origin_form_state = false;
    this.sect_update_state=false;
    this.new_sector = new Sectordto();
  }
  public UpdateSectorForm()
  {
    this.sect_form_state = false;
    this.origin_form_state = false;
    this.sect_update_state=true;
    this.new_sector = new Sectordto();
  }
  public Origin()
  {
    this.sect_form_state = false;
    this.origin_form_state = true;
    this.sect_update_state=false;
  }


}
