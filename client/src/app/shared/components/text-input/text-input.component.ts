import { Component, Input, Self } from '@angular/core';
import { ControlValueAccessor, FormControl, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-input',
  templateUrl: './text-input.component.html',
  styleUrls: ['./text-input.component.scss']
})
export class TextInputComponent implements ControlValueAccessor {
@Input() type = 'text';
@Input() label = '';


  constructor(@Self() public controlDir: NgControl){
    this.controlDir.valueAccessor = this;
  }

  writeValue(obj: any): void {
    console.log("should write value")
  }
  
  registerOnChange(fn: any): void {
    console.log("should register on change")
  }

  registerOnTouched(fn: any): void {
    console.log("should register on touched")
  }
  
  get control(): FormControl{
    return this.controlDir.control as FormControl
  }
}
