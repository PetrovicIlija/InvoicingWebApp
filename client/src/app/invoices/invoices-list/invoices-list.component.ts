import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { InvoiceService } from 'src/app/_services/invoice.service';
import { InvoiceHeader } from 'src/app/models/invoiceHeader';
import { InvoicesFormComponent } from '../invoices-form/invoices-form.component';

@Component({
  selector: 'app-invoices-list',
  templateUrl: './invoices-list.component.html',
  styleUrls: ['./invoices-list.component.css']
})
export class InvoicesListComponent implements OnInit {
  invoices: InvoiceHeader[];
  displayDialog: boolean;
  newInvoice: InvoiceHeader = {
    invoiceNumber: 0,
    shippingDate: new Date(),
    documentDate: new Date(),
    arrivalDate: new Date(),
    description: '',
    remark: '',
    placeOfIssuance: '',
    dateOfIssuance: new Date(),
    fiscalNumber: '',
    buyer: null,
    numberOfItems: 0, 
    totalPrice: 0,
    isCharged: false,
  };

  constructor(
    private invoiceService: InvoiceService,
    private dialog: MatDialog,
    private router : Router,
  ) { }

  ngOnInit(): void {
    this.loadInvoices();
  }

  loadInvoices() {
    this.invoiceService.getInvoices().subscribe(invoices => {
      this.invoices = invoices;
    });
  }

  openInvoiceCreatePage(invoice:InvoiceHeader) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = "80%";
    dialogConfig.height = "80%";

    if (invoice.invoiceNumber == undefined || invoice.invoiceNumber === 0) {
      dialogConfig.data = {
        // name: this.newBuyer.name,
        // address: this.newBuyer.address,
        // city: this.newBuyer.city,
        // country: this.newBuyer.country,
        // postalCode: this.newBuyer.postalCode,
        // identificationNumber: this.newBuyer.identificationNumber,
        // taxNumber: this.newBuyer.taxNumber,
        // bankAccount1: this.newBuyer.bankAccount1,
        // bankAccount2: this.newBuyer.bankAccount2,
        // bankAccount3: this.newBuyer.bankAccount3,
        // swift: this.newBuyer.swift,
        // isDomestic: this.newBuyer.isDomestic,
      };

      const dialogRef = this.dialog.open(InvoicesFormComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.addInvoice(result);
        }
      });
    } else {
      // dialogConfig.data = {
      //   id: buyer.id,
      //   name: buyer.name,
      //   address: buyer.address,
      //   city: buyer.city,
      //   country: buyer.country,
      //   postalCode: buyer.postalCode,
      //   identificationNumber: buyer.identificationNumber,
      //   taxNumber: buyer.taxNumber,
      //   bankAccount1: buyer.bankAccount1,
      //   bankAccount2: buyer.bankAccount2,
      //   bankAccount3: buyer.bankAccount3,
      //   swift: buyer.swift,
      //   isDomestic: buyer.isDomestic,
      // };
      dialogConfig.data = invoice;
  

  
      const dialogRef = this.dialog.open(InvoicesFormComponent, dialogConfig);
  
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.updateInvoice(result);
        }
        else {
          // ak izmjeni podatke i zatvori dialog, bez da stisne Save, vrati podatke na početno stanje prije izmjene
          this.loadInvoices();
        }
      });
    }
  }


  payTheInvoice(invoice: InvoiceHeader) {
    if(confirm("Are you sure you want to charge the invoice?")) {
      invoice.isCharged = true;
      this.invoiceService.updateInvoice(invoice).subscribe(() => {
        this.loadInvoices();
      });
    }
  }


  addInvoice(invoice: InvoiceHeader) {
    this.invoiceService.addInvoice(invoice).subscribe(() => {
      this.loadInvoices();
    });
  }

  updateInvoice(invoice: InvoiceHeader) {
    this.invoiceService.updateInvoice(invoice).subscribe(() => {
      this.loadInvoices();
    });
  }

  deleteInvoice(invoice: InvoiceHeader) {
    if(confirm("Are you sure you want to delete the invoice?")) {
      this.invoiceService.deleteInvoice(invoice.id).subscribe(() => {
        this.loadInvoices();
      });
    }
  }
}
