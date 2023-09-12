import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { AccountService } from './account.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { InvoiceHeader } from '../models/invoiceHeader';

@Injectable({
  providedIn: 'root'
})
export class InvoiceService {
  private baseUrl = environment.baseUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) { }
  getInvoices(): Observable<InvoiceHeader[]> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}invoiceheader`; 
    return this.http.get<InvoiceHeader[]>(url, httpOptions);
  }
  addInvoice(invoice: InvoiceHeader): Observable<InvoiceHeader> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}invoiceheader`; 
    return this.http.post<InvoiceHeader>(url, invoice, httpOptions);
  }
  updateInvoice(invoice: InvoiceHeader): Observable<InvoiceHeader> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}invoiceheader/${invoice.id}`;
    return this.http.put<InvoiceHeader>(url, invoice, httpOptions);
  }
  deleteInvoice(id: number): Observable<InvoiceHeader> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}invoiceheader/${id}`; 
    return this.http.delete<InvoiceHeader>(url, httpOptions);
  }
  getInvoice(id: number): Observable<InvoiceHeader> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}invoiceheader/${id}`; 
    return this.http.get<InvoiceHeader>(url, httpOptions);
  }
}
