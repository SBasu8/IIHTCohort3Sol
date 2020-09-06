import { AccountService } from './../../../Services/AccountService/account.service';
import { Role } from './../../../Models/AuthService/role';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  item: Role;
  errMssg: string="No Errors yet";
  constructor(private service : AccountService) {this.item = new Role(); }

  ngOnInit(): void {
  }

  Signup()
  {
    console.log(this.item);
 
    this.item.roleType=parseInt(this.item.roleType.toString());
    this.service.Signup(this.item).subscribe(res=>{
      console.log(res);
    })
  }

}
