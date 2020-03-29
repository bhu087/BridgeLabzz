import { Component, OnInit } from '@angular/core';
import { BackEndServiceService } from '../back-end-service.service';
import { FormGroup, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
  providers:[BackEndServiceService]
})
export class SearchComponent implements OnInit {
  formBuilder: any;
  searchNote: FormGroup;
  searchKey: string;
  constructor(private service: BackEndServiceService) { }

  ngOnInit(): void {
    this.formBuilder = new FormBuilder;
        this.searchNote = this.formBuilder.group({
          search:[]
         });
  }
  searchKeyUp(value : any){
    console.log("Search Here");
    this.searchKey = value.search.toString();
    this.service.searchNotes("Hello").subscribe((serve) =>{
      console.log(serve);
      alert("Searched");
    });
  }
  
}
