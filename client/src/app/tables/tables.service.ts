import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Table } from '../models/tables';

@Injectable({
  providedIn: 'root'
})
export class TablesService {
  baseUrl = 'https://localhost:5001/api/'

  constructor(private http: HttpClient) { }

  getTables(){
    return this.http.get<Table[]>(this.baseUrl + 'table');

  }
}
