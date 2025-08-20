import { ProductDto } from "./ProductDto";

export class LocalStorageProductList {

    public product:ProductDto;
    public quantity:number;
    constructor(product:ProductDto,quantity:number) {
        this.product=product
        this.quantity=quantity
    }

}