export class Product{
    public name: string;
    public netPrice: number;
    public quantity: number;
    constructor(
    name: string,
    netPrice: number,
    quantity: number)
    {
        this.name = name;
        this.netPrice = netPrice;
        this.quantity = quantity;
    }

}