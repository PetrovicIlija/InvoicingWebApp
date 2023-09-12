import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { Service } from '../models/service';
import { environment } from 'src/environments/environment';
import { User } from '../models/user';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {

  private baseUrl = environment.baseUrl;
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(
    private http: HttpClient,
    private accountService: AccountService
    ) {}

  

  getServices(): Observable<Service[]> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}service`; 
    return this.http.get<Service[]>(url, httpOptions);
  }
  getService(id: number): Observable<Service> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}service/${id}`; 
    return this.http.get<Service>(url, httpOptions);
  }
  addService(service: Service): Observable<Service> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}service`; 
    return this.http.post<Service>(url, service, httpOptions);
  }
  updateService(service: Service): Observable<Service> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}service/${service.id}`; 
    return this.http.put<Service>(url, service, httpOptions);
  }
  deleteService(id: number): Observable<Service> {
    const token = this.accountService.getBearerToken();
    const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    })
  };
    const url = `${this.baseUrl}service/${id}`; 
    return this.http.delete<Service>(url, httpOptions);
  }
  
}
