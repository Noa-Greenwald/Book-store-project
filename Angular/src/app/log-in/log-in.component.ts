import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StoreServiceService } from '../store-service.service';


@Component({
  selector: 'app-log-in',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './log-in.component.html',
  styleUrls: ['./log-in.component.css'],
})
export class LogInComponent {

  constructor(private storeService: StoreServiceService) { }

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
      console.log('Registration Data:', this.registerData);
    } else {
      alert('Please fill in all required fields.');
    }
  }
answer:boolean
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

}
