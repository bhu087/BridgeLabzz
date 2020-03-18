import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BackEndServiceService } from '../back-end-service.service';
import { Routes, RouterModule, Router } from '@angular/router';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.component.html',
  styleUrls: ['./login-component.component.css']
})
export class LoginComponentComponent implements OnInit {

  constructor(private service : BackEndServiceService,
    private router: Router) { }
  formBuilder: any;
  LoginForm: FormGroup;
  submitted = false;
  public dashBoardUrl = "https://stackoverflow.com/questions/40020703/angular2-redirect-to-calling-url-after-successful-login";
    ngOnInit() {
      this.formBuilder = new FormBuilder;
        this.LoginForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
            password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20),Validators.pattern('^(?=\\D*\\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{6,20}$')]]
        });
    }
    // convenience getter for easy access to form fields
    get form() { return this.LoginForm.controls; }

    onSubmit(value : any) {
        this.submitted = true;
       
        if (this.LoginForm.invalid) {
          return;
        }
         this.service.getLogin(value.email, value.password).subscribe((serve) =>{
           console.log(serve);
           this.router.navigate(['dashboard']);
           alert("Loged in");
         });
      }

}
