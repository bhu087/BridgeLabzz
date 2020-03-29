import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashBoardComponent } from './dash-board/dash-board.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { RegisterComponent } from './register/register.component';
import { CreateNoteComponent } from './create-note/create-note.component';
import { ProfilePicComponent } from './profile-pic/profile-pic.component';
import { CloudinaryModule, Cloudinary } from '@cloudinary/angular-5.x';
import { SearchComponent } from './search/search.component';


const routes: Routes = [
    {path:'home', component : MainNavComponent},
    {path: 'register', component : RegisterComponent},
    { path:'dashboard',component : DashBoardComponent },
    {path:'', component : DashBoardComponent},//redirectTo:'https://keep.google.com/', pathMatch:'full'}
    {path:'profile', component : ProfilePicComponent},
    { path:'search',component : SearchComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],//CloudinaryModule.forRoot(cloudinaryLib, CloudinaryConfig),
  exports: [RouterModule]
})
export class AppRoutingModule { 

}
