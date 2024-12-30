import { Component } from '@angular/core';
import { StoreServiceService } from '../store-service.service';
import { Product } from '../models/product';
import { CommonModule } from '@angular/common';
import { PayPurchaseComponent } from '../pay-purchase/pay-purchase.component';
import { Router } from '@angular/router';


@Component({
  selector: 'app-shopping-cart',
  standalone: true,
  imports: [CommonModule, PayPurchaseComponent],
  templateUrl: './shopping-cart.component.html',
})
export class ShoppingCartComponent {
  listOfPurchase: Product[] = []; 
  listOfPurchaseToShow: Product[] = []; 
  amount: number = 0;
  maxAmount: number = 5000; 
  isProperties: boolean = false;
  currentAmount: number;

  constructor(private storeService: StoreServiceService, private router:Router) {
    storeService.getlistOfPurchase().then(data => {
      this.listOfPurchase = data;
      this.updateCartDetails();
    });

    this.listOfPurchase = this.storeService.listOfPurchase;
    this.listOfPurchaseToShow = this.storeService.listOfPurchase; 
  }

  deleteProduct(product: Product) {
    this.storeService.listOfPurchase = this.storeService.listOfPurchase.filter(p => p !== product);
    this.listOfPurchaseToShow = this.storeService.listOfPurchase;
    this.updateCartDetails(); 
  }

  updateCartDetails() {
    this.amount = this.listOfPurchase.reduce((sum, item) => sum + item.price, 0);
    console.log("סכום בסל:", this.amount);

    if (this.amount > this.maxAmount) {
      alert(`חריגה ממגבלת הסכום המותרת של ${this.maxAmount} ש\"ח! יש להסיר פריטים כדי להמשיך.`);
    }
  }

  addProduct(product: Product) {
    const potentialTotal = this.amount + product.price;

    if (potentialTotal > this.maxAmount) {
      alert(`לא ניתן להוסיף את הפריט. הסכום הכולל יחרוג ממגבלת ${this.maxAmount} ש\"ח.`);
      return;
    }

    this.storeService.listOfPurchase.push(product);
    this.updateCartDetails(); 
  }

  finishShopping(amount: number) {
    
    if (this.amount > this.maxAmount) {
      alert(`לא ניתן להשלים את הקנייה - חרגת ממגבלת הסכום המותרת של ${this.maxAmount} ש\"ח!`);
      return;
    }
    this.router.navigate(['/PayPurchaseComponent'])
    this.isProperties = true;
    this.currentAmount = amount;
  }
}



 




