import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import {MessageService} from 'primeng/api';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
  providers: [MessageService]
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  constructor(private accountService: AccountService, private messageService: MessageService) { }

  ngOnInit(): void {
  }
  register() {
    this.accountService.register(this.model).subscribe(response => {
      this.cancel();
    }, error => this.messageService.add({severity:'error', summary:'Error', detail:error.error}));
  }
  cancel() {
    this.cancelRegister.emit(false);
  }
}
