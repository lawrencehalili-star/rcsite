import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { StorageService } from '../../../shared/services/auth/storage.service';
import { AuthService } from '../../../shared/services/auth/auth.service';

@Component({
  selector: 'app-portal-layout',
  templateUrl: './portal-layout.component.html'
})
export class PortalLayoutComponent implements OnInit {
  
 isExpand:boolean = true;
 id: any;
 name:any;
 role:any;
 isMobile:boolean = false;
 

  constructor(private storage: StorageService, private service: AuthService) {}

  toggleSideBar(): void {  
    this.isExpand = !this.isExpand;
  }

  ngOnInit(): void {
    if(window.innerWidth < 701) {
      this.isMobile = true;
      this.isExpand = false;
     }
    this.name = this.storage.getSession("DisplayName");
    this.role = this.storage.getSession("RoleName");
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
