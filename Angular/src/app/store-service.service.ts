import { Injectable } from '@angular/core';
import { Product } from './models/product';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from './models/category';
import { Customer } from './models/customer';

@Injectable({
  providedIn: 'root'
})
export class StoreServiceService {
listOfPurchase:Product[]=[];
 constructor(private http:HttpClient) {}

   getProductList(): Observable<Product[]> 
   {
     return this.http.get<Product[]>("http://localhost:5133/api/Product/products");
   }
   getCategories(): Observable<Category[]> 
   {
      return this.http.get<Category[]>("http://localhost:5133/api/Product/categories");
   }
 
   getbycategoryId(category: string): Observable<Product[]> {
    const url = `http://localhost:5133/api/Product/PostByCategoryName/${category}`;
    return this.http.post<Product[]>(url, {});
  }
  
  checkCustomerEmail(email:string):Observable<boolean>
  {
  const url=`http://localhost:5133/api/Product/GetCheckCustomerEmail/${email}`;
  return this.http.get<boolean>(url)
  }
  getlistOfPurchase()
  {
     return Promise.resolve(this.listOfPurchase);
  }
  registerCustomer(customerData: any): Observable<any> {
    const url = 'http://localhost:5133/api/Customer/Register';
    return this.http.post(url, customerData);
  }
  private apiUrlCustomer = 'http://localhost:5252/api/Costumer/InsertCustomer';

  insertCustomer(customer: Customer): Observable<Customer> {
    return this.http.post<Customer>(this.apiUrlCustomer, customer);
  }
}