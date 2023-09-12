import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgxNavbarModule } from 'ngx-bootstrap-navbar';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    NgxNavbarModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    TooltipModule.forRoot(),
    ButtonModule,
    ToastModule
  ],
  exports: [
    NgxNavbarModule,
    BsDropdownModule,
    CollapseModule,
    TooltipModule,
    ButtonModule,
    ToastModule
  ]
})
export class SharedModule { }
