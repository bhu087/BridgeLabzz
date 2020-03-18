import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { MainNavComponent } from './main-nav/main-nav.component';


const routes: Routes = [
    {path:'home', component : MainNavComponent},
    {path:'', redirectTo:'https://keep.google.com/', pathMatch:'full'},
    { path:'dashboard',component : DashBoardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
