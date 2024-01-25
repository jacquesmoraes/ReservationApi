import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';

import { ReactiveFormsModule} from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { MatNativeDateModule } from '@angular/material/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableItemComponent } from './table-item/table-item.component';
import { TablesDetailsComponent } from './tables-details/tables-details.component';
import { TablesComponent } from './tables.component';
import { RouterLink, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon, MatIconModule } from '@angular/material/icon';
import { TablesSidebarComponent } from './tables-sidebar/tables-sidebar.component';
import { SharedModule } from '../shared/shared.module';
import { TablesRoutingModule } from './tables-routing.module';
import { AccountModule } from '../account/account.module';


@NgModule({
  
  declarations: [
    TablesComponent,
    TableItemComponent,
    TablesDetailsComponent,
    TablesSidebarComponent,
  ],
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatNativeDateModule,
    MatInputModule,
    MatButtonModule,
    MatDatepickerModule,
    TablesRoutingModule,
    MatIconModule,
    MatButtonModule,
   AccountModule,
    SharedModule,
    
    
    
  ],
 
    
})
export class TablesModule { }
