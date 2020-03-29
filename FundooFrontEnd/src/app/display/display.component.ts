import { Component, OnInit } from '@angular/core';
import { BackEndServiceService } from '../back-end-service.service';

interface DataResponse {
  notesId1: number;
  email: string;
  title: string;
  Description: string;
  createdTime: string;
  modifiedTime: string;
  remainder: string;
  image: string;
  isArchive: boolean;
  isTrash: boolean;
  isPin: boolean;
  color: string;
}

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css'],
  providers:[BackEndServiceService]
})
export class DisplayComponent implements OnInit {
  // userNotes = 
  //   {
  //     title: ' ',
  //     Description: ' ',
  //   }
  
 Message;
  constructor(private service : BackEndServiceService) { }

  ngOnInit(): void {
    
  }

  displayMessage(){
    const Email = {
      email : "Bhu@gmail.com"
    }
  var tempArray: DataResponse[] = [];
    this.service.getAllNotes(Email).subscribe((serve) =>{
    
    console.log(tempArray[0]);
    alert("Displayed");
    });
  }
}
