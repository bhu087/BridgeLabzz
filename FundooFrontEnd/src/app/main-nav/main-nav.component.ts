import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map, shareReplay } from 'rxjs/operators';
import { BackEndServiceService } from '../back-end-service.service';

@Component({
  selector: 'app-main-nav',
  templateUrl: './main-nav.component.html',
  styleUrls: ['./main-nav.component.css'],
  providers:[BackEndServiceService]
})
export class MainNavComponent {
   loadLoginOnClick : boolean = true;
   loadRegisterOnClick : boolean = false;
  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches),
      shareReplay()
    );
     loadLogin(){
       this.loadLoginOnClick = true;
       this.loadRegisterOnClick = false;
     }
     loadAbout(){
       this.loadLoginOnClick = false;
       this.loadRegisterOnClick = false;
     }
     loadRegister(){
       this.loadRegisterOnClick = true;
       this.loadLoginOnClick = false;
     }
  constructor(private breakpointObserver: BreakpointObserver) {}
}
