
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UploadExcelService {

  path: string = "https://localhost:44329/uploadexcelservice";
  constructor(private http: HttpClient) { }

  Upload(fileInput: FormData){
    return this.http.post(this.path+"/upload",fileInput);
  }
}
