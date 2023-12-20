import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Table } from '../models/tables';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TablesService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getTables(){
    return this.http.get<Table[]>(this.baseUrl + 'table');

  }
  getAvailableTables(numberOfGuests: number, date: Date, time: Date): Observable<Table[]> {
    
    const formatedDate = date.toISOString().split('T')[0];
    const params = {
      numberOfGuests,
      date : formatedDate,
      time,
    };
    return this.http.post<Table[]>(this.baseUrl + 'table/available', params);
   
  }

}
