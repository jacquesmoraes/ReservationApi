import { Component, OnInit } from '@angular/core';
import { Table } from '../models/tables';
import { TablesService } from './tables.service';
import { CheckTableParams } from '../models/CheckTableParams'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
  filterForm: FormGroup;
  isSubmitted = false;


  constructor(private tableService: TablesService, private formBuilder: FormBuilder) {
    this.checkParams = {}
    this.filterForm = this.formBuilder.group({
      numberOfGuests: [null, [Validators.required, Validators.min(0), Validators.max(20)]],
      date: [null, Validators.required],
      time: [null, Validators.required]
    });
  }

  ngOnInit(): void {
    this.getTables();
  }
  onSubmit() {
    this.isSubmitted = true;
    
    if (this.filterForm.invalid) {
      console.log('invalid')
      return;
    }
    this.onReservationRequest();
  }
  getTables() {
    this.tableService.getTables().subscribe({
      next: (response: Table[]) => this.tables = response,
      error: error => console.log(error)

    })
  }

  
  onReservationRequest() {
    const formValues = this.filterForm.value;
    const selectedDate = formValues.date;
    const selectedTime = formValues.time;
    const params :CheckTableParams = {
      numberOfGuests : formValues.numberOfGuests,
      date : selectedDate,
      time : selectedTime
      
    }

    this.tableService.getAvailableTables(params).subscribe({
      next: response => {
        console.log(response);
        this.tables = response;
      },
      error: error => console.log(error)
    })
  }

  get formattedReservationDateTime(): string {
    const date = this.filterForm.value.date;
    const time = this.filterForm.value.time;
  
    if (date && time) {
      const dateTime = new Date(date);
      const [hours, minutes] = time.split(':').map(Number);
      dateTime.setHours(hours, minutes);
      return dateTime.toISOString();
    }
    return '';
  }

 
}
