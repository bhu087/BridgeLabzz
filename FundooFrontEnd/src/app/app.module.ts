import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import {MatSidenavModule} from '@angular/material/sidenav';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { FormsModule, FormGroup, FormBuilder, Validators, ReactiveFormsModule } from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';
import {MatGridListModule} from '@angular/material/grid-list';
import { AboutComponent } from './about/about.component';
import { LoginComponentComponent } from './login-component/login-component.component';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MatCardModule } from '@angular/material/card'
import { MatInputModule } from '@angular/material/input';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { RegisterComponent } from './register/register.component'
import { MatExpansionModule } from '@angular/material/expansion';
import {MatTooltipModule} from '@angular/material/tooltip';
import { Routes, RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { ForgetPasswordComponent } from './forget-password/forget-password.component';
import { ResetPasswordComponent } from './reset-password/reset-password.component';

@NgModule({
  declarations: [
    AppComponent,
    MainNavComponent,
    AboutComponent,
    LoginComponentComponent,
    DashBoardComponent,
    RegisterComponent,
    ForgetPasswordComponent,
    ResetPasswordComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatSidenavModule,
    LayoutModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    FormsModule,
    MatTabsModule,
    MatGridListModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatCardModule,
    MatInputModule,
    MatExpansionModule,
    MatTooltipModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { 
  opened = false;
}
