import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { RegisterComponent } from './register/register.component';
import { CreateNoteComponent } from './create-note/create-note.component';


const routes: Routes = [
    {path:'home', component : MainNavComponent},
    {path: 'register', component : RegisterComponent},
    { path:'dashboard',component : DashBoardComponent },
    {path:'', component : DashBoardComponent}//redirectTo:'https://keep.google.com/', pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
