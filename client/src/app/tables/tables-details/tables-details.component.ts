import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tables-details',
  templateUrl: './tables-details.component.html',
  styleUrls: ['./tables-details.component.scss']
})
export class TablesDetailsComponent {
@Input() isSubmitted?: boolean;


}
