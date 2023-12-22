import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Table } from '../models/tables';
import { Observable } from 'rxjs';
import { CheckTableParams } from '../models/CheckTableParams';

@Injectable({
  providedIn: 'root'
})
export class TablesService {
  

  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }
  
  getTables(){
    return this.http.get<Table[]>(this.baseUrl + 'table');

  }

getTable(id:number){
return this.http.get<Table>(this.baseUrl + 'table/'+ id)
}


  getAvailableTables(checkParams: CheckTableParams) {
    

    let params = new HttpParams();
    if (checkParams.date) {
      
      const formattedDate = new Date(checkParams.date).toISOString().split('T')[0];
      params = params.append('date', formattedDate);
  }

  if (checkParams.time) {
    const [hours, minutes, seconds] = checkParams.time.split(':');

    const formattedTime = new Date(1970, 0, 1, +hours, +minutes, +seconds).toISOString().split('T')[1];
    console.log('Formatted Time:', formattedTime);
    params = params.append('time', formattedTime);
  }

    return  this.http.get<Table[]>(this.baseUrl + 'table/available',{ params} );
   
  }

}