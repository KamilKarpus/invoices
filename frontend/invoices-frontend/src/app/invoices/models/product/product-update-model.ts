export class ProductUpdate{
    constructor(
        public productId: string,
        public netPrice: number,
        public quantity: number,
        public name: string
    ){}
}