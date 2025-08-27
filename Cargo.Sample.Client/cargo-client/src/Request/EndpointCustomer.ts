import { NoContentDto, ResponseDto } from "@/Dtos";
import { LoginDto, LoginResponseDto,RegisterDto } from "@/Pages";

export class EndpointCustomer {

    public static endpoint:EndpointCustomer | null
    public static GetEndpointCustomer():EndpointCustomer{

        if(this.endpoint == null)
            this.endpoint = new EndpointCustomer();

        return this.endpoint;

    }


    async registerCustomer(customer:RegisterDto): Promise<ResponseDto<NoContentDto>> 
    {
       return await fetch("/api/Customer/Register",{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(customer)
        })
        .then(async response => {
            return await response.json() as ResponseDto<NoContentDto>;
        }).catch(error => {
            console.log(error);
            return new ResponseDto<NoContentDto>([error], null);
        });
    }
    async loginCustomer(loginDto:LoginDto): Promise<ResponseDto<LoginResponseDto>> {

        return await fetch("/api/Identity/Login",{
            method:'POST',
            headers:{
                'Content-Type':'application/json'
            },
            body:JSON.stringify(loginDto)
        }).then(async response =>await response.json() as ResponseDto<LoginResponseDto>)
        .catch(error =>{
            console.log(error);
            return new ResponseDto<LoginResponseDto>([error],null)
        });
    }
}