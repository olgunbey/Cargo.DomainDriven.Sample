import { ProductDto } from "./ProductDto";

export class LocalStorageProductList {

    public productDto:ProductDto;
    public quantity:number;
    constructor(productDto:ProductDto,quantity:number) {
        this.productDto=productDto
        this.quantity=quantity
    }

}