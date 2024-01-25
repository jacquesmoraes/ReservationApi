import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { CarouselModule } from 'ngx-bootstrap/carousel';



@NgModule({
  declarations: [
    TextInputComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CarouselModule.forRoot(),
    
  ],
  exports:[
    ReactiveFormsModule,
    TextInputComponent,
    CarouselModule
  ]
})
export class SharedModule { }
