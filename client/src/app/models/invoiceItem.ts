import { InvoiceHeader } from './invoiceHeader';
import { Service } from './service';
export class InvoiceItem {
    id?: number;
    description: string;
    quantity: number;
    priceOfService: number;
    priceOfServiceInEuros?: number;
    discount: number;
    tax: number;
    totalPrice: number;
    invoiceHeaderId: number;
    invoiceHeader: InvoiceHeader;
    serviceId: number;
    service: Service;
  }