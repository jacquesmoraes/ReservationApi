import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Table } from '../models/tables';
import { CheckTableParams } from '../models/CheckTableParams';
import { formatDate } from '@angular/common';
import * as moment from 'moment';

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


  getAvailableTables( {date , time, numberOfGuests}: CheckTableParams) {
    // const {date, time, numberOfGuests = 10} = checkParams
    let params = new HttpParams();
     
    if(numberOfGuests) params = params.append('NumberOfGuests', numberOfGuests);
    if(date){ 
      const formattedDate = formatDate(date, 'yyyy-MM-dd', 'en-US');
      params = params.append('date', formattedDate);}
     if(time){ 
      const formattedTime = moment(time, "HH:mm").format("HH:mm:ss")
      params = params.append('time', formattedTime);}
    

    return  this.http.get<Table[]>(this.baseUrl + 'table/available',{ params} );
   
  }

}