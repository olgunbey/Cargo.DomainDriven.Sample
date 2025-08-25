
export {}; 

declare global {
  interface Array<T> {
    Single(predicate: (item: T) => boolean): T;
  }
}

Array.prototype.Single = function<T>(this:T[],predicate:(item:T)=>boolean){
 const result = this.filter(predicate)
    if(result.length >1)
    {
        throw new Error("Max bir tane dönebilir")
    }
    if(result.length == 0)
        throw new Error("Boş")

    return result[0]
}

