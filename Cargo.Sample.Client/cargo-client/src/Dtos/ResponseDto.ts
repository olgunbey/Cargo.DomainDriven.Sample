export class ResponseDto<T> {


    public Errors: string[];
    public Data: T | null;


    constructor(errors:string[],data:T ) {
        this.Errors = errors || [];
        this.Data = data || null;
        
    }
}
