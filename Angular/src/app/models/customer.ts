export class Customer {
    customerId:number;
    customerName:string;
    phone:number;
    email:string;
    birthday:Date;

    constructor(customerId:number, customerName:string, phone:number, email:string, birthday:Date)
    {
        this.customerId=customerId;
        this.customerName=customerName;
        this.phone=phone;
        this.email=email;
        this.birthday=birthday;

    }
}
