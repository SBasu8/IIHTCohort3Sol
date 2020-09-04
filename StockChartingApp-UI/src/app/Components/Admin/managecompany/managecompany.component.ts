import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';
import { Company } from 'src/app/Models/company';

@Component({
  selector: 'app-managecompany',
  templateUrl: './managecompany.component.html',
  styleUrls: ['./managecompany.component.css']
})
export class ManagecompanyComponent implements OnInit 
{
  comp_list = new Array();

  constructor(private company_service:CompanyService) 
  {
    company_service.GetAllCompanies().subscribe(res =>
      {
        console.log(res);
        this.comp_list = res;
      }, (err)=>
      {
        console.log(err);
      });
  }

  ngOnInit(): void {
  }

}
