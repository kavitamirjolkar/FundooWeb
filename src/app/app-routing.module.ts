import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { LoginComponent } from './components/login/login.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { UserComponent } from './components/user/user.component';
import { HomeComponent } from './components/home/home.component';
import { NotesComponent } from './components/notes/notes.component';
import { NotesDisplayComponent } from './components/notes-display/notes-display.component';
import { NotesondashboardComponent } from './components/notesondashboard/notesondashboard.component';
import { DialogComponent } from './components/dialog/dialog.component';
import { ArchiveComponent } from './components/archive/archive.component';
import { LabelComponent } from './components/label/label.component';
import { ReminderComponent } from './components/reminder/reminder.component';
import { TrashComponent } from './components/trash/trash.component';
import { IocnsOnNoteComponent } from './components/iocns-on-note/iocns-on-note.component';


const routes: Routes = [
  {path:'',redirectTo:'/user/login',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent },   
      { path: 'forgotpassword', component: ForgetPasswordComponent },
      { path: 'resetpassword', component: ResetPasswordComponent },
   ] 
  },
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]
,
children:[

  {path:'',redirectTo:'notes',pathMatch:'full'},
  { path: 'notes', component:NotesDisplayComponent},
  { path: 'notesbyId', component:NotesDisplayComponent},
  { path: 'trash', component:TrashComponent},
  {path:'archive',component:ArchiveComponent},
  {path:'labels',component:LabelComponent},
  {path:'reminder',component:ReminderComponent},
  {path:'image',component:IocnsOnNoteComponent}

]
},
{ path: 'dialog', component:DialogComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }