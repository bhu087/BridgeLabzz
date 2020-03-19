import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class BackEndServiceService {
  uri = 'https://localhost:44371';
  constructor(private http:HttpClient){

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
}
