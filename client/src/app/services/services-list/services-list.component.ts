import { Component, OnInit } from '@angular/core';
import { ServiceService } from 'src/app/_services/service.service';
import { Service } from 'src/app/models/service';
import { ServiceFormComponent } from '../service-form/service-form.component';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';

@Component({
  selector: 'app-services-list',
  templateUrl: './services-list.component.html',
  styleUrls: ['./services-list.component.css']
})
export class ServicesListComponent implements OnInit {
  services : Service[];
  displayDialog: boolean;
  newService: Service = {
    name: '',
    price: 1,
    priceInEuros: this.calculatePriceInEuros(1)
  };
  



  constructor(
    private serviceService: ServiceService,
    private dialog : MatDialog,
  ) { }

  ngOnInit(): void {
    this.loadServices();
  }


  loadServices(){
    this.serviceService.getServices().subscribe(services => {
      this.services = services;
    })
  }


  openDialog(service:Service) {
    const dialogConfig = new MatDialogConfig();

    if (service.name === '') {
      dialogConfig.data = {
        name: this.newService.name,
        price: this.newService.price,
        priceinEuros: this.calculatePriceInEuros(this.newService.price)
      };

      const dialogRef = this.dialog.open(ServiceFormComponent, dialogConfig);

      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          result.priceInEuros = this.calculatePriceInEuros(result.price);
          this.addService(result);
        }
      });
    } else {
      dialogConfig.data = {
        id: service.id,
        name: service.name,
        price: service.price,
        priceInEuros: this.calculatePriceInEuros(service.price)
      };
  

  
      const dialogRef = this.dialog.open(ServiceFormComponent, dialogConfig);
  
      dialogRef.afterClosed().subscribe(result => {
        if (result) {
          result.priceInEuros = this.calculatePriceInEuros(result.price);
          this.updateService(result);
        }
      });
    }
  }
  addService(service: Service) {
    this.serviceService.addService(service).subscribe(() => {
      this.loadServices();
    });
  }

  updateService(service: Service) {
    this.serviceService.updateService(service).subscribe(() => {
      this.loadServices();
    });
  }

  deleteService(service: Service) {
    if(confirm("Are you sure you want to delete the service?")) {
      this.serviceService.deleteService(service.id).subscribe(() => {
        this.loadServices();
      });
    }
  }

  calculatePriceInEuros(price: number): number {
    return price / 1.95583;
  }

}
