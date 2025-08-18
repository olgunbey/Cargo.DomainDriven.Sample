import { ResponseDto,RegisterDto } from "@/Dtos";
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
}