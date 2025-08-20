
import { GetAllCategoryResponseDto,ProductDto,ResponseDto } from "@/Dtos/index";

export class EndpointProduct {
      async getAllCategories(): Promise<ResponseDto<GetAllCategoryResponseDto[]>> {
        return await fetch('/api/Category/GetAllCategory',{
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
    async getProductsByCategoryId(categoryId:string):Promise<ResponseDto<ProductDto[]>>{
        return await fetch(`/api/Product/GetAllProductByCategoryId/`, {
            method:'GET',
            headers: {
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'categoryIdRequest': categoryId
            }
        })
        .then(async response => {
            return await response.json() as ResponseDto<ProductDto[]>;
        }).catch(error => {
            console.log(error);
            return new ResponseDto<ProductDto[]>([error], null);
        });
        
    }
    
}

