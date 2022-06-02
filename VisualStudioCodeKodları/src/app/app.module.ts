import { ApiService } from 'src/app/services/api.service';
import { SafeHtmlPipe } from './pipes/safeHtml-pipe.pipe';
import { KategoriDialogComponent } from './components/dialogs/kategori-dialog/kategori-dialog.component';
import { HaberDialogComponent } from './components/dialogs/haber-dialog/haber-dialog.component';
import { KategoriComponent } from './components/kategori/kategori.component';
import { HaberComponent } from './components/haber/haber.component';
import { LoginComponent } from './components/login/login.component';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { MyAlertService } from './services/myAlert.service';
import { AlertDialogComponent } from './components/dialogs/alert-dialog/alert-dialog.component';
import { HomeComponent } from './components/home/home.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.module';
import { ConfirmDialogComponent } from './components/dialogs/confirm-dialog/confirm-dialog.component';
import { HttpClientModule } from '@angular/common/http';
import { JoditAngularModule } from 'jodit-angular';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainNavComponent,
    LoginComponent,
    HaberComponent,
    KategoriComponent,
  

    //Dialoglar
    AlertDialogComponent,
    ConfirmDialogComponent,
    HaberDialogComponent,
    KategoriDialogComponent,
    
    SafeHtmlPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    JoditAngularModule,
    
  ],
  entryComponents:[
    AlertDialogComponent,
    ConfirmDialogComponent,
    HaberDialogComponent,
    KategoriDialogComponent
  ],
  providers: [MyAlertService,ApiService,SafeHtmlPipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
