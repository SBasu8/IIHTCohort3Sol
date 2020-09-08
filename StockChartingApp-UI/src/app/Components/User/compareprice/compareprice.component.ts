import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'src/app/Services/CompanyService/company.service';
import { StockExchangeService } from 'src/app/Services/StockExchangeService/stock-exchange.service';
import { Stockexchange } from 'src/app/Models/StockExchangeService/stockexchange';
import { Stockpricerequestdto } from 'src/app/Models/CompanyService/stockpricerequestdto';
import { Company } from 'src/app/Models/CompanyService/company';
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { Router } from '@angular/router';

@Component({
  selector: 'app-compareprice',
  templateUrl: './compareprice.component.html',
  styleUrls: ['./compareprice.component.css']
})
export class ComparepriceComponent implements OnInit {
 
	comp_list:Company[];
	comp_id_map = new Map();
  existing_ses:Stockexchange[];
	request_list = new Array<Stockpricerequestdto>();
	
	myForm:FormGroup;

	constructor(private company_service:CompanyService, private se_service:StockExchangeService, private fb:FormBuilder, private router:Router) 
  {
		company_service.GetAllCompanies().subscribe(res =>
		{
			console.log(res);
			this.comp_list = res;
			this.comp_list.forEach( comp =>
			{
				this.comp_id_map.set(comp.companyName,comp.id);
			});
		}, (err)=>
		{
			console.log(err);
		});

    se_service.GetAllStockExchange().subscribe(res => 
    {
      console.log(res);
      this.existing_ses = res;
    }, (err)=>
    {
      console.log(err);
    });
  }

  ngOnInit(): void 
	{
		let newForm = this.fb.group({
			From_Date: [''],
			From_Time: [''],
			To_Date: [''],
			To_Time: [''],
			Period: [''],
			formArray: this.fb.array([])
		});

		const arrayControl = <FormArray>newForm.controls['formArray'];
			let newGroup = this.fb.group({
					StockExchange: [''],
					CompanyName: ['']					
			});
		arrayControl.push(newGroup);

		this.myForm = newForm;
 }
  
		addInput(): void 
		{
			const arrayControl = <FormArray>this.myForm.controls['formArray'];
			let newGroup = this.fb.group({
					StockExchange: [''],
					CompanyName: ['']					
			});
			arrayControl.push(newGroup);
		}

		delInput(index:number): void 
		{
			console.log(index);
			const arrayControl = <FormArray>this.myForm.controls['formArray'];
			arrayControl.removeAt(index);			
		}

		onSubmit(): void 
		{
			const arrayControl = <FormArray>this.myForm.controls['formArray'];
			for(let i=0;i<arrayControl.length;i++)
			{
				let temp_req = new Stockpricerequestdto();
				temp_req.companyId = this.comp_id_map.get(arrayControl.at(i).value.CompanyName);
				temp_req.stockExchangeId = arrayControl.at(i).value.StockExchange;
				temp_req.from = this.myForm.controls['From_Date'].value + " " + this.myForm.controls['From_Time'].value;
				temp_req.to = this.myForm.controls['To_Date'].value + " " + this.myForm.controls['To_Time'].value;
				temp_req.periodicity = this.myForm.controls['Period'].value;
				temp_req.companyName = arrayControl.at(i).value.CompanyName;
				this.request_list.push(temp_req);
			}
			console.log(this.request_list);
			localStorage.setItem("chart_request",JSON.stringify(this.request_list));
			this.router.navigateByUrl("userlanding/charting");
		}

		get formData()
		{
			return <FormArray>this.myForm.get('formArray');
		}

		public onChangeEvent(e): void 
		{
			let name = e.target.value;
			let list = this.comp_list.filter(c => c.companyName === name)[0];
		}
}