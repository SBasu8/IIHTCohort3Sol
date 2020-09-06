import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { SignupComponent } from './Components/Common/signup/signup.component';
import { AdminlandingComponent } from './Components/Admin/adminlanding/adminlanding.component';
import { UserlandingComponent } from './Components/User/userlanding/userlanding.component';
import { UploadexcelComponent } from './Components/Admin/uploadexcel/uploadexcel.component';
import { ManageexchangeComponent } from './Components/Admin/manageexchange/manageexchange.component';
import { ManagecompanyComponent } from './Components/Admin/managecompany/managecompany.component';
import { ManageipodetailsComponent } from './Components/Admin/manageipodetails/manageipodetails.component';
import { AdminloginComponent } from './Components/Admin/adminlogin/adminlogin.component';
import { UserloginComponent } from './Components/User/userlogin/userlogin.component';
import { ChartingComponent } from './Components/User/charting/charting.component';
import { ComparepriceComponent } from './Components/User/compareprice/compareprice.component';
import { HomepageComponent } from './Components/Common/homepage/homepage.component';
import { IpodetailsComponent } from './Components/User/ipodetails/ipodetails.component';
import { ManagesectorsComponent } from "./Components/Admin/managesectors/managesectors.component";

const routes: Routes = [
  {path:"",component:HomepageComponent},
  {path:"signup", component:SignupComponent},
  {path:"userlogin", component:UserloginComponent},
  {path:"adminlogin", component:AdminloginComponent},
  {path:"adminlanding", component:AdminlandingComponent, children:[
    {path:"uploadexcel", component:UploadexcelComponent},
    {path:"manageexchange", component:ManageexchangeComponent},
    {path:"managecompany", component:ManagecompanyComponent},
    {path:"manageipodetails", component:ManageipodetailsComponent},
    {path:"managesectors", component:ManagesectorsComponent}    
  ]},
  {path:"userlanding", component:UserlandingComponent, children:[
    {path:"charting", component:ChartingComponent},
    {path:"compareprice", component:ComparepriceComponent},
    {path:"ipodetails", component:IpodetailsComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
