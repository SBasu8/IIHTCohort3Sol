import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-adminlanding',
  templateUrl: './adminlanding.component.html',
  styleUrls: ['./adminlanding.component.css']
})
export class AdminlandingComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  public ImportStockPrices()
  {
    this.router.navigateByUrl("adminlanding/uploadexcel");
  }

  public ManageExchanges()
  {
    this.router.navigateByUrl("adminlanding/manageexchange");
  }

  public ManageCompanies()
  {
    this.router.navigateByUrl("adminlanding/managecompany");
  }

  public ManageIPODetails()
  {
    this.router.navigateByUrl("adminlanding/manageipodetails");
  }

  public LogOut()
  {
    localStorage.clear();
    this.router.navigateByUrl("");
  }

}
