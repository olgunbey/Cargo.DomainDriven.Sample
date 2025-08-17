
export class GetAllProductByCategoryIdResponseDto {

    public productId:string;
    public name: string;
    public categoryId: string;
    public price: number;
    constructor(productId:string, productName:string, categoryId:string, price:number) {
        this.productId = productId;
        this.name = productName;
        this.categoryId = categoryId;
        this.price = price;
    }
}