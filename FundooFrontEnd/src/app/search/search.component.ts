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
  searchResult: string;
  constructor(private service: BackEndServiceService) { }

  ngOnInit(): void {
    this.formBuilder = new FormBuilder;
        this.searchNote = this.formBuilder.group({
          search:[]
         });
  }
  searchKeyUp(value : any){
    this.service.searchNotes(value.search).subscribe((serve) =>{
      console.log(serve);
      this.searchResult = serve.toString();
      alert("Searched");
    });
  }
  
}
