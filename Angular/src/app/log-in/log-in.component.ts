import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StoreServiceService } from '../store-service.service';
import { Customer } from '../models/customer';

@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent {
  constructor(private storeService: StoreServiceService) {}

  isLoginMode: boolean = true;

  loginData = {
    email: '',
    customerName: ''
  };

  registerData = {
    customerName: '',
    email: '',
    phone: '',
    birthday: ''
  };

  answer: boolean = false;

  toggleMode() {
    this.isLoginMode = !this.isLoginMode;
  }

  login() {
    if (this.loginData.email && this.loginData.customerName) {
      console.log('Login Data:', this.loginData);
    } else {
      alert('Please fill in all required fields.');
    }
  }

  register() {
    if (
      this.registerData.customerName &&
      this.registerData.email &&
      this.registerData.phone &&
      this.registerData.birthday
    ) {
      this.storeService.registerCustomer(this.registerData).subscribe({
        next: (response) => {
          alert('הרישום הצליח! ברוך הבא למערכת.');
          window.location.href = '/home';
        },
        error: (err) => {
          console.error('Error during registration:', err);
          alert('הרישום נכשל. אנא נסה שנית מאוחר יותר.');
        }
      });
    } else {
      alert('אנא מלא את כל השדות הנדרשים.');
    }
  }

  CheckIfEMailExists(email: string) {
    this.storeService.checkCustomerEmail(email).subscribe({
      next: (exists: boolean) => {
        this.answer = exists;
        if (exists) {
          window.location.href = '/shopping-cart';
        } else {
          alert('האימייל אינו רשום במערכת. נא להירשם.');
          this.toggleMode();
        }
      },
      error: (err) => {
        console.error('Error checking email:', err);
      }
    });
  }

  logIn() {
    const customer = new Customer(
      0, // מזהה חדש - ייווצר בצד השרת
      this.registerData.customerName,
      Number(this.registerData.phone),
      this.registerData.email,
      new Date(this.registerData.birthday)
    );

    this.storeService.insertCustomer(customer).subscribe(
      (response) => {
        console.log('Customer inserted successfully', response);
      },
      (error) => {
        console.error('Error inserting customer', error);
      }
    );
  }
}
