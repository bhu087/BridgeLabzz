import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { RegisterComponent } from './register/register.component';
import { CreateNoteComponent } from './create-note/create-note.component';


const routes: Routes = [
    {path:'home', component : MainNavComponent},
    {path: 'register', component : RegisterComponent},
    {path:'', redirectTo:'https://keep.google.com/', pathMatch:'full'},
    { path:'dashboard',component : DashBoardComponent },
    {path: 'createNote', component: CreateNoteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
