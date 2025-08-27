
export class SaveOrderRequestDto {
    public cityId:string
    public cityName:string
    public districtId:string
    public districtName:string
    public detail:string
    public customerId:string
    public productItems:ProductItems[]
    public locationId:string

    constructor(cityId:string,cityName:string,districtId:string,districtName:string,detail:string,customerId:string,productItems:ProductItems[],locationId:string)
    {
        this.cityId=cityId;
        this.cityName=cityName;
        this.districtId=districtId;
        this.detail=detail;
        this.customerId=customerId;
        this.districtName=districtName;
        this.productItems=productItems;
        this.locationId=locationId;
    }

}

export class ProductItems{
    public id:string
    public name:string
    public quantity:number
    public price:number


    constructor(id:string,name:string,quantity:number,price:number) {
       this.id=id;
       this.name=name;
       this.quantity=quantity;
       this.price=price; 
    }
}