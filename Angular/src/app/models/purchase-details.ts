export class PurchaseDetails {
    purchaseDetailsId:number;
    purchaseId:number;
    productId:number;
    quantity:number;

    constructor(purchaseDetailsId:number,purchaseId:number,productId:number, quantity:number)
    {
       this.productId=productId;
       this.purchaseDetailsId=purchaseDetailsId;
       this.purchaseId=productId;
       this.quantity=quantity;
    }
    
}
