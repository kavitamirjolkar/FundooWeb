import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './components/user/user.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { UserService } from './service/user.service';
import { LoginComponent } from './components/login/login.component';
import { HomeComponent } from './components/home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { ForgetPasswordComponent } from './components/forget-password/forget-password.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import 'hammerjs';
import { MatButtonModule, MatCheckboxModule } from '@angular/material';
import{MatIconModule}from '@angular/material/icon';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import{MatListModule}from '@angular/material/list';
import {MatCardModule} from '@angular/material/card';
import { NotesComponent } from './components/notes/notes.component';
import { NotesDisplayComponent } from './components/notes-display/notes-display.component';
import {MatExpansionModule} from '@angular/material/expansion';
import { NotesondashboardComponent } from './components/notesondashboard/notesondashboard.component';
import {FlexLayoutModule} from '@angular/flex-layout';
import { IocnsOnNoteComponent } from './components/iocns-on-note/iocns-on-note.component';
import { DialogComponent } from './components/dialog/dialog.component';
import {MatDialogModule} from '@angular/material/dialog';
import { ReminderComponent } from './components/reminder/reminder.component';


@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    ForgetPasswordComponent,
    ResetPasswordComponent,
    NotesComponent,
    NotesDisplayComponent,
    NotesondashboardComponent,
    IocnsOnNoteComponent,
    DialogComponent,
    ReminderComponent,
    
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatSidenavModule,
    MatButtonModule,
    MatCheckboxModule,
    MatIconModule,
    MatToolbarModule,
    MatMenuModule,
    MatListModule,
    MatCardModule,
    FlexLayoutModule,
    MatExpansionModule,
    MatDialogModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }