import { Component, OnInit } from '@angular/core';
import { Table } from '../shared/models/tables';
import { TablesService } from './tables.service';
import { CheckTableParams } from '../shared/models/CheckTableParams'
import { FormBuilder, FormControl, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { formatDateAndTime } from '../utils/date-formatter';

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss'],

})
export class TablesComponent implements OnInit {
  tables: Table[] = [];
  numberOfGuests?: number;
  checkTableParams: CheckTableParams;
  date: Date = new Date();
  filterForm: FormGroup;
  isSubmitted = false;

  constructor(private tableService: TablesService, private formBuilder: FormBuilder) {
    this.checkTableParams = {}
    this.filterForm = this.formBuilder.group({
      numberOfGuests: [null, [Validators.required, Validators.min(1), Validators.max(20)]],
      date: [null, Validators.required],
      time: [null, [Validators.required, timeRangeValidator('09:00', '21:00')]]
    });
  }

  ngOnInit(): void {
    this.getTables();
  }


  onSubmit() {
    if(this.filterForm.invalid){
      this.filterForm.markAllAsTouched();
      return;
    }

    this.isSubmitted = true;
    // spread(espalhar) = ... servem pra espalhar dados de array ou objeto
    // const result = [...array1, ...array2]
    // const user = {emai: "hugo@gmail.com", username:"hgrafa"}
    // const {email, ...rest} = user // rest operator
    
    const formData = this.filterForm.value;
    this.checkTableParams = {...formData}
    
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
    const params: CheckTableParams = {
      numberOfGuests: formValues.numberOfGuests,
      date: selectedDate,
      time: selectedTime
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

    if (!date || !time)
      return '';
    
    return formatDateAndTime(date, time);
  }

}

function timeRangeValidator(minHour: string, maxHour: string) {
  return (control: FormControl): ValidationErrors | null => {
    const value = control.value;
    if (!value) {

      return null;
    }

    const currentHour = parseInt(value.split(':')[0], 10);
    const minHourValue = parseInt(minHour.split(':')[0], 10);
    const maxHourValue = parseInt(maxHour.split(':')[0], 10);

    if (currentHour < minHourValue || currentHour > maxHourValue) {
      return { timeRange: true };
    }

    return null;
  };
}
