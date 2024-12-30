import { Component} from '@angular/core';
import { Product } from '../models/product';
import { StoreServiceService } from '../store-service.service';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms'
import { ShowProductComponent } from '../show-product/show-product.component';
import { Category } from '../models/category';

@Component({
  selector: 'app-store-products',
  standalone: true,
  imports: [CommonModule,FormsModule,ShowProductComponent],
  templateUrl: './store-products.component.html',
  styleUrls: ['./store-products.component.css'] 
})

export class StoreProductsComponent {
  productList:Product[]=[];
  allproductList:Product[]=[];
  categories:Category[]=[];
  selectedCategoryName: string | null = null;



  constructor(private storeService: StoreServiceService) {

this.storeService.getProductList().subscribe(
  data=> {
  this.productList=data;
this.allproductList=data;}
  ,err=>{console.log('err')
  
});
this.loadCategories()
}
  currentProduct:Product;
  matchAge:number=0;
  isProperties:Boolean=false;
  
  sortListup(){
    this.productList=this.productList.sort((a:Product, b:Product)=>a.price-b.price)
  }
  sortListdown()
  {this.productList=this.productList.sort((a:Product, b:Product)=>b.price-a.price)}

  filterAge(){
   this.productList=this.productList.filter(n => n.matchAge==this.matchAge)
  }
  inputBook(product:Product){
    this.isProperties=true;
    this.currentProduct=product;
    
  }
  returntostore(){
    this.isProperties=false;
  }
  
  showAll(){
    this.productList=this.allproductList;
  }
   loadCategories(): void {
    this.storeService.getCategories().subscribe(
      (data) => {
        this.categories = data;
      },
      (error) => {
        console.error('Error loading categories:', error);
      }
    );
  }
  filterByCategory(categoryName: string | null): void {
    if (categoryName !== null) {
      this.storeService.getbycategoryId(categoryName).subscribe((products: Product[]) => {
        this.productList = products;
      });
    }
  }
  
  } 
  












































































