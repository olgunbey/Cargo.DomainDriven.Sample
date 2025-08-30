import { ResponseDto } from "@/Dtos";
import { ClientCredentialDto } from "@/Dtos/ClientCredentialDto";
import axios from "axios";

const instance = axios.create({
    baseURL:'/api/',
    method:'GET'
});


instance.interceptors.request.use(async (config)=>{

    if(config.url =="Identity/Refresh")
    {
        const response  = await axios({
        url:'/api/Identity/Token',
        method:'POST',
        data:{
            clientId:import.meta.env.VITE_CLIENTID,
            clientSecret:import.meta.env.VITE_CLIENTSECRET
        }
    })
    var dtoResponse = response.data as ResponseDto<ClientCredentialDto>;
    config.headers.Authorization = `Bearer ${dtoResponse.data?.accessToken}`
    }
    return config;
});

export default instance;