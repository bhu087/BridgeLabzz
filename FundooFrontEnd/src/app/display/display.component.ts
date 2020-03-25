import { Component, OnInit } from '@angular/core';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-display',
  templateUrl: './display.component.html',
  styleUrls: ['./display.component.css']
})
export class DisplayComponent implements OnInit {
 Message = "hello";
  constructor(private service : BackEndServiceService) { }

  ngOnInit(): void {
    
  }

  displayMessage(){
    this.service.getAllNotes("bhuD@getMaxListeners.com").subscribe((serve) =>{
      console.log(serve);
      this.Message = serve.toString();
      //this.router.navigate(['dashboard']);
      alert("Loged in");
    });
  }
}
