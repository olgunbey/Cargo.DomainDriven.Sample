import { ResponseDto } from "@/Dtos";
import { NoContentDto } from "@/Dtos/NoContentDto";
import { SaveOrderRequestDto } from "@/Dtos/SaveOrderRequestDto";
import { Order } from "@/Pages/OrderListPage.vue";

export class EndpointOrder {

    public static endpointOrder:EndpointOrder | null
    public static GetEndpointOrder(): EndpointOrder{

        if(this.endpointOrder == null)
            this.endpointOrder = new EndpointOrder();

        return this.endpointOrder;
    } 

    async SaveOrder(orderProductList:SaveOrderRequestDto):Promise<ResponseDto<NoContentDto>> {
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
    async GetAllOrderByCustomerId(customerId:string):Promise<ResponseDto<Order[]>>
    {
        return await fetch("/api/Order/GetAllOrderByCustomerId",{
            method:'GET',
            headers:{
                'Content-Type':'application/json',
                'Accept': 'application/json',
                'customerId':customerId
            }
        }).
        then(async response =>(await response.json()) as ResponseDto<Order[]>)
        .catch(error=> {
            console.log(error)
            return new ResponseDto<Order[]>([error],null)
        })
    }
}