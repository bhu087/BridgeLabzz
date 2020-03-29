import { Component, OnInit } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css'],
  providers:[BackEndServiceService]
})
export class DashBoardComponent implements OnInit {
 loadDashBoard: boolean = false;
 panelOpenState: boolean = false;
 collapsed : boolean = false;
 remainderDiv : boolean = false;
 notesDiv : boolean = true;
 
  constructor(private service : BackEndServiceService) { }

  ngOnInit(): void {
  }
  onClickRemainder(){
    this.remainderDiv = true;
    this.notesDiv = false;
  }
  onClickNotes(){
    this.remainderDiv = false;
    this.notesDiv = true;
  }
  getAllNotes(email : any){
        console.log("get all notes here");
        
        // this.service.getAllNotes(email).subscribe((serve) =>{
        //   console.log(serve);
        //   // console.log('JSON Response = ', JSON.stringify(result));
        //   //this.router.navigate(['dashboard']);
        //   alert("Registered");
        // });
  }
  
}
