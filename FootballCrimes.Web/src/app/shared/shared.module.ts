import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrimeTypePipe } from './crime-type.pipe';



@NgModule({
  declarations: [
    CrimeTypePipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CrimeTypePipe
  ]
})
export class SharedModule { }
