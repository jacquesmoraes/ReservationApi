import { Component, Input } from '@angular/core';
import { CheckTableParams } from 'src/app/shared/models/CheckTableParams';

@Component({
  selector: 'app-tables-sidebar',
  templateUrl: './tables-sidebar.component.html',
  styleUrls: ['./tables-sidebar.component.scss']
})
export class TablesSidebarComponent {
  @Input()
  isSubmitted: boolean = false;

  @Input()
  checkTableParams: CheckTableParams;

  constructor() {
    this.checkTableParams = {} as CheckTableParams;
    
  }

}
