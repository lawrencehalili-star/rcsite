import { Component } from '@angular/core';
import { AuthService } from '../../../../shared/services/auth/auth.service';
import { StorageService } from '../../../../shared/services/auth/storage.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html'
})
export class AuthenticationComponent  {
  loading:boolean = false;
  username:any;
  password:any;

  constructor(private service: AuthService, private storage:StorageService, private toastr: ToastrService){}

  AuthenticateAdmin(event:any) : void {
    event.target.disabled = true;
    this.loading = true;
    this.service.authenticateAdmin(this.username, this.password).subscribe(res => {
      if(res.status === 'success') {
        if(res.info.Id !== '00000000-0000-0000-0000-000000000000') {
          this.storage.saveSession("UserId", res.info.UserId);
          this.storage.saveSession("IsAdmin", "1");
          this.storage.saveSession("IsLoggedIn", "1");
          this.storage.saveSession("DisplayName", res.info.DisplayName);
          this.storage.saveSession("RoleId", res.info.RoleId);
          this.storage.saveSession("RoleName", res.info.RoleName);
          this.storage.removeSession('StudentId');
          this.toastr.success(res.msg);
          window.location.href = '/admin/dashboard';
        } else {
          event.target.disabled = false;
          this.toastr.error("Invalid credentials");
        }
      } else {
        event.target.disabled = false;
        this.toastr.error(res.msg);
        this.username = '';
        this.password = '';
        this.storage.saveSession("IsLoggedIn", "0");
      }
    });
    this.loading = false;
  }

}
