import { Component, OnInit } from '@angular/core';
import { CreateNoteComponent } from 'src/app/create-note/create-note.component';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {
 loadDashBoard: boolean = false;
 panelOpenState: boolean = false;
 collapsed : boolean = false;
  constructor() { }

  ngOnInit(): void {
  }
  activeDashBoard(){
    this.loadDashBoard = true;
  }
}
