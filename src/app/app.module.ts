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
import { MatButtonModule, MatCheckboxModule ,MatFormFieldModule} from '@angular/material';
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
import { ArchiveComponent } from './components/archive/archive.component';
import { LabelComponent } from './components/label/label.component';
import { TrashComponent } from './components/trash/trash.component';
import { MatChipsModule } from '@angular/material/chips';
import { AuthServiceConfig, FacebookLoginProvider, SocialLoginModule } from 'angular-6-social-login';
import { AuthGuard } from './auth/auth.guard';
import { CollaborationComponent } from './components/collaboration/collaboration.component';
import { SearchComponent } from './components/search/search.component';
import { SearchPipe } from './pipe/search.pipe';
import {DragDropModule} from '@angular/cdk/drag-drop';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatTooltipModule} from '@angular/material/tooltip';
import {MatInputModule} from '@angular/material/input';

export function getAuthServiceConfigs() {
  let config = new AuthServiceConfig(
      [
        {
          id: FacebookLoginProvider.PROVIDER_ID,
          provider: new FacebookLoginProvider("2465798696765815")
        },
      ]
  );
  return config;
}
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
    ArchiveComponent,
    LabelComponent,
    TrashComponent,
    CollaborationComponent,
    SearchComponent,
    SearchPipe,
   
    
    
   
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
    MatChipsModule,
    SocialLoginModule,
    MatFormFieldModule,
    DragDropModule,
    MatDatepickerModule,
    MatTooltipModule,
    MatInputModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  providers: [AuthGuard,UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,

    multi: true
  },
  {
    provide: AuthServiceConfig,
    useFactory: getAuthServiceConfigs
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }