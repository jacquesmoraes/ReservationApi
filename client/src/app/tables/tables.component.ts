import { Component, OnInit } from '@angular/core';
import { Table } from '../models/tables';
import { TablesService } from './tables.service';
import { CheckTableParams } from '../models/CheckTableParams'
import { FormControl, FormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss'],
  
})
export class TablesComponent implements OnInit {
  tables: Table[] = [];
  numberOfGuests: number = 0;
  checkParams = new CheckTableParams();
  date: Date = new Date();
  time: Date = new Date();


  constructor(private tableService: TablesService) { }

  ngOnInit(): void {

    this.getTables();
  }

  getTables() {
    this.tableService.getTables().subscribe({
      next: (response: Table[]) => this.tables = response,
      error: error => console.log(error)

    })
  }

  getAvailableTables() {

    this.tableService.getAvailableTables(this.checkParams).subscribe({
      next: response => {

        this.tables = response;
      },
      error: error => console.log(error)
    })


  }



}