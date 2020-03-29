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
  dataCurrentArray: Array<any> = [];
  dataUndoArray: Array<any> = [];
  dataRedoArray: Array<any> = [];
  undoLimit: number = 5;
  showUndo:boolean = false;
  showRedo:boolean = false;
  constructor(private service : BackEndServiceService,
    private router: Router) { }

  ngOnInit(): void {
    this.formBuilder = new FormBuilder;
        this.createNoteForm = this.formBuilder.group({
          createDescription : ['', [Validators.required,]],
          createTitle:[]
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
  undo(): void {
    this.showRedo = true;
    if (this.dataUndoArray.length != 0) {    
      this.dataRedoArray.push(this.dataCurrentArray.pop());  
      this.dataCurrentArray.push(this.dataUndoArray.pop());
      if (this.dataUndoArray.length == 0) {
        this.showUndo = false;
      }
    }    
  }
  redo(): void {
    if (this.dataRedoArray.length != 0) {    
     this.dataUndoArray.push(this.dataCurrentArray.pop());
     this.dataCurrentArray.push(this.dataRedoArray.pop());
     if (this.dataRedoArray.length == 0) {
       this.showRedo = false;
    }
   }
  }

}
