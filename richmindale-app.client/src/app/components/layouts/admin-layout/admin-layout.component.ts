import { Component, OnInit } from '@angular/core';
import { StorageService } from '../../../shared/services/auth/storage.service';
import { AuthService } from '../../../shared/services/auth/auth.service';

@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html'
})
export class AdminLayoutComponent implements OnInit {
  isExpand:boolean = true;
  isCollapsed: boolean = false;
  id:any;
  name: any;
  role:any;
  isMobile:boolean = false;

  constructor(private storage: StorageService, private service: AuthService) {}

  toggleSideBar(): void {  
    this.isExpand = !this.isExpand;
  }

  toggleCollapse(section:any) : void {
    document.getElementById(section)
    this.isCollapsed = !this.isCollapsed;
  }

  ngOnInit(): void {
     if(window.innerWidth < 701) {
      this.isMobile = true;
      this.isExpand = !this.isMobile;
     }
     this.id = this.storage.getSession('UserId');
     if(this.id !== '' || this.id !== 'undefined' || this.id !== null) {
       this.name = this.storage.getSession("DisplayName");
       this.role = this.storage.getSession('RoleName');
     } else {
       window.location.href = '/home';
     }
  }

  DoLogOut() : void {
    this.storage.clearSession();
    this.storage.saveSession("UserId", "");
    this.storage.saveSession("RoleId","");
    this.storage.saveSession("RoleName","");
    this.storage.saveSession("IsLoggedIn","0");
    this.storage.saveSession('IsAdmin','0');
    window.location.href = '/';
  }

  

}
