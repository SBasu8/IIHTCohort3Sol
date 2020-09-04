import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userlanding',
  templateUrl: './userlanding.component.html',
  styleUrls: ['./userlanding.component.css']
})
export class UserlandingComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }

  public IPOs()
  {
    this.router.navigateByUrl("userlanding/ipodetails");
  }

  public CompareCompanies()
  {
    this.router.navigateByUrl("userlanding/compareprice");
  }

  public LogOut()
  {
    localStorage.clear();
    this.router.navigateByUrl("")
  }

}
