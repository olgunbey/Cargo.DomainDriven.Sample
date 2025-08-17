export class ResponseDto<T> {


    public errors: string[];
    public data: T | null;


    constructor(errors:string[],data:T ) {
        this.errors = errors || [];
        this.data = data || null;
        
    }
}
