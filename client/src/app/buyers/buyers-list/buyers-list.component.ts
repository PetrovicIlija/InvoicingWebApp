import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Buyer } from 'src/app/models/buyer';
import { BuyersFormComponent } from '../buyers-form/buyers-form.component';
import { BuyerService } from 'src/app/_services/buyer.service';

@Component({
  selector: 'app-buyers-list',
  templateUrl: './buyers-list.component.html',
  styleUrls: ['./buyers-list.component.css']
})
export class BuyersListComponent implements OnInit{
  buyers: Buyer[] = [];
  displayDialog: boolean;
  newBuyer: Buyer = {
    name: '',
    address: '',
    city: '',
    country: '',
    postalCode: '',
    identificationNumber: '',
    taxNumber: '',
    bankAccount1: '',
    bankAccount2: '',
    bankAccount3: '',
    swift: '',
    isDomestic: true,
  };



  ngOnInit(): void {
    this.loadBuyers();
  }

  constructor(
    private buyersService: BuyerService,
    private dialog: MatDialog,
  ) { }

  loadBuyers() {
    this.buyersService.getBuyers().subscribe(buyers => {
      this.buyers = buyers;
    })
  }

  openDialog(buyer:Buyer) {
    const dialogConfig = new MatDialogConfig();

    if (buyer.name === '') {
      dialogConfig.data = {
        name: this.newBuyer.name,
        address: this.newBuyer.address,
        city: this.newBuyer.city,
        country: this.newBuyer.country,
        postalCode: this.newBuyer.postalCode,
        identificationNumber: this.newBuyer.identificationNumber,
        taxNumber: this.newBuyer.taxNumber,
        bankAccount1: this.newBuyer.bankAccount1,
        bankAccount2: this.newBuyer.bankAccount2,
        bankAccount3: this.newBuyer.bankAccount3,
        swift: this.newBuyer.swift,
        isDomestic: this.newBuyer.isDomestic,
      };

      const dialogRef = this.dialog.open(BuyersFormComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.addBuyer(result);
        }
      });
    } else {
      dialogConfig.data = {
        id: buyer.id,
        name: buyer.name,
        address: buyer.address,
        city: buyer.city,
        country: buyer.country,
        postalCode: buyer.postalCode,
        identificationNumber: buyer.identificationNumber,
        taxNumber: buyer.taxNumber,
        bankAccount1: buyer.bankAccount1,
        bankAccount2: buyer.bankAccount2,
        bankAccount3: buyer.bankAccount3,
        swift: buyer.swift,
        isDomestic: buyer.isDomestic,
      };
  

  
      const dialogRef = this.dialog.open(BuyersFormComponent, dialogConfig);
  
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          this.updateBuyer(result);
        }
      });
    }
  }

  addBuyer(buyer: Buyer) {
    this.buyersService.addBuyer(buyer).subscribe(() => {
      this.loadBuyers();
    });
  }

  updateBuyer(buyer: Buyer) {
    this.buyersService.updateBuyer(buyer).subscribe(() => {
      this.loadBuyers();
    });
  }

  deleteBuyer(buyer: Buyer) {
    if(confirm("Are you sure you want to delete the buyer?")) {
      this.buyersService.deleteBuyer(buyer.id).subscribe(() => {
        this.loadBuyers();
      });
    }
  }

}
