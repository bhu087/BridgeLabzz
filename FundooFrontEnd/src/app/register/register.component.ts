import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  constructor(private service : BackEndServiceService) { }
  formBuilder: any;
  registerForm: FormGroup;
  submitted = false;
  public i : boolean;
    ngOnInit() {
      this.formBuilder = new FormBuilder;
        this.registerForm = this.formBuilder.group({
          FirstName: ['', [Validators.required]],
          LastName: ['', [Validators.required]],
          email: ['', [Validators.required, Validators.email,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
          password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20),Validators.pattern('^(?=\\D*\\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{6,20}$')]],
          confirmPassword : ['',[Validators.required]]  
        });
    }
    checkPassSame(){
      let pass = this.formBuilder.value.password;
      let passConf = this.formBuilder.value.confPass;
      if(pass == passConf) {
        this.i = true;
      }else {
        this.i = false;
      }
    }
    // convenience getter for easy access to form fields
    get form() { return this.registerForm.controls; }

    onRegisterSubmit(value : any) {
        this.submitted = true;
        // stop here if form is invalid
        if (this.registerForm.invalid) {
          return;
        }
        let formData: FormData = new FormData(); 
        formData.append('Name', value.name); 
        formData.append('Email', value.email);
        formData.append('Password', value.password);
      }
}
