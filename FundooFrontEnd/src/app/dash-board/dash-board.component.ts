import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent implements OnInit {
 loadDashBoard: boolean = false;
 panelOpenState: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }
  activeDashBoard(){
    this.loadDashBoard = true;
  }
}
