import { Component,Input, Output,EventEmitter} from '@angular/core';
import{CommonModule} from '@angular/common';
import { FormGroup, FormControl,Validators,ReactiveFormsModule ,FormsModule} from '@angular/forms';
import{ActivatedRoute,Route,Router,RouterOutlet,RouterModule} from'@angular/router';

@Component({
  selector: 'app-pay-purchase',
  standalone: true,
  imports: [FormsModule,CommonModule,ReactiveFormsModule,RouterModule,RouterOutlet],
  templateUrl: './pay-purchase.component.html',
  styleUrl: './pay-purchase.component.css'
})
export class PayPurchaseComponent {

    @Input() amount:number ;

    public myForm : FormGroup;
  constuctor() {
  };
  
formCustomer = new FormGroup(
    {
     firstName: new FormControl('',[Validators.maxLength(13)]),
     lastName: new FormControl('',[Validators.maxLength(20)]),
     CreditCardNumber:new FormControl('',[Validators.minLength(16), Validators.maxLength(16)]),
     email:new FormControl('',Validators.required),
    phone:new FormControl('',Validators.maxLength(10)),
    }
  );
  save()
  {
    alert( "הקנייה בוצעה בהצלחה")
    
  
  }
}
