
export class ProductDto {

    public productId:string;
    public name: string;
    public categoryId: string;
    public price: number;
    public image:string;
    public description:string;
    constructor(productId:string, productName:string, categoryId:string, price:number,image:string,description:string) {
        this.productId = productId;
        this.name = productName;
        this.categoryId = categoryId;
        this.price = price;
        this.image=image;
        this.description=description;
    }
}