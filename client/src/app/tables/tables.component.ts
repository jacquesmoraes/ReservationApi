import { Component, OnInit } from '@angular/core';
import { Table } from '../models/tables';
import { TablesService } from './tables.service';
import { CheckTableParams } from '../models/CheckTableParams'


@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss'],

})
export class TablesComponent implements OnInit {
  tables: Table[] = [];
  numberOfGuests?: number;
  checkParams: CheckTableParams
  date: Date = new Date();
  time: Date = new Date();



  constructor(private tableService: TablesService) {
    this.checkParams = {}
  }

  ngOnInit(): void {
    this.getTables();
  }

  getTables() {
    this.tableService.getTables().subscribe({
      next: (response: Table[]) => this.tables = response,
      error: error => console.log(error)

    })
  }

  onReservationRequest() {
    // this.checkParams é interpretado como bool por causa do operador && e caso seja falsy o segundo membro nem é executado
    
    this.checkParams && this.tableService.getAvailableTables(this.checkParams).subscribe({
      next: response => {
        console.log(response);
        this.tables = response;
      },
      error: error => console.log(error)
    })
  }

  



}