import { Component, Input } from '@angular/core';
import { Table } from '../models/tables';
import { TablesComponent } from '../tables/tables.component';

@Component({
  selector: 'app-table-item',
  templateUrl: './table-item.component.html',
  styleUrls: ['./table-item.component.scss']
})
export class TableItemComponent {
@Input() table? : Table;
@Input() isSubmitted? : boolean;
}
