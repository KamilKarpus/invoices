export class ProductAdd{
    constructor(
        public invoiceId: string,
        public name: string,
        public netPrice: number,
        public quantity: number
    ) {}
}