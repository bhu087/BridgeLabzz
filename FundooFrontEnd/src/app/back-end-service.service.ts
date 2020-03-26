import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { stringify } from 'querystring';
import { DisplayComponent } from 'src/app/display/display.component';



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

  getAllNotes(value : any){
    return this.http.get(this.uri+'/api/Notes/getAllNotes', value.email);
  }
  
  // displayMessage(message : any){
  //   return this.display.displayMessage(message);
  // }
}
