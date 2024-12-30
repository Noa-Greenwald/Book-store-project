import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Product } from '../models/product';
import { StoreServiceService } from '../store-service.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-show-product',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './show-product.component.html'
})
export class ShowProductComponent {

  @Input() product: Product;
  @Output() returntostore = new EventEmitter<void>();

  maxAmount: number = 5000;
  currentTotal: number = 0; 

  constructor(private StoreService: StoreServiceService) {
    this.updateCurrentTotal();
  }

  inputBook() {
    this.returntostore.emit();
  }

  addToShoppingCart(product: Product) {
    const newTotal = this.currentTotal + product.price;

    if (newTotal > this.maxAmount) {
      alert(`לא ניתן להוסיף מוצר זה. סכום הסל הכולל חורג מהמגבלה של ${this.maxAmount} ש"ח. נא למחוק פריטים כדי להוסיף.`);
      return;
    }

    this.StoreService.listOfPurchase.push(product);
    this.updateCurrentTotal(); 
    console.log("מוצר נוסף לסל:", this.StoreService.listOfPurchase);
  }

  removeFromShoppingCart(product: Product) {
    this.StoreService.listOfPurchase = this.StoreService.listOfPurchase.filter(p => p !== product);
    this.updateCurrentTotal(); 
    alert(`המוצר '${product.productName}' הוסר מהסל.`);
    console.log("עדכון סל לאחר מחיקה:", this.StoreService.listOfPurchase);
  }

  updateCurrentTotal() {
    this.currentTotal = this.StoreService.listOfPurchase.reduce((sum, item) => sum + item.price, 0);
    console.log("סכום נוכחי בסל:", this.currentTotal);
  }

  canAddProduct(product: Product): boolean {
    const newTotal = this.currentTotal + product.price;
    return newTotal <= this.maxAmount;
  }
}