import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from '../_services/account.service';
import { User } from '../models/user';
import { Router } from '@angular/router';
import {MessageService} from 'primeng/api';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  providers: [MessageService]
})
export class NavComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService, private router: Router, private messageService: MessageService) { }

  ngOnInit(): void {
  }
  login(){
    this.accountService.login(this.model).subscribe( {
      next: _ => this.router.navigateByUrl('/invoices'),
      error: error => this.messageService.add({severity:'error', summary:'Error', detail:error.error})
    });
  }
  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
}
