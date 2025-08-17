
export class GetAllProductByCategoryIdResponseDto {

    
    public id: number;
    public productName: string;
    public categoryId: number;
    public price: number;
    public description: string
    constructor(id:number, productName:string, categoryId:number, price:number, description:string) {
        this.id = id;
        this.productName = productName;
        this.categoryId = categoryId;
        this.price = price;
        this.description = description;
        
    }
}