import { LocationDto } from "@/Components/OrderTargetLocationPopUp.vue";
import { ResponseDto,NoContentDto,SaveLocationForOrderRequestDto } from "@/Dtos";


export class EndpointLocation {
    public static endpointLocation: EndpointLocation | null 

    public static SingletonEndpointRequest(): EndpointLocation {

        if (this.endpointLocation == null)
        {
             this.endpointLocation = new EndpointLocation()
        }
        return this.endpointLocation;
    }


    async GetAllCity(): Promise<ResponseDto<LocationDto[]>> {
        return await fetch("/api/Location/GetAllLocation", {
            method: 'GET',
            headers: {
                'Content-type': 'application/json',
                'Accept': 'application/json'
            }
        }
        )
            .then(async response => (await response.json()) as ResponseDto<LocationDto[]>)
            .catch(error => {
                console.log(error);
                return new ResponseDto<LocationDto[]>([error], null)
            })
    }
    async SaveLocationForOrder(dto:SaveLocationForOrderRequestDto):Promise<ResponseDto<NoContentDto>>
    {
        return await fetch("/api/Location/SaveLocationForOrder",{
            method:'POST',
            headers:{
                'Content-type':'application/json',
                'Accept':'application/json'
            },
            body:JSON.stringify(dto)
        })
        .then(async response => (await response.json())as ResponseDto<NoContentDto>)
        .catch(error => {
                console.log(error);
                return new ResponseDto<NoContentDto[]>([error], null)
            })
    }

}