import { ProductDto } from "./ProductDto";

export class LocalStorageProductListDto {

    public product:ProductDto;
    public quantity:number;
    constructor(product:ProductDto,quantity:number) {
        this.product=product
        this.quantity=quantity
    }

}