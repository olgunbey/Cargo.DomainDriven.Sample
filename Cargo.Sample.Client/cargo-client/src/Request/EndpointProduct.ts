
import { GetAllCategoryResponseDto,GetAllProductByCategoryIdResponseDto,ResponseDto } from "@/Dtos/index";

export class EndpointProduct {
      async getAllCategories(): Promise<ResponseDto<GetAllCategoryResponseDto[]>> {
        return await fetch('https://localhost:7208/api/Category/GetAllCategory',{
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
        .then(async response => {
            return await response.json() as ResponseDto<GetAllCategoryResponseDto[]>;
        }).catch(error => {
            console.log(error);
            return new ResponseDto<GetAllCategoryResponseDto[]>([error], null);
        });
    }
    async getProductsByCategoryId(categoryId:string):Promise<ResponseDto<GetAllProductByCategoryIdResponseDto[]>>{
        return await fetch(`https://localhost:7208/api/Product/GetAllProductByCategoryId/`, {
            method:'GET',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'categoryIdRequest': categoryId
            }
        })
        .then(async response => {
            return await response.json() as ResponseDto<GetAllProductByCategoryIdResponseDto[]>;
        }).catch(error => {
            console.log(error);
            return new ResponseDto<GetAllProductByCategoryIdResponseDto[]>([error], null);
        });
        
    }
    
}

