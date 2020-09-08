
import { Router } from '@angular/router';
import { InputDetails } from './../../../Models/AuthService/input-details';
import { AccountService } from './../../../Services/AccountService/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-userlogin',
  templateUrl: './userlogin.component.html',
  styleUrls: ['./userlogin.component.css']
})
export class UserloginComponent implements OnInit {

  inputDetails: InputDetails;
  errMssg: string;
  constructor(private service: AccountService, private router: Router) 
  { this.inputDetails = new InputDetails();}

  ngOnInit(): void {
  }

  Login()
  { 
    this.service.UserLogin(this.inputDetails).subscribe(res=>{
      
      if(res.token=="" || res.token==null) {alert("Invalid Creds");window.location.reload();}
      else if(res.roleType!=2) {this.errMssg="You are not a User";}
      else{
        localStorage.setItem("token",res.token);
        console.log(res);
        this.router.navigateByUrl("userlanding");
      }
    })
  }

  Signup()
  {
    this.router.navigateByUrl("signup");
  }


}
