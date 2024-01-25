import { Component, Input } from '@angular/core';
import { Table } from '../../shared/models/tables';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-table-item',
  templateUrl: './table-item.component.html',
  styleUrls: ['./table-item.component.scss']
})
export class TableItemComponent {
@Input() table? : Table;
@Input() isSubmitted? : boolean;

constructor(public accountService: AccountService){}
}
