export class InvoicesInfoView{
    id: string;
    customerid: string;
    creationdate: Date;
    saledate: Date;
    paymentdeadline: Date;
    nettopay: number;
    grosstopay: number;
    paid: number;
    lefttopay: number;
    remarks: string;
    status: number;
    sellerid: string;
    currency: string;
    vatrate: number;
}