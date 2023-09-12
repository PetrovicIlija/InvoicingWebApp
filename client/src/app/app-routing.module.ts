import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { InvoicesListComponent } from './invoices/invoices-list/invoices-list.component';
import { BuyersListComponent } from './buyers/buyers-list/buyers-list.component';
import { ServicesListComponent } from './services/services-list/services-list.component';
import { AuthGuard } from './_guards/auth.guard';
import { InvoicesFormComponent } from './invoices/invoices-form/invoices-form.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '', runGuardsAndResolvers: 'always', canActivate: [AuthGuard], children: [
      { path: 'invoices', component: InvoicesListComponent },
      { path: 'services', component: ServicesListComponent },
      { path: 'partners', component: BuyersListComponent },
      { path: 'invoices/create', component: InvoicesFormComponent },
      { path: 'invoices/edit/:id', component: InvoicesFormComponent },
    ]
  },
  { path: '**', component: HomeComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
