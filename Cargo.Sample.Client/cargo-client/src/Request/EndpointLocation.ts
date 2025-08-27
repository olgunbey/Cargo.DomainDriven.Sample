import { GetAllLocationForOrderResponseDto } from "@/Components/Basket.vue";
import { ResponseDto, NoContentDto, SaveLocationForOrderRequestDto } from "@/Dtos";
import {CityDto} from "@/Components/OrderTargetLocationPopUp.vue";


export class EndpointLocation {
    public static endpointLocation: EndpointLocation | null

    public static SingletonEndpointRequest(): EndpointLocation {

        if (this.endpointLocation == null) {
            this.endpointLocation = new EndpointLocation()
        }
        return this.endpointLocation;
    }


    async GetAllCity(): Promise<ResponseDto<CityDto[]>> {
        return await fetch("/api/Location/GetAllLocation", {
            method: 'GET',
            headers: {
                'Content-type': 'application/json',
                'Accept': 'application/json'
            }
        }
        )
            .then(async response => (await response.json()) as ResponseDto<CityDto[]>)
            .catch(error => {
                console.log(error);
                return new ResponseDto<CityDto[]>([error], null)
            })
    }
    async SaveLocationForOrder(dto: SaveLocationForOrderRequestDto): Promise<ResponseDto<NoContentDto>> {
        return await fetch("/api/Location/SaveLocationForOrder", {
            method: 'POST',
            headers: {
                'Content-type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(dto)
        })
            .then(async response => (await response.json()) as ResponseDto<NoContentDto>)
            .catch(error => {
                console.log(error);
                return new ResponseDto<NoContentDto[]>([error], null)
            })
    }

    async GetAllLocationForOrder(customerId:string): Promise<ResponseDto<GetAllLocationForOrderResponseDto[]>> {
        return await fetch("/api/Location/GetAllSaveLocationForOrder", {
            method: 'GET',
            headers: {
                'Content-type': 'application/json',
                'Accept': 'application/json',
                'customerId':customerId
            }
        })
            .then(async response => (await response.json()) as ResponseDto<GetAllLocationForOrderResponseDto[]>)
            .catch(error => {
                console.log(error);
                return new ResponseDto<GetAllLocationForOrderResponseDto[]>([error], null)
            })
    }
    async RemoveLocationForOrder(locationId:string):Promise<ResponseDto<NoContentDto>>
    {
        return await fetch("/api/Location/RemoveLocationForOrder",{
            method:'GET',
            headers:{
                'Content-type':'application/json',
                'Accept':'application/json',
               'locationId':locationId
            }
        })
        .then(async response => (await response.json()) as ResponseDto<NoContentDto>)
        .catch(error => {
            console.log(error);
            return new ResponseDto<NoContentDto>([error], null)
        })
    }
    async UpdateLocationForOrder(location:GetAllLocationForOrderResponseDto):Promise<ResponseDto<NoContentDto>>
    {
        return await fetch("/api/Location/UpdateLocationForOrder",{
            method:'GET',
            headers:{
                'Content-type':'application/json',
                'Accept':'application/json',
                'id':location.id,
                'districtId':location.districtId,
                'cityId':location.cityId,
                'detail':location.detail
            }
        })
        .then(async response => await(response.json()) as ResponseDto<NoContentDto>)
        .catch(error => {
                console.log(error);
                return new ResponseDto<NoContentDto>([error], null)
        })
    }

}