import { Component, OnInit } from '@angular/core';
import { Table } from '../models/tables';
import { TablesService } from './tables.service';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit {
  tables : Table[] = [];

 constructor(private tableService : TablesService){}

  ngOnInit(): void {
    this.tableService.getTables().subscribe({
      next: (response : Table[]) => this.tables = response,
      error: error => console.log(error)

    })
  }

}
