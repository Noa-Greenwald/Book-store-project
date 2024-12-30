import { Routes } from '@angular/router';
import{HomeComponent } from './home/home.component'
import{NotFoundComponent } from './not-found/not-found.component'
import{ShoppingCartComponent } from './shopping-cart/shopping-cart.component'
import{StoreProductsComponent } from './store-products/store-products.component'
import { PayPurchaseComponent } from './pay-purchase/pay-purchase.component';
import { ShowProductComponent } from './show-product/show-product.component';
import { LogInComponent } from './log-in/log-in.component';


export const routes: Routes = [
    {path:'',component:HomeComponent},
    {path:'log-in',component:LogInComponent},
    {path:'home',component:HomeComponent},
    {path:'shopping-cart',component:ShoppingCartComponent},
    {path:'store-product',component:StoreProductsComponent},
    {path:'show-product',component:ShowProductComponent},
    {path:'pay-purchase',component:PayPurchaseComponent},
    {path:'**',component:NotFoundComponent}
];
