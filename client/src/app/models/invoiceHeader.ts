import { InvoiceItem } from "./invoiceItem";
import { User } from "./user";
import { Buyer } from "./buyer";

export class InvoiceHeader {
    id?: number;
    invoiceNumber: number;
    shippingDate: Date;
    documentDate: Date;
    arrivalDate: Date;
    description: string;
    remark: string;
    placeOfIssuance: string;
    dateOfIssuance: Date;
    fiscalNumber: string;
    buyer: Buyer;
    numberOfItems: number;
    totalPrice: number;
    isCharged: boolean;
    appUserId?: number;
    appUser?: User;
    invoiceItems?: InvoiceItem[];
  }
  
  export enum InvoiceStatus {
    Created,
    Charged,
  }