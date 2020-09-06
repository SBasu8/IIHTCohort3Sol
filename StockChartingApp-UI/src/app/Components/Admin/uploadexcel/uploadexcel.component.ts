import { UploadExcelService } from './../../../Services/UploadExcelService/upload-excel.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-uploadexcel',
  templateUrl: './uploadexcel.component.html',
  styleUrls: ['./uploadexcel.component.css']
})
export class UploadexcelComponent implements OnInit {

  fileInput: File = null;
  constructor(private service : UploadExcelService) { }

  ngOnInit(): void {
  }

  onSelectedFile(e){this.fileInput = e.target.files[0];console.log(this.fileInput);}

  StockPriceUpload()
  {
    console.log(this.fileInput);
    if(this.fileInput==null){alert( "Please input file");}
    else{
      var formData = new FormData();
      formData.append("file1",this.fileInput);
      
      formData.forEach((value,key) => {
        console.log(key+" "+value)
      });

      this.service.Upload(formData).subscribe(res=>{
        console.log(res);
        alert("Uploaded");
        window.location.reload();
      })
    }
  }
  

}
