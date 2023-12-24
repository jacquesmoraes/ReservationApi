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


  getAvailableTables( {date, time, numberOfGuests = 10}: CheckTableParams) {
    // const {date, time, numberOfGuests = 10} = checkParams
    let params = new HttpParams();
    if(numberOfGuests) params = params.append('NumberOfGuests', numberOfGuests);
    if(date)  params = params.append('ReservationTime', date.toISOString());
     if(time) params = params.append('ReservationTime', time.toISOString());
    

    return  this.http.get<Table[]>(this.baseUrl + 'table/available',{ params} );
   
  }

}