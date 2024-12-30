export class Product {
    productId:number;
    productName:string;
    categoryId:number;
    companyId:Number;
    description:string;
    matchAge:number;
    price:number;
    picture:String;
    lastUpdatedDate:Date;

    constructor( productId:number, productName:string, categoryId:number, companyId:Number,description:string,matchAge:number,price:number,  picture:String, lastUpdatedDate:Date)
    {
        this.productId=productId;
        this.productName=productName;
        this.companyId=companyId;
        this.categoryId=categoryId;
        this.description=description;
        this.matchAge=matchAge;
        this.price=price;
        this.picture=picture;
        this.lastUpdatedDate=lastUpdatedDate

    }
}
