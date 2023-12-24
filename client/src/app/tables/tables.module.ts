import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { MatFormFieldModule } from '@angular/material/form-field';

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    TimepickerModule.forRoot()
  
  ],
})
export class TablesModule { }
