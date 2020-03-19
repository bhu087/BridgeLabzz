import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  router: any;
  result:any;
  constructor(private service : BackEndServiceService) { }
  formBuilder: FormBuilder;
  registerForm: FormGroup;
  submitted = false;
    ngOnInit() {
      this.formBuilder = new FormBuilder;
        this.registerForm = this.formBuilder.group({
          firstName: ['', [Validators.required, Validators.minLength(6)]],
          lastName: ['', [Validators.required, Validators.minLength(6)]],
          registerEmail : ['', [Validators.required, Validators.email]],//,Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
          password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(20),Validators.pattern('^(?=\\D*\\d)(?=[^a-z]*[a-z])(?=[^A-Z]*[A-Z]).{6,20}$')]],
        });
    }
    // convenience getter for easy access to form fields
    get registrationForm() { return this.registerForm.controls; }

    // checkPassSame(){
    //   const pass = this.formBuilder.value.password;
    //   const passConf = this.formBuilder.value.confirmPassword;
    //   if(pass == passConf) {
    //     this.i = false;
    //   }else {
    //     this.i = true;
    //   }
    // }
    

    onRegisterSubmit(value : any) {
        this.submitted = true;
        // stop here if form is invalid
        if (this.registerForm.invalid) {
          return;
        }
        console.log("I m here");
        // let formData: FormData = new FormData(); 
        // formData.append('Name', value.firstName); 
        // formData.append('Email', value.email);
        // formData.append('Password', value.password);
        // console.log(formData);
        const log = {
          name : value.firstName,
          email : value.registerEmail,
          password : value.password
        }
        this.service.register(log).subscribe((serve) =>{
          console.log(serve);
          this.result = serve;
          // console.log('JSON Response = ', JSON.stringify(result));
          //this.router.navigate(['dashboard']);
          alert("Registered");
        });
      }
}
