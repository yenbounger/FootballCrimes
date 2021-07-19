import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CrimeTypePipe } from './crime-type.pipe';
import { ListPipe } from './list.pipe';



@NgModule({
  declarations: [
    CrimeTypePipe,
    ListPipe
  ],
  imports: [
    CommonModule
  ],
  exports: [
    CrimeTypePipe,
    ListPipe
  ]
})
export class SharedModule { }
