
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UploadExcelService {

  path: string = "http://localhost:8001";
  constructor(private http: HttpClient) { }

  Upload(fileInput: FormData){
    return this.http.post(this.path+"/uploadexcelservice/upload",fileInput);
  }
}
