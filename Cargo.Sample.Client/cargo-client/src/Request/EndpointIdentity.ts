import { NoContentDto, ResponseDto } from "@/Dtos";
import { LoginDto, RegisterDto } from "@/Pages";
import axios from "axios";
import instance from "@/Request/AxiosInterceptor";
import { UserDto } from "@/Dtos/UserDto";

export class EndpointIdentity {

    public static endpointIdentity:EndpointIdentity
    public static GetEndpointIdentity():EndpointIdentity{

        if(this.endpointIdentity ==null)
            this.endpointIdentity = new EndpointIdentity()

        return this.endpointIdentity;
    }
    async Refresh(refreshToken:string):Promise<ResponseDto<UserDto>>
    {
        return await instance({
            url:'Identity/Refresh',
            method:'GET',
            headers: {
                'refreshToken':refreshToken
            }
        }).then(response => response.data as ResponseDto<UserDto>)
        .catch(error=> {
            console.log(error)
            return new ResponseDto<UserDto>(error,null)
        })
        
    }
    async loginCustomer(loginDto:LoginDto): Promise<ResponseDto<UserDto>> {
        
        return await axios({
            url:'/api/Identity/Login',
            method:'POST',
            data:{
                clientId: loginDto.clientId,
                clientSecret: loginDto.clientSecret,
                mail: loginDto.mail,
                password: loginDto.password
            }
        }).then(async response =>await response.data as ResponseDto<UserDto>)
            .catch(error =>{
                console.log(error);
                return new ResponseDto<UserDto>([error],null)
            });
        }
        async registerCustomer(customer:RegisterDto): Promise<ResponseDto<NoContentDto>> {
        return await axios({
            method:'POST',
            url:'/api/Identity/Register',
            data:{
                name:customer.name,
                mail:customer.mail,
                gender:customer.gender,
                password:customer.password,
                surname:customer.surname
            }
        })
        .then((response)=> response.data as ResponseDto<NoContentDto>)
        .catch((error)=>{
            console.log(error)
            return new ResponseDto<NoContentDto>(error,null)
        })
    }
        
}