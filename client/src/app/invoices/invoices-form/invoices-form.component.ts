import { ChangeDetectorRef, Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BuyerService } from 'src/app/_services/buyer.service';
import { ServiceService } from 'src/app/_services/service.service';
import { Buyer } from 'src/app/models/buyer';
import { InvoiceHeader } from 'src/app/models/invoiceHeader';
import { InvoiceItem } from 'src/app/models/invoiceItem';
import { Service } from 'src/app/models/service';

@Component({
  selector: 'app-invoices-form',
  templateUrl: './invoices-form.component.html',
  styleUrls: ['./invoices-form.component.css']
})
export class InvoicesFormComponent {
  invoiceItems: InvoiceItem[] = [];
  buyers: Buyer[] = [];
  selectedBuyer = null;
  services: Service[] = [];
  basicPrice = 0;
  // invoiceForm: FormGroup;

  constructor(
    private buyersService: BuyerService,
    private servicesService: ServiceService,
    private dialogRef: MatDialogRef<InvoicesFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: InvoiceHeader,
    private formBuilder: FormBuilder
  ) { 
  }

  ngOnInit(): void {
    if(this.data.buyer != undefined) {
      this.selectedBuyer = this.data.buyer.id;
    }


    this.servicesService.getServices().subscribe(data => {
      this.services = data;
      
      if(this.data.id != undefined) {
        this.invoiceItems = this.data.invoiceItems;
      }
    });

    this.buyersService.getBuyers().subscribe(data => {
      this.buyers = data;
    });
  }


  selectedBuyerChange(e) {
    var buyerId = e.value;
    var buyer = this.buyers.find(x => x.id == buyerId);
    this.data.buyer = buyer;
  }

  selectedInvoiceItemServiceChange(e, item) {
    var selectedServiceId = e.value;
    var service = this.services.find(x => x.id == selectedServiceId);

    if(service) {
      item.priceOfService = service.price;
      item.priceOfServiceInEuros = (service.price / 1.95583).toFixed(2);
    }
  }

  close(){
    this.dialogRef.close();
  }

  onSubmit(){
    this.data.invoiceItems = this.invoiceItems;
  }

  addItem() {
    var item = new InvoiceItem();
    item.discount = 0;
    item.tax = 0;
    this.invoiceItems.push(item);
  }

  deleteInvoiceItem(index: number) {
    this.invoiceItems.splice(index, 1);
  }

  onQuantityChange(searchValue: string, item): void {  
    var quantity = parseInt(searchValue);
    if(quantity < 0) {
      quantity = 0;
    }
    item.quantity = quantity;
    var updatedTotal = quantity * item.priceOfService;
    item.totalPrice = updatedTotal;
    this.basicPrice = updatedTotal;
  }

  onDiscountChange(searchValue: string, item): void {
    var discount = parseInt(searchValue);
    if(discount > 100) {
      discount = 100;
    }
    if(discount < 0) {
      discount = 0;
    }
    item.discount = discount;
    var discountAmount = this.basicPrice * (discount / 100);
    item.totalPrice = this.basicPrice - discountAmount + (this.basicPrice * (item.tax / 100));
  }

  onTaxChange(searchValue: string, item): void {
    var tax = parseInt(searchValue);
    if(tax > 100) {
      tax = 100;
    }
    if(tax < 0) {
      tax = 0;
    }
    item.tax = tax;
    var taxAmount = this.basicPrice * (tax / 100);
    item.totalPrice = this.basicPrice + taxAmount - (this.basicPrice * (item.discount / 100));
  }
  
}
