import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { BackEndServiceService } from '../back-end-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.css']
})
export class CreateNoteComponent implements OnInit {
  collapsed : boolean = false;
  formBuilder: any;
  createNoteForm: FormGroup;
  noteData: string;
  constructor(private service : BackEndServiceService,
    private router: Router) { }

  ngOnInit(): void {
    this.formBuilder = new FormBuilder;
        this.createNoteForm = this.formBuilder.group({
          createNote: ['', [Validators.required,]]
         });
  }
  get form() { return this.createNoteForm.controls; }
  onKey(event : any){
    this.noteData = event.target.value;
    if(this.noteData == null || this.noteData == ''){
        return;
    }
    this.service.createNote(this.noteData).subscribe((serve) =>{
      console.log(serve);
      alert("Created");
    });
  }

}
