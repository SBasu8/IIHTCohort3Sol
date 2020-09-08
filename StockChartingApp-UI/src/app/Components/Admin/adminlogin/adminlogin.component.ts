import { Router } from '@angular/router';
import { InputDetails } from './../../../Models/AuthService/input-details';
import { AccountService } from './../../../Services/AccountService/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-adminlogin',
  templateUrl: './adminlogin.component.html',
  styleUrls: ['./adminlogin.component.css']
})
export class AdminloginComponent implements OnInit {

  inputDetails: InputDetails;
  errMssg: string;

  constructor(private service: AccountService,private router: Router) 
  { this.inputDetails=new InputDetails();}

  ngOnInit(): void {
  }

  Login()
  { 
    this.service.AdminLogin(this.inputDetails).subscribe(res=>{
      
      if(res.token=="" || res.token==null) {alert("Invalid Creds"); window.location.reload();}
      else if(res.roleType!=1) {this.errMssg="You are not an Admin";}
      else
      {
        localStorage.setItem("token", res.token);
        console.log(res);
        this.router.navigateByUrl("adminlanding");
      }

    })
  }

}
