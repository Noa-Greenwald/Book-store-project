export class Purchase {
    purchaseId:number;
    customerId:number;
    purchaseDate:Date;
    amountPay:number;
    remark:string;
    constructor(purchaseId:number,
        customerId:number,
        purchaseDate:Date,
        amountPay:number,
        remark:string){
            this.amountPay=amountPay;
            this.customerId=customerId;
            this.purchaseDate=purchaseDate;
            this.purchaseId=purchaseId;
            this.remark=remark;

    }
}
