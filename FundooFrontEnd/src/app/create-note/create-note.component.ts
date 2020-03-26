import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { BackEndServiceService } from '../back-end-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-note',
  templateUrl: './create-note.component.html',
  styleUrls: ['./create-note.component.css'],
  providers:[BackEndServiceService]
})
export class CreateNoteComponent implements OnInit {
  collapsed : boolean = false;
  formBuilder: any;
  createNoteForm: FormGroup;
  tempData : any;
  noteData: string;
  result : any;
  tempEmail : string = "bhuD@getMaxListeners.com";
  constructor(private service : BackEndServiceService,
    private router: Router) { }

  ngOnInit(): void {
    this.formBuilder = new FormBuilder;
        this.createNoteForm = this.formBuilder.group({
          createDescription : ['', [Validators.required,]]
         });
  }
  //get form() { return this.createNoteForm.controls; }
  onKey(value : any){
    this.tempData = value.createDescription;
    this.noteData = this.tempData.toString();
    if(this.noteData == null || this.noteData == ''){
        return;
    }
    console.log("log creating");
    const log = {
      email : this.tempEmail,
      title : value.createTitle,
      description : value.createDescription
    }
    this.service.createNote(log).subscribe((serve) =>{
      this.result = serve;
      console.log(serve);
      alert("Created");
    });
  }

}
