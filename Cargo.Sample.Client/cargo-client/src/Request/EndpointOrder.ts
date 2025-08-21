import { LocalStorageProductListDto, ResponseDto } from "@/Dtos";
import { NoContentDto } from "@/Dtos/NoContentDto";

export class EndpointOrder {

    public static endpointOrder:EndpointOrder | null
    public static GetEndpointOrder(): EndpointOrder{

        if(this.endpointOrder===null)
            this.endpointOrder = new EndpointOrder();

        return this.endpointOrder;
    } 

    async CreateOrder(orderProductList:LocalStorageProductListDto[]):Promise<ResponseDto<NoContentDto>> {
        return await fetch("/api/Order/CreateOrder",{
            method:'POST',
            headers:{
                'Content-Type':'application/json',
                'Accept': 'application/json',
            },
            body:JSON.stringify(orderProductList)
        }).
        then(async response =>(await response.json()) as ResponseDto<NoContentDto>)
        .catch(error=> {
            console.log(error)
            return new ResponseDto<NoContentDto>([error],null)
        })

    }
}