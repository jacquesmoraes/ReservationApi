import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from "@angular/common/http";
import { ReservationComponent } from './reservation/reservation.component';
import { HomeComponent } from './home/home.component';
import { HomeModule } from './home/home.module';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { TablesComponent } from './tables/tables.component';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { TableItemComponent } from './tables/table-item/table-item.component';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { TablesDetailsComponent } from './tables/tables-details/tables-details.component';
import { TablesModule } from './tables/tables.module';

@NgModule({
  declarations: [
    AppComponent,
    ReservationComponent,
    
    HomeComponent,
    NavbarComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    HomeModule,
    FormsModule,
    MatNativeDateModule,
    NgxMaterialTimepickerModule,
    TablesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
