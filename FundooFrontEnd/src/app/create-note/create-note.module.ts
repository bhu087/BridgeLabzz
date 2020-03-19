import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateNoteComponent } from './create-note.component';



@NgModule({
  declarations: [CreateNoteComponent],
  imports: [
    CommonModule
  ],
  exports:[
    CreateNoteComponent
  ]
})
export class CreateNoteModule { }
