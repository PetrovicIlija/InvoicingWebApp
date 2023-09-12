import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AccountService } from './account.service';
import { Buyer } from '../models/buyer';

@Injectable({
  providedIn: 'root'
})
export class BuyerService {
  private baseUrl = environment.baseUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) { }
  getBuyers(): Observable<Buyer[]> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}buyer`; 
    return this.http.get<Buyer[]>(url, httpOptions);
  }
  getBuyer(id: number): Observable<Buyer> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}buyer/${id}`; 
    return this.http.get<Buyer>(url, httpOptions);
  }
  addBuyer(buyer: Buyer): Observable<Buyer> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}buyer`; 
    return this.http.post<Buyer>(url, buyer, httpOptions);
  }
  updateBuyer(buyer: Buyer): Observable<Buyer> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}buyer/${buyer.id}`; 
    return this.http.put<Buyer>(url, buyer, httpOptions);
  }
  deleteBuyer(id: number): Observable<Buyer> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}buyer/${id}`; 
    return this.http.delete<Buyer>(url, httpOptions);
  }

}
