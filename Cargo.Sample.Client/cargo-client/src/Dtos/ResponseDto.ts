export class ResponseDto<T> {


    public errors: string[];
    public data: T | null;


    constructor(errors:string[],data:T| null) {
        this.errors = errors || [];
        this.data = data;
        
    }
}
