import { ResponseDto } from "@/Dtos";
import { LoginDto, LoginResponseDto,RegisterDto } from "@/Pages";

export class EndpointCustomer {
    async registerCustomer(customer:RegisterDto): Promise<ResponseDto<RegisterDto[]>> 
    {
       return await fetch("https://localhost:7208/api/Customer/Register",{
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            },
            body: JSON.stringify(customer)
        })
        .then(async response => {
            return await response.json() as ResponseDto<RegisterDto[]>;
        }).catch(error => {
            console.log(error);
            return new ResponseDto<RegisterDto[]>([error], null);
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