import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import  {  FormsModule  }  from  '@angular/forms' ;
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { ServicesListComponent } from './services/services-list/services-list.component';
import { InvoicesListComponent } from './invoices/invoices-list/invoices-list.component';
import { SharedModule } from './_modules/shared.module';
import { environment } from '../environments/environment';
import {TableModule} from 'primeng/table';
import { ServiceFormComponent } from './services/service-form/service-form.component';
import { InvoicesFormComponent } from './invoices/invoices-form/invoices-form.component';
import { BuyersListComponent } from './buyers/buyers-list/buyers-list.component';
import { BuyersFormComponent } from './buyers/buyers-form/buyers-form.component'; 
import { ReactiveFormsModule } from '@angular/forms';
import {DialogModule} from 'primeng/dialog';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import{MatFormFieldModule} from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatDialogModule} from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input';
import { MatOptionModule } from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    ServicesListComponent,
    InvoicesListComponent,
    ServiceFormComponent,
    InvoicesFormComponent,
    BuyersListComponent,
    BuyersFormComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    SharedModule,
    TableModule,
    ReactiveFormsModule,
    DialogModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatFormFieldModule,
    MatToolbarModule,
    MatDialogModule,
    MatInputModule,
    MatOptionModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule
  ],
  providers: [
    {
      provide: 'BASE_URL',
      useValue: environment.baseUrl
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
