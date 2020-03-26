import { Component, OnInit } from '@angular/core';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css'],
  providers:[BackEndServiceService]
})
export class DisplayComponent implements OnInit {
  userNotes = 
    {
      title: ' ',
      Description: ' ',
    }
  
 Message = "";
  constructor(private service : BackEndServiceService) { }

  ngOnInit(): void {
    
  }

  displayMessage(){
    this.service.getAllNotes("bhu.com").subscribe((serve) =>{
      console.log(serve);
      alert("Displayed");
      });
      console.log("I'm Here");
  }
}
