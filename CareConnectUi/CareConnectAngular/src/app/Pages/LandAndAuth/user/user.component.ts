import { CommonModule } from "@angular/common";
import { Component, OnInit, Output, EventEmitter } from "@angular/core";
import { DashboardComponent } from "../../dashboard/dashboard.component";
import { RouterLink } from "@angular/router";

interface UserDetails {
  id: string;
  email: string;
  name: string;
  phoneNumber: string;
}

interface StorageData {
  user: {
    user: UserDetails;
    token: string;
    role: string;
  };
}

@Component({
  selector: 'app-user',
  standalone: true,
  imports: [CommonModule, DashboardComponent,RouterLink],
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  @Output() closePopup = new EventEmitter<void>();

  userDetails: UserDetails = {
    id: '',
    email: '',
    name: '',
    phoneNumber: ''
  };

  userId: string = '';
  name: string = '';
  email: string='';
  phoneNumber:number= 0;
show: any;

  ngOnInit(): void {
    const userStr = localStorage.getItem('user');
    if (userStr) {
      try {
        const parsedData = JSON.parse(userStr);
        const user = parsedData.user;
        // Assign values to the component properties
        this.userId = user.id;
        this.name = user.name;
        this.email=user.email;
        this.phoneNumber=user.phoneNumber;
      } catch (error) {
        console.error('Error parsing the user data:', error);
      }
    } else {
      console.warn('No user data found in localStorage.');
    }

  }


  

  onClose() {
    this.closePopup.emit();
  }

  // Helper method to get user role
  getUserRole(): string {
    const userStr = localStorage.getItem('user');
    if (userStr) {
      try {
        const storageData: StorageData = JSON.parse(userStr);
        return storageData.user.role;
      } catch {
        return 'User';
      }
    }
    return 'User';
  }
}