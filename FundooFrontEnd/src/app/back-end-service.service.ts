import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { stringify } from 'querystring';
import { DisplayComponent } from 'src/app/display/display.component';
import { Observable } from 'rxjs';



@Injectable()
export class BackEndServiceService {
  uri = 'https://localhost:44371';
  constructor(private http:HttpClient){
    ////,private display: DisplayComponent
  }
  getLogin(email : any, password : any){
    const log = {
      email : email,
      password : password
    }
    return this.http.post(this.uri+'/api/Account/login', log);
  }

  register(log : any){
    return this.http.post(this.uri+'/api/Account/register', log);
  }

  createNote(note : any){
    return this.http.post(this.uri+'/api/Notes/addNote', note);
  }

  getAllNotes(search : any){
    console.log(search);
    return this.http.get(this.uri+'/api/Notes/getAllNotes/?email='+search.email);
  };

  searchNotes(value : any){
    
    console.log("Search Here");
    console.log(value);
    return this.http.get(this.uri+'/api/Notes/search/?searchParameter='+value);
  }
  
  // displayMessage(message : any){
  //   return this.display.displayMessage(message);
  // }
}
