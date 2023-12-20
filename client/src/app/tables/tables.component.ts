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
  numberOfGuests: number = 0;
  date: Date = new Date();
  time: Date = new Date();

 constructor(private tableService : TablesService){}

  ngOnInit(): void {
   
    this.getTables();
  }
  onUserInputChange(): void {
   
    this.getAvailableTables();
  }
  getTables(){
    this.tableService.getTables().subscribe({
      next: (response : Table[]) => this.tables = response,
      error: error => console.log(error)

    })
  }

  getAvailableTables(): void {
    this.tableService.getAvailableTables(this.numberOfGuests, this.date, this.time)
      .subscribe((tables) => {
        this.tables = tables;
        
      });
  }
  


  

}
