import { Component, OnDestroy, OnInit } from '@angular/core';
import { StorageService } from '../../../shared/services/auth/storage.service';
@Component({
  selector: 'app-public-layout',
  templateUrl: './public-layout.component_1.html',
  // templateUrl: './public-layout.component.html'
})
export class PublicLayoutComponent implements OnInit, OnDestroy {
  isLoggedIn: boolean = false;
  showNav: boolean = false;
  name: any;
  role: any;
  
  //var for dropdown menu
  isMenuOpen: boolean = false;

  constructor(private storage: StorageService) {}

  toggleNav() {
    this.showNav = !this.showNav;
  }
  
  //toggle method for dropdown menu
 toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
 }
  
  ngOnInit(): void {
    this.isLoggedIn =
      this.storage.getSession('IsLoggedIn') === '0' ? false : true;
    if (this.isLoggedIn) {
      this.name = this.storage.getSession('DisplayName');
      this.role = this.storage.getSession('RoleName');
    }
  }

  ngOnDestroy(): void {}

  DoLogOut(): void {
    this.storage.clearSession();
    this.storage.saveSession('UserId', '');
    this.storage.saveSession('UserId', '');
    this.storage.saveSession('RoleId', '');
    this.storage.saveSession('RoleName', '');
    this.storage.saveSession('IsLoggedIn', '0');
    this.storage.saveSession('IsAdmin', '0');
  }

  NavigateDashboard(): void {
    if (this.storage.getSession('IsAdmin') === '1') {
      window.location.href = '/admin/dashboard';
    } else {
      window.location.href = '/rims/dashboard';
    }
  }

  onPaymentClick(): void {}

  menuOpen = true;
}
