export class InvoiceAdd{
    constructor(
        public customerId : string,
        public sellerId : string,
        public currency : string,
        public vatRate : number
    ){}
}