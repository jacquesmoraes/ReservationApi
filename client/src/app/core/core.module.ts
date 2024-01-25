import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './navbar/navbar.component';
import { SharedModule } from '../shared/shared.module';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestErrorComponent } from './test-error/test-error.component';
import { FormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  declarations: [
    NavbarComponent,
    ServerErrorComponent,
    TestErrorComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    FormsModule,
    MatNativeDateModule,
    NgxMaterialTimepickerModule,
    ToastrModule.forRoot({positionClass: 'toast-bottom-right', preventDuplicates: true}),
    BsDropdownModule.forRoot(),
  ],
  exports:[
    NavbarComponent
  ]
})
export class CoreModule { }
